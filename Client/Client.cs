using Share;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ImgToTextClientApp
{
    internal class Client
    {
        public bool Running { get; private set; } = false;
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public delegate void ConnectionFailed();
        public event ConnectionFailed OnConnectionFailed;

        public Client()
        { 
        }

        internal void SendImg(string imgPath)
        {
            if (File.Exists(imgPath))
            {
                ConnectToServer();
                Sender.SendFile(networkStream, imgPath);
                Disconnect();
            }
        }

        internal void ConnectToServer()
        {
            try
            {
                tcpClient = new TcpClient(
                    Constants.SERVER_IP, 
                    Constants.SERVER_PORT);

                networkStream = tcpClient.GetStream();
            }
            catch (Exception)
            {
                OnConnectionFailed.Invoke();
                throw;
            }
        }

        internal void Disconnect()
        {
            tcpClient.Close();
        }
    }
}