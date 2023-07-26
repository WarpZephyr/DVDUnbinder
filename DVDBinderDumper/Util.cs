using SoulsFormats;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DVDBinderDumper
{
    public static class Util
    {
        public static string GetFile(string title = "Get a file", string filter = "All Files (*.*)|*.*", string initialDir = "C:\\Users")
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = title;
            dialog.Filter = filter;
            dialog.Multiselect = false;
            dialog.InitialDirectory = initialDir;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            return dialog.FileName;
        }

        public static string GetFolder(string title = "Get a folder")
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = title;

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            return dialog.SelectedPath;
        }

        public static bool ShowQuestionWarningDialog(string text = "Warning: Are you sure you want to do this?", string title = "Warning Question")
        {
            DialogResult dialog = MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            return dialog == DialogResult.Yes;
        }

        public static string[] GetFiles(string dir, string unkPath)
        {
            var dirPaths = new List<string>();
            dirPaths.AddRange(Directory.GetDirectories(dir));
            dirPaths.AddRange(Directory.GetFiles(dir));
            if (dirPaths.Contains(unkPath))
                dirPaths.Remove(unkPath);

            var paths = new List<string>();
            foreach (string path in dirPaths)
            {
                if (Directory.Exists(path))
                    paths.AddRange(Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories));
                else
                    paths.Add(path);
            }
            return paths.ToArray();
        }

        public static bool Contains(this string str, params string[] options)
        {
            foreach (string option in options)
                if (str.Contains(option))
                    return true;
            return false;
        }

        public static bool EndsWith(this string str, params string[] options)
        {
            foreach(string option in options)
                if (str.EndsWith(option))
                    return true;
            return false;
        }

        public static long GetRequiredSpace(BHD5 bhd)
        {
            long total = 0;
            foreach (var bucket in bhd.Buckets)
            {
                foreach (var fileHeader in bucket)
                {
                    if (bhd.Format > BHD5.Game.DarkSouls2)
                    {
                        total += fileHeader.UnpaddedFileSize;
                    }
                    else
                    {
                        total += fileHeader.PaddedFileSize;
                    }
                }
            }
            return total;
        }
    }
}
