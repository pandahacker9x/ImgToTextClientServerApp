
using Share;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ImgToTextServerApp
{
    class Server
    {
        public bool Running { get; private set; } = false;
        private IPEndPoint serverEP;
        private TcpListener serverListener;

        public Server()
        {
            serverEP = new IPEndPoint(
                IPAddress.Parse(Constants.SERVER_IP), Constants.SERVER_PORT);
            serverListener = new TcpListener(serverEP);
        }

        internal void Start()
        {
            Running = true;
            serverListener.Start();

            ThreadPool.QueueUserWorkItem(
                AcceptMultipleClients, null);
        }

        private void AcceptMultipleClients(object obj)
        {
            while (Running)
            {
                TcpClient client = serverListener.AcceptTcpClient();
                Debug.WriteLine("Connected with a client");
                ThreadPool.QueueUserWorkItem(
                    HandleRequestsAsync, client);
            }
        }

        private void HandleRequestsAsync(object client)
        {
            string imgPath = ReceiveImg(
                ((TcpClient)client).GetStream());
        }


        private string ReceiveImg(NetworkStream networkStream)
        {
            var imgPath = FileHelper.CreateRandomFileName(Constants.SERVER_FOLDER_PATH_TO_SAVE);
            FileHelper.ReceiveFile(networkStream, imgPath);
            return imgPath;
        }

        internal void Stop()
        {
            Running = false;
        }
    }
}
