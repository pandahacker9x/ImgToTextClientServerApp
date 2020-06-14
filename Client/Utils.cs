using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ImgToTextClientApp
{
    internal class Utils
    {
        internal static string SelectImg()
        {
            try 
            {
                var dialog = new OpenFileDialog();
                dialog.Filter =
                    "(Image files *.png, *.jpg)|*.png;*.jpg";
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