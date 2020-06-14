using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using Tesseract;

namespace Share
{
    public class Utils
    {

        internal static byte[] ToBytes(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        internal static string ToString(byte[] stringBytes, int size)
        {
            return Encoding.ASCII.GetString(stringBytes, 0, size);
        }

        internal static string GetFileExtention(string path)
        {
            var components = Path.GetExtension(path).Split(new[] { '?' });
            var extension = components.Length > 0 ? components[0] : "";

            // Guarantee that extension length = Constanst.EXTENSION_FILE_BYTE_SIZE 
            if (extension == ".jpeg") extension = ".jpg";
            if (extension.Length != 4) extension = Constants.UNKONW_EXTENSION;
            return extension;
        }

        public static string GenerateUniqueFilePath(string folderPath, string fileExtention)
        {
            var uniqueFileName = Guid.NewGuid().ToString();
            return Constants.SERVER_FOLDER_PATH_TO_SAVE + uniqueFileName + fileExtention;
        }

        public static string ImgToText(string imgPath) 
        {
            Bitmap img = new Bitmap(imgPath);
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
            Page page = engine.Process(img, PageSegMode.Auto);
            string text = page.GetText();
            return text;
        }
    }
}