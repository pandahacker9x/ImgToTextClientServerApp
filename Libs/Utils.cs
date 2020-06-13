﻿using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.IO;
using System.Text;

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
            ScriptEngine engine = Python.CreateEngine();
            var pyFile = @"C:\Users\LONG\Documents\Downloads\ImgToTextApp\ImgToTextClientServerApp\Server\Python\img2text.py";
            dynamic py = engine.ExecuteFile(pyFile);
            dynamic text = py.imgTotext(imgPath);
            return text;
        }
    }
}