using BhdLib;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDUnbinder
{
    public partial class FormMain : Form
    {
        private static readonly Properties.Settings settings = Properties.Settings.Default;
        private static readonly string EnvFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string ResFolderPath = $"{EnvFolderPath}\\res";
        private static readonly string OverridePath = $"{ResFolderPath}\\override.txt";
        private static readonly string BlacklistPath = $"{ResFolderPath}\\blacklist.txt";

        public FormMain()
        {
            InitializeComponent();
            Location = settings.WindowLocation;
            if (settings.WindowSize.Width >= MinimumSize.Width && settings.WindowSize.Height >= MinimumSize.Height)
                Size = settings.WindowSize;
            if (settings.WindowMaximized)
                WindowState = FormWindowState.Maximized;

            txtHeader.Text = settings.HeaderPath;
            txtData.Text = settings.DataPath;
            txtDictionary.Text = settings.DictionaryPath;
            txtOutput.Text = settings.OutputDir;
            cbxGenerateCleanDict.Checked = settings.GenerateCleanDictionary;

            cbxGame.DataSource = Enum.GetValues(typeof(BHD5.Game));
            if (cbxGame.Items.Contains(settings.Game))
                cbxGame.Text = settings.Game;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.WindowMaximized = WindowState == FormWindowState.Maximized;
            if (WindowState == FormWindowState.Normal)
            {
                settings.WindowLocation = Location;
                settings.WindowSize = Size;
            }
            else
            {
                settings.WindowLocation = RestoreBounds.Location;
                settings.WindowSize = RestoreBounds.Size;
            }

            settings.HeaderPath = txtHeader.Text;
            settings.DataPath = txtData.Text;
            settings.DictionaryPath = txtDictionary.Text;
            settings.OutputDir = txtOutput.Text;
            settings.GenerateCleanDictionary = cbxGenerateCleanDict.Checked;
        }

        private void BrowseHeaderFile_Click(object sender, EventArgs e)
        {
            string str = Util.GetFile();
            if (str == null)
                return;
            txtHeader.Text = str;
        }

        private void BrowseDataFile_Click(object sender, EventArgs e)
        {
            string str = Util.GetFile();
            if (str == null)
                return;
            txtData.Text = str;
        }

        private void BrowseDictFile_Click(object sender, EventArgs e)
        {
            string str = Util.GetFile();
            if (str == null)
                return;
            txtDictionary.Text = str;
        }

        private void BrowseOutputFolder_Click(object sender, EventArgs e)
        {
            string str = Util.GetFolder();
            if (str == null)
                return;
            txtOutput.Text = str;
        }

        private async void BtnUnpack_Click(object sender, EventArgs e)
        {
            string headerPath = txtHeader.Text;
            string dataPath = txtData.Text;

            if (!File.Exists(headerPath))
            {
                MessageBox.Show("Header file not found.");
                return;
            }
            if (!File.Exists(dataPath))
            {
                MessageBox.Show("Data file not found.");
                return;
            }
            if (!File.Exists(txtDictionary.Text))
            {
                MessageBox.Show("Dictionary file not found.");
                return;
            }
            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show("Please select an output folder.");
                return;
            }
            if (File.Exists(txtOutput.Text))
            {
                MessageBox.Show("Selected output folder is a file, please choose a different name.");
            }

            Directory.CreateDirectory(txtOutput.Text);

            BHD5.Game game = (BHD5.Game)cbxGame.SelectedItem;
            Dictionary<ulong, string> dict = HashDictionary.ReadDictionary(txtDictionary.Text, game);
            string outDir = txtOutput.Text;

            using (var headerStream = File.OpenRead(headerPath))
            using (var dataStream = File.OpenRead(dataPath))
            {
                BHD5 bhd = BHD5.Read(headerStream, game);
                pbrProgress.Maximum = bhd.Buckets.Sum(b => b.Count);
                pbrProgress.Value = 0;
                int foundFiles = 0;
                int notFoundFiles = 0;
                string cleanDictPath = $"{Path.GetDirectoryName(txtDictionary.Text)}\\cleanDict.txt";
                List<string> cleanList = new List<string>();
                File.CreateText(cleanDictPath);

                string drive = Path.GetPathRoot(Path.GetFullPath(outDir));
                DriveInfo driveInfo = new DriveInfo(drive);

                long requiredSpace = Util.GetRequiredSpace(bhd);
                if (driveInfo.AvailableFreeSpace < requiredSpace)
                {
                    DialogResult choice = MessageBox.Show(
                        $"{requiredSpace / 1024 / 1024 / 1024} GB of free space is required to unpack this game; " +
                        $"only {driveInfo.AvailableFreeSpace / (1024f * 1024 * 1024):F1} GB available.\r\n" +
                        "It will most likely fail.\r\n\r\n" +
                        "Do you want to continue?",
                        "Space Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (choice == DialogResult.No)
                        return;
                }

                var overrides = new Dictionary<ulong, string>();
                if (File.Exists(OverridePath))
                {
                    try
                    {
                        foreach (var line in File.ReadAllLines(OverridePath))
                        {
                            var split = line.Split('=');
                            overrides.Add(ulong.Parse(split[0]), split[1]);
                        }
                    }
                    catch { }
                }

                List<string> blacklist = new List<string>();
                if (File.Exists(BlacklistPath))
                {
                    try
                    {
                        blacklist.AddRange(File.ReadAllLines(BlacklistPath));
                    }
                    catch { }
                }

                await Task.Run(() =>
                {
                    foreach (BHD5.Bucket bucket in bhd.Buckets)
                    {
                        foreach (BHD5.FileHeader fileHeader in bucket)
                        {
                            bool found = dict.TryGetValue(fileHeader.FileNameHash, out string name);
                            if (!found || blacklist.Contains($"{fileHeader.FileNameHash}={name}"))
                            {
                                notFoundFiles++;
                                byte[] data = fileHeader.ReadFile(dataStream);

                                string outPath;
                                if (overrides.ContainsKey(fileHeader.FileNameHash))
                                {
                                    outPath = $"{outDir}\\{overrides[fileHeader.FileNameHash]}";
                                }
                                else
                                {
                                    string extension = SFUtil.GuessExtension(data);
                                    string fileName = $"{fileHeader.FileNameHash}{extension}";
                                    string folder = $"{SFUtil.GuessFolder(data, extension)}";
                                    outPath = $"{outDir}\\_unknown\\{folder}{fileName}";
                                }

                                if (!File.Exists(outPath))
                                {
                                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                                    File.WriteAllBytes(outPath, data);
                                }
                            }
                            else if (found)
                            {
                                foundFiles++;
                                cleanList.Add(name);
                                if (!File.Exists($"{outDir}\\{name}"))
                                {
                                    byte[] data = fileHeader.ReadFile(dataStream);
                                    string outPath = $"{outDir}\\{name}";
                                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                                    File.WriteAllBytes(outPath, data);
                                }
                            }

                            Invoke(new Action(() => txtCurrent.Text = $"{notFoundFiles} not found out of {foundFiles + notFoundFiles} total files; {dict.Count} names tried per hash."));
                            Invoke(new Action(() => pbrProgress.Value++));
                        }
                    }
                });

                if (cbxGenerateCleanDict.Checked)
                {
                    File.WriteAllLines(cleanDictPath, cleanList);
                }
            }
        }

        private async void btnDumpBuckets_Click(object sender, EventArgs e)
        {
            string headerPath = txtHeader.Text;

            if (!File.Exists(headerPath))
            {
                MessageBox.Show("Header file not found.");
                return;
            }

            BHD5.Game game = (BHD5.Game)cbxGame.SelectedItem;
            Dictionary<ulong, string> dict = HashDictionary.ReadDictionary(txtDictionary.Text, game);
            string outDir = txtOutput.Text;

            using (var headerStream = File.OpenRead(headerPath))
            {
                BHD5 bhd = BHD5.Read(headerStream, game);
                pbrProgress.Maximum = bhd.Buckets.Count;
                pbrProgress.Value = 0;
                string outPath = $"{outDir}\\buckets.txt";
                List<string> list = new List<string>();
                Directory.CreateDirectory(Path.GetDirectoryName(outPath));
                File.CreateText(outPath);

                await Task.Run(() =>
                {
                    int bucketCount = 0;
                    for (int i = 0; i < bhd.Buckets.Count; i++)
                    {
                        var bucket = bhd.Buckets[i];
                        list.Add($"bucket_{i} count_{bucket.Count}");
                        for (int j = 0; j < bucket.Count; j++)
                            list.Add($"\t{j} {bucket[j].FileNameHash}");
                        list.Add("");
                        bucketCount++;
                        Invoke(new Action(() => txtCurrent.Text = $"Dumped {bucketCount} buckets."));
                        Invoke(new Action(() => pbrProgress.Value++));
                    }
                });
                File.WriteAllLines(outPath, list);
            }
        }

        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                (sender as TextBox).Text = files[0];
            }
        }
    }
}
