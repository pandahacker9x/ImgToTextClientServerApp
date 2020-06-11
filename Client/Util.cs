using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImgToTextClientApp
{
    internal class Util
    {
        internal static byte[] ToBytes(string msg)
        {
            return Encoding.ASCII.GetBytes(msg);
        }

        internal static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        internal static bool WriteFile(string path, string content)
        {
            try
            {
                var fileStream = File.OpenWrite(path);
                StreamWriter writer = new StreamWriter(fileStream);
                writer.Write(content);
                writer.Flush();
                fileStream.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal static string SelectImg()
        {
            try 
            {
                var dialog = new OpenFileDialog();
                dialog.Filter =
                    "(Image files *.png, *.jpg)|*.png;*.jpg|All files (*.*)|*.*";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}