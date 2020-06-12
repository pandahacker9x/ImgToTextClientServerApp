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
    public class Sender
    {
        public static void SendFile(NetworkStream networkStream, string path)
        {
            SendFileType(networkStream, path);
            SendFileContent(networkStream, path);
            //networkStream.Close();
        }

        private static void SendFileType(NetworkStream networkStream, string path)
        {
            SendString(networkStream, Utils.GetFileExtention(path));
        }

        public static void SendString(NetworkStream networkStream, string str)
        {
            byte[] strBytes = Utils.ToBytes(str);
            networkStream.Write(strBytes, 0, strBytes.Length);
            networkStream.Flush();
        }

        private static void SendFileContent(NetworkStream networkStream, string path)
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

    }
}
