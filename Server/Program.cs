using Share;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgToTextServerApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CreateFolderToSaveImgs();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormServerControl());
        }

        public static void CreateFolderToSaveImgs()
        {
            new FileInfo(Constants.SERVER_FOLDER_PATH_TO_SAVE)
                .Directory.Create();
        }

    }
}
