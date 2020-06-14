﻿using Share;
using System;
using System.Diagnostics;
using System.IO;
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
                try
                {
                    AcceptClient();
                }
                catch (SocketException sckEx)
                {
                    if (Running) Stop();
                    Debug.WriteLine("SocketException " + sckEx.Message);
                }

            }
        }

        private void AcceptClient()
        {
            TcpClient client = serverListener.AcceptTcpClient();
            Debug.WriteLine("Connected with a client");
            ThreadPool.QueueUserWorkItem(
                HandleRequestsAsync, client);
        }

        private void HandleRequestsAsync(object client)
        {
            if (Running)
            {
                var networkStream = ((TcpClient)client).GetStream();
                string imgPath = ReceiveImg(networkStream);

                string text = Utils.ImgToText(imgPath);
                Sender.SendString(networkStream, text);
            }
        }

        private string ReceiveImg(NetworkStream networkStream)
        {
            var imgFileExtention = Receiver.ReceiveString(networkStream, Constants.EXTENSION_FILE_BYTE_SIZE);
            var pathToSave = Utils.GenerateUniqueFilePath(
                Constants.SERVER_FOLDER_PATH_TO_SAVE, imgFileExtention);
            Receiver.ReceiveFileContent(networkStream, pathToSave);
            return pathToSave;
        }

        internal void Stop()
        {
            Running = false;
            serverListener.Stop();
        }
    }
}
