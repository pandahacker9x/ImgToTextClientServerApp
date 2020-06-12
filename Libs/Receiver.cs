using Share;
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
    public class Receiver
    {
        public static void ReceiveFileContent(NetworkStream networkStream,
            string pathToSave)
        {
            Debug.WriteLine("Saved image location: " + pathToSave);
            StreamReader stream = new StreamReader(networkStream);

            FileStream fileStream = File.Create(pathToSave);
            Debug.WriteLine("File name " + fileStream.Name);

            byte[] buffer = new byte[Constants.FRAME];
            int readedBytes = -1;
            while (readedBytes != 0)
            {
                readedBytes = networkStream.Read(buffer, 0, Constants.FRAME);
                if (readedBytes != 0)
                    fileStream.Write(buffer, 0, readedBytes);
                Debug.WriteLine("Receives ");
            }

            Debug.WriteLine("Done receiving image!");

            fileStream.Close();
        }

        public static string ReceiveString(NetworkStream networkStream, int stringByteSize = 1024)
        {
            byte[] stringBytes = new byte[Constants.EXTENSION_FILE_BYTE_SIZE];
            int size = networkStream.Read(stringBytes, 0, Constants.EXTENSION_FILE_BYTE_SIZE);
            return Utils.ToString(stringBytes, size); ;
        }
    }
}
