using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Share
{
    public class FileHelper
    {
        public static void ReceiveFile(NetworkStream networkStream,
            string pathToSave)
        {
            Debug.WriteLine("Saved image location: " + pathToSave);

            FileStream fileStream = File.Create(pathToSave);

            int frameSize = 1024;
            byte[] buffer = new byte[frameSize];
            int readedBytes = -1;

            while (readedBytes != 0)
            {
                readedBytes = networkStream.Read(buffer, 0, frameSize);
                fileStream.Write(buffer, 0, readedBytes);
            }
            Console.WriteLine("Done receiving image!");

            fileStream.Close();
        }

        public static void SendFile(NetworkStream networkStream, string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[Constants.FRAME];
            int readedBytes = -1;
            while (readedBytes != 0)
            {
                readedBytes = fileStream.Read(buffer, 0, Constants.FRAME);
                networkStream.Write(buffer, 0, readedBytes);
            }
            networkStream.Flush();
            fileStream.Close();
        }

        public static string CreateRandomFileName(string folderPath)
        {
            return Constants.SERVER_FOLDER_PATH_TO_SAVE +  "img";
        }
    }
}
