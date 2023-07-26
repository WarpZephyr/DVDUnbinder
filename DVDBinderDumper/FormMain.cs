using BhdLib;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DVDBinderDumper
{
    public partial class FormMain : Form
    {
        private static readonly Properties.Settings settings = Properties.Settings.Default;
        private static readonly string EnvFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string ResFolderPath = $"{EnvFolderPath}\\res";

        public FormMain()
        {
            InitializeComponent();

            // Initialize settings
            if (settings.WindowSize.Width >= MinimumSize.Width && settings.WindowSize.Height >= MinimumSize.Height)
                Size = settings.WindowSize;
            if (settings.WindowMaximized)
                WindowState = FormWindowState.Maximized;
            txtHeader.Text = settings.HeaderPath;
            txtDictionary.Text = settings.DictionaryPath;
            txtOutput.Text = settings.OutputDirectory;
            chxOption1.Checked = settings.FirstOptionEnabled;
            chxOption2.Checked = settings.SecondOptionEnabled;
            chxOption3.Checked = settings.ThirdOptionEnabled;

            // Verify data integrity on selected indices from settings
            if (settings.FirstOptionSelectedIndex >= 0 && settings.FirstOptionSelectedIndex < cbxOption1.Items.Count)
                cbxOption1.SelectedIndex = settings.FirstOptionSelectedIndex;
            else
                cbxOption1.SelectedIndex = 0;

            if (settings.SecondOptionSelectedIndex >= 0 && settings.SecondOptionSelectedIndex < cbxOption2.Items.Count)
                cbxOption2.SelectedIndex = settings.SecondOptionSelectedIndex;
            else
                cbxOption2.SelectedIndex = 0;

            if (settings.ThirdOptionSelectedIndex >= 0 && settings.ThirdOptionSelectedIndex < cbxOption3.Items.Count)
                cbxOption3.SelectedIndex = settings.ThirdOptionSelectedIndex;
            else
                cbxOption3.SelectedIndex = 0;

            if (settings.DumpOptionSelectedIndex >= 0 && settings.DumpOptionSelectedIndex < cbxDumpOption.Items.Count)
                cbxDumpOption.SelectedIndex = settings.DumpOptionSelectedIndex;
            else
                cbxDumpOption.SelectedIndex = 0;

            cbxGame.DataSource = Enum.GetValues(typeof(BHD5.Game));
            if (cbxGame.Items.Contains(settings.SelectedGame))
                cbxGame.Text = settings.SelectedGame;
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
            settings.DictionaryPath = txtDictionary.Text;
            settings.OutputDirectory = txtOutput.Text;
            settings.DumpOptionSelectedIndex = cbxDumpOption.SelectedIndex;
            settings.FirstOptionSelectedIndex = cbxOption1.SelectedIndex;
            settings.SecondOptionSelectedIndex = cbxOption2.SelectedIndex;
            settings.ThirdOptionSelectedIndex = cbxOption3.SelectedIndex;
            settings.FirstOptionEnabled = chxOption1.Checked;
            settings.SecondOptionEnabled = chxOption2.Checked;
            settings.ThirdOptionEnabled = chxOption3.Checked;
            settings.SelectedGame = cbxGame.SelectedItem.ToString();
            settings.Save();
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

        private void btnBrowseHeader_Click(object sender, EventArgs e)
        {
            string initialDir = "C:\\Users";
            if (settings.HeaderLastBrowsedDirectory != "" && Directory.Exists(settings.HeaderLastBrowsedDirectory))
                initialDir = settings.HeaderLastBrowsedDirectory;

            string path = Util.GetFile("Select the .bhd header file.", "All Files (*.*)|*.*", initialDir);
            if (path == null)
                return;

            settings.HeaderLastBrowsedDirectory = Path.GetDirectoryName(path);
            txtHeader.Text = path;
        }

        private void btnBrowseDictionary_Click(object sender, EventArgs e)
        {
            string initialDir = "C:\\Users";
            if (settings.DictionaryLastBrowsedDirectory != "" && Directory.Exists(settings.DictionaryLastBrowsedDirectory))
                initialDir = settings.DictionaryLastBrowsedDirectory;

            string path = Util.GetFile("Select a dictionary .txt file to use for getting names.", "All Files (*.*)|*.*", initialDir);
            if (path == null)
                return;

            settings.DictionaryLastBrowsedDirectory = Path.GetDirectoryName(path);
            txtDictionary.Text = path;
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            string path = Util.GetFolder("Select the output directory.");
            if (path == null)
                return;
            txtOutput.Text = path;
        }

        private async void btnDump_Click(object sender, EventArgs e)
        {
            if (!VerifyInitialPaths())
                return;
            BHD5.Game game = (BHD5.Game)cbxGame.SelectedItem;
            Dictionary<ulong, string> dict = new Dictionary<ulong, string>();
            if (File.Exists(txtDictionary.Text))
                dict = HashDictionary.ReadDictionary(txtDictionary.Text, game);
            string outDir = txtOutput.Text;
            string outName = GetOptionFileName();
            string outPath = Path.Combine(outDir, outName);

            if (!VerifyOutPath(outName, outPath))
                return;

            var lines = new List<string>();

            string dumpOption = cbxDumpOption.SelectedItem.ToString();
            string option1 = cbxOption1.SelectedItem.ToString();
            string option2 = cbxOption2.SelectedItem.ToString();
            string option3 = cbxOption3.SelectedItem.ToString();

            using (var headerStream = File.OpenRead(txtHeader.Text))
            {
                BHD5 bhd = BHD5.Read(headerStream, game);

                pbrProgress.Maximum = bhd.Buckets.Sum(b => b.Count);
                pbrProgress.Value = 0;

                await Task.Run(() =>
                {
                    int bucketCount = bhd.Buckets.Count;

                    switch (dumpOption)
                    {
                        case "All":

                            for (int i = 0; i < bhd.Buckets.Count; i++)
                            {
                                var bucket = bhd.Buckets[i];
                                foreach (var file in bucket)
                                {
                                    bool found = dict.TryGetValue(file.FileNameHash, out string name);
                                    if (found)
                                    {
                                        lines.Add(GetLine(option1, option2, option3, file.FileOffset, file.FileNameHash, name));
                                    }
                                    else
                                    {
                                        lines.Add(GetLine(option1, option2, option3, file.FileOffset, file.FileNameHash));
                                    }

                                    Invoke(new Action(() => txtCurrent.Text = $"Bucket {i + 1} out of {bucketCount} buckets."));
                                    Invoke(new Action(() => pbrProgress.Value++));
                                }
                            }
                            break;
                        case "Known Names Only":
                            for (int i = 0; i < bhd.Buckets.Count; i++)
                            {
                                var bucket = bhd.Buckets[i];
                                foreach (var file in bucket)
                                {
                                    bool found = dict.TryGetValue(file.FileNameHash, out string name);
                                    if (found)
                                    {
                                        lines.Add(GetLine(option1, option2, option3, file.FileOffset, file.FileNameHash, name));
                                    }

                                    Invoke(new Action(() => txtCurrent.Text = $"Bucket {i + 1} out of {bucketCount} buckets."));
                                    Invoke(new Action(() => pbrProgress.Value++));
                                }
                            }
                            break;
                        case "Unknown Names Only":
                            for (int i = 0; i < bhd.Buckets.Count; i++)
                            {
                                var bucket = bhd.Buckets[i];
                                foreach (var file in bucket)
                                {
                                    bool found = dict.TryGetValue(file.FileNameHash, out string name);
                                    if (!found)
                                    {
                                        lines.Add(GetLine(option1, option2, option3, file.FileOffset, file.FileNameHash));
                                    }

                                    Invoke(new Action(() => txtCurrent.Text = $"Bucket {i + 1} out of {bucketCount} buckets."));
                                    Invoke(new Action(() => pbrProgress.Value++));
                                }
                            }
                            break;
                        default:
                            throw new NotSupportedException($"{dumpOption} is not supported.");
                    }
                });
            }

            File.WriteAllLines(outPath, lines);
        }

        private string GetOptionFileName()
        {
            string name = string.Empty;
            if (chxOption1.Checked)
                name += $"{cbxOption1.SelectedItem}";
            if (chxOption2.Checked)
                if (!string.IsNullOrEmpty(name))
                    name += $"={cbxOption2.SelectedItem}";
                else
                    name += $"{cbxOption2.SelectedItem}";
            if (chxOption3.Checked)
                if (!string.IsNullOrEmpty(name))
                    name += $"={cbxOption3.SelectedItem}";
                else
                    name += $"{cbxOption3.SelectedItem}";
            if (string.IsNullOrEmpty(name))
                name = "dump";
            name += ".txt";
            return name.ToLower();
        }

        private string GetLine(string option1, string option2, string option3, long offset, ulong hash, string name = null)
        {
            string output = string.Empty;

            if (chxOption1.Checked)
            {
                output = AddOption(output, option1, offset, hash, name);
            }

            if (chxOption2.Checked)
            {
                output = AddOption(output, option2, offset, hash, name, chxOption1.Checked);
            }

            if (chxOption3.Checked)
            {
                output = AddOption(output, option3, offset, hash, name, chxOption1.Checked || chxOption2.Checked);
            }

            return output;
        }

        private string AddOption(string output, string option, long offset, ulong hash, string name = null, bool previousSelected = false)
        {
            string add = string.Empty;
            switch (option)
            {
                case "Offset":
                    add += $"{offset}";
                    break;
                case "Name":
                    if (!string.IsNullOrEmpty(name))
                        add += $"{name}";
                    break;
                case "Hash":
                    add += $"{hash}";
                    break;
                default:
                    throw new ArgumentException($"{option} is not a supported option.");
            }

            if (previousSelected && !string.IsNullOrEmpty(add))
                output += $"={add}";
            else
                output += add;
            return output;
        }

        private bool VerifyOutPath(string outName, string outPath)
        {
            if (Directory.Exists(outPath))
            {
                MessageBox.Show($"A folder already exists on the output path named {outName}");
                return false;
            }

            if (File.Exists(outPath))
            {
                DialogResult dialog = MessageBox.Show($"A file already exists on the output path named {outName}, do you wish to overwrite it?", "Overwrite Existing File On Output Path", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog != DialogResult.Yes)
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyInitialPaths()
        {
            if (!File.Exists(txtHeader.Text))
            {
                MessageBox.Show("Header file not found.");
                return false;
            }
            if (!File.Exists(txtDictionary.Text))
            {
                MessageBox.Show("Dictionary file not found.");
                return false;
            }
            if (string.IsNullOrEmpty(txtOutput.Text))
            {
                MessageBox.Show("Please select an output folder.");
                return false;
            }
            if (File.Exists(txtOutput.Text))
            {
                MessageBox.Show("Selected output folder is a file, please choose a different name.");
                return false;
            }
            if (!BHD5.IsBHD(txtHeader.Text))
            {
                MessageBox.Show("Selected header file is not a BHD5 header.");
                return false;
            }
            return true;
        }
    }
}
