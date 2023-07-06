using BHDLib;
using SoulsFormats;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDUnbinder
{
    public partial class FormMain : Form
    {
        private static readonly DVDRebinder.Properties.Settings settings = DVDRebinder.Properties.Settings.Default;
        private static readonly string EnvFolderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = "DVDRebinder " + Application.ProductVersion;
            Location = settings.WindowLocation;
            if (settings.WindowSize.Width >= MinimumSize.Width && settings.WindowSize.Height >= MinimumSize.Height)
                Size = settings.WindowSize;
            if (settings.WindowMaximized)
                WindowState = FormWindowState.Maximized;

            txtHeaderName.Text = settings.HeaderName;
            txtDataName.Text = settings.DataName;
            txtInput.Text = settings.InDir;
            txtOutput.Text = settings.OutputDir;
            if (settings.BucketDistribution > 0)
                numBucketDistribution.Value = settings.BucketDistribution;
            cbxBigEndian.Checked = settings.BigEndian;

            cbxGame.DataSource = Enum.GetValues(typeof(BHD5.Game));
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

            settings.HeaderName = txtHeaderName.Text;
            settings.DataName = txtDataName.Text;
            settings.InDir = txtInput.Text;
            settings.OutputDir = txtOutput.Text;
            settings.BucketDistribution = (int)numBucketDistribution.Value;
            settings.Game = cbxGame.Text;
            settings.BigEndian = cbxBigEndian.Checked;
            settings.Save();
        }

        private void btnBrowseHeaderName_Click(object sender, EventArgs e)
        {
            string initialDir = "C:\\Users";
            if (settings.LastBrowseDirectory != "")
                initialDir = settings.LastBrowseDirectory;

            string path = Util.GetFile("Select a file to get it's name for the BHD5 header file.", "All Files (*.*)|*.*", initialDir);
            if (path == null)
                return;

            settings.LastBrowseDirectory = Path.GetDirectoryName(path);
            txtHeaderName.Text = Path.GetFileName(path);
        }

        private void btnBrowseDataName_Click(object sender, EventArgs e)
        {
            string initialDir = "C:\\Users";
            if (settings.LastBrowseDirectory != "")
                initialDir = settings.LastBrowseDirectory;

            string path = Util.GetFile("Select a file to get it's name for the BHD5 data file.", "All Files (*.*)|*.*", initialDir);
            if (path == null)
                return;

            settings.LastBrowseDirectory = Path.GetDirectoryName(path);
            txtDataName.Text = Path.GetFileName(path);
        }

        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            string path = Util.GetFolder("Select a folder with the files to pack into a BHD5.");
            if (path == null)
                return;

            settings.LastBrowseDirectory = path;
            txtInput.Text = path;
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e)
        {
            string path = Util.GetFolder("Select a folder to output the repacked BHD5 to.");
            if (path == null)
                return;

            settings.LastBrowseDirectory = path;
            txtOutput.Text = path;
        }

        private void btnBrowseHeaderBucketCount_Click(object sender, EventArgs e)
        {
            string initialDir = "C:\\Users";
            if (settings.LastBrowseDirectory != "")
                initialDir = settings.LastBrowseDirectory;

            string path = Util.GetFile("Select a BHD5 Header file to get the approximate bucket distribution of.", "Binder Header (*.bhd)|*.bhd|All Files (*.*)|*.*", initialDir);
            if (path == null)
                return;
            if (!BHD5.IsBHD(path))
            {
                MessageBox.Show("Selected file is not a BHD5 header.");
                return;
            }

            BHD5.Game game = (BHD5.Game)cbxGame.SelectedItem;

            using (var headerStream = File.OpenRead(path))
            {
                var bhd = BHD5.Read(headerStream, game);
                numBucketDistribution.Value = (int)Math.Ceiling(decimal.Divide(bhd.Buckets.Sum(b => b.Count), bhd.Buckets.Count));
            }
        }

        private async void btnRepack_Click(object sender, EventArgs e)
        {
            // Initialization
            BHD5.Game game = (BHD5.Game)cbxGame.SelectedItem;
            string headerName = txtHeaderName.Text;
            string dataName = txtDataName.Text;
            string inDir = txtInput.Text;
            string outDir = txtOutput.Text;
            string headerOut = Path.Combine(outDir, headerName);
            string dataOut = Path.Combine(outDir, dataName);
            string unkDir = Path.Combine(inDir, "_unknown");
            bool warning;

            // Empty check
            if (string.IsNullOrEmpty(headerName))
            {
                MessageBox.Show("Header name is empty.");
                return;
            }
            if (string.IsNullOrEmpty(dataName))
            {
                MessageBox.Show("Data name is empty.");
                return;
            }
            if (string.IsNullOrEmpty(inDir))
            {
                MessageBox.Show("Input directory is empty.");
                return;
            }
            if (string.IsNullOrEmpty(outDir))
            {
                MessageBox.Show("Output directory is empty.");
                return;
            }

            // File existing in directory paths check
            if (File.Exists(inDir))
            {
                MessageBox.Show("Please select a folder for input, not a file.");
                return;
            }
            if (File.Exists(outDir))
            {
                MessageBox.Show("Please select a folder for output, not a file.");
                return;
            }

            // Directory exists on file path check
            if (Directory.Exists(headerOut))
            {
                MessageBox.Show("The output path for the Header file is a folder, please select a different name.");
                return;
            }
            if (Directory.Exists(dataOut))
            {
                MessageBox.Show("The output path for the Data file is a folder, please select a different name.");
                return;
            }

            // Files exist check
            if (File.Exists(headerOut))
            {
                warning = Util.ShowQuestionWarningDialog("Warning: Header file already exists on path, do you wish to overwrite it?", "Overwrite Header File");
                if (!warning)
                    return;
            }
            if (File.Exists(dataOut))
            {
                warning = Util.ShowQuestionWarningDialog("Warning: Data file already exists on path, do you wish to overwrite it?", "Overwrite Data File");
                if (!warning)
                    return;
            }

            // Create directories
            if (!Directory.Exists(inDir))
                Directory.CreateDirectory(inDir);
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            string[] paths = Util.GetFiles(inDir, unkDir);
            var unkPaths = new List<string>();
            if (Directory.Exists(unkDir))
                unkPaths.AddRange(Directory.GetFiles(unkDir, "*", SearchOption.AllDirectories));

            pbrProgress.Maximum = paths.Length + unkPaths.Count + 2;
            pbrProgress.Value = 0;

            await Task.Run(() =>
            {
                try
                {
                    Invoke(new Action(() => txtCurrent.Text = $"Generating BHD...."));
                    var bhd = HashDictionary.Generate(inDir, paths, unkPaths.ToArray(), game, (int)numBucketDistribution.Value, cbxBigEndian.Checked, out Dictionary<ulong, string> hashDict);
                    Invoke(new Action(() => pbrProgress.Value++));

                    if (!File.Exists(dataOut))
                    {
                        string drive = Path.GetPathRoot(Path.GetFullPath(outDir));
                        DriveInfo driveInfo = new DriveInfo(drive);

                        long requiredSpace = Util.GetRequiredSpace(bhd);
                        if (driveInfo.AvailableFreeSpace < requiredSpace)
                        {
                            DialogResult choice = MessageBox.Show(
                                $"{requiredSpace / 1024 / 1024 / 1024} GB of free space is required to repack the data file of this game; " +
                                $"only {driveInfo.AvailableFreeSpace / (1024f * 1024 * 1024):F1} GB available.\r\n" +
                                "It will most likely fail.\r\n\r\n" +
                                "Do you want to continue?",
                                "Space Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (choice == DialogResult.No)
                            {
                                Invoke(new Action(() => txtCurrent.Text = $"Canceled repack"));
                                Invoke(new Action(() => pbrProgress.Value = 0));
                                return;
                            }
                        }
                    }

                    using (var fs = new FileStream(headerOut, FileMode.OpenOrCreate))
                    {
                        Invoke(new Action(() => txtCurrent.Text = $"Writing BHD...."));
                        bhd.Write(fs);
                        Invoke(new Action(() => pbrProgress.Value++));
                    }

                    using (var fs = new FileStream(dataOut, FileMode.OpenOrCreate))
                    {
                        int total = 0;
                        foreach (var bucket in bhd.Buckets)
                        {
                            foreach (var fileHeader in bucket)
                            {
                                string path = hashDict[fileHeader.FileNameHash];
                                byte[] bytes = File.ReadAllBytes(hashDict[fileHeader.FileNameHash]);
                                fs.Write(bytes, 0, bytes.Length);
                                total++;

                                Invoke(new Action(() => txtCurrent.Text = $"Packed: {total}; Packing: {HashDictionary.GetRelative(inDir, path)}"));
                                Invoke(new Action(() => pbrProgress.Value++));
                            }
                        }
                        Invoke(new Action(() => txtCurrent.Text = $"Finished packing; Packed: {total} files"));
                    }
                }
                catch (HashCollisionException ex)
                {
                    MessageBox.Show($"Error; stopping Header file generation; {ex.Message}");
                    Invoke(new Action(() => txtCurrent.Text = $"A hash collision was detected"));
                    Invoke(new Action(() => pbrProgress.Value = 0));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unknown error occurred: {ex.Message}");
                    Invoke(new Action(() => txtCurrent.Text = $"An unknown error occurred"));
                    Invoke(new Action(() => pbrProgress.Value = 0));
                }
            });
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
