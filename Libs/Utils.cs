using System;
using System.IO;
using System.Text;

namespace Share
{
    internal class Utils
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
    }
}