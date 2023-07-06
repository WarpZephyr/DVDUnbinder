using SoulsFormats;
using System.Windows.Forms;

namespace DVDUnbinder
{
    public static class Util
    {
        public static string GetFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            return dialog.FileName;
        }

        public static string GetFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return null;

            return dialog.SelectedPath;
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
