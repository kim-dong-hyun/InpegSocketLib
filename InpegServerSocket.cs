using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace InpegSocketLib
{
    public delegate void ServerConnectHandlerCallback(InpegClientSession client);
    public delegate void ServerReceiveHandlerCallback(InpegClientSession client, byte[] recvBuffer, int size);

    public class InpegClientSession
    {
        public Socket clientSock;
        public byte[] recvBuffer = new byte[1024 * 1024];
        public object Tag { get; set; }

        public InpegClientSession(Socket sock)
        {
            clientSock = sock;
        }

        public void IncomingPacketHandler(object data)
        {
            InpegServerSocket server = data as InpegServerSocket;

            try
            {
                int ret = clientSock.Receive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None);
                if (ret <= 0)
                {
                    server.Task.UnregisterSocketHandler(clientSock);
                    server.clientList.Remove(this);
                    if (server.ClientDisconnectHandler != null)
                        server.ClientDisconnectHandler(this);
                }
                else
                {
                    if (server.ReceiveHandler != null)
                        server.ReceiveHandler(this, recvBuffer, ret);
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.ToString());

                server.Task.UnregisterSocketHandler(clientSock);
                server.clientList.Remove(this);

                if (server.ClientDisconnectHandler != null)
                    server.ClientDisconnectHandler(this);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public int Send(byte[] buffer, int size)
        {
            try
            {
                return clientSock.Send(buffer, 0, size, SocketFlags.None);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return 0;
            }
        }
    }

    public class InpegServerSocket : InpegSocket
    {
        public InpegTaskScheduler Task { get { return task;  } }

        public List<InpegClientSession> clientList = new List<InpegClientSession>();        
        protected bool isRunning = false;
        protected const int BACKLOG = 1000;

        public ServerConnectHandlerCallback ClientConnectHandler = null;
        public ServerReceiveHandlerCallback ReceiveHandler = null;
        public ServerConnectHandlerCallback ClientDisconnectHandler = null;

        public bool IsRunning { get { return isRunning; } }

        public InpegServerSocket()
        {
        }

        public bool StartServer(int port)
        {
            try
            {
                if (isRunning == true) return false;

                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, port);
                socket = CreateSocket(ProtocolType.Tcp);
                socket.Blocking = false;
                socket.Bind(serverEndPoint);
                socket.Listen(BACKLOG);

                task.RegisterSocketHandler(socket, IncomingConnectionHandler, null);
                task.StartEventLoop();

                isRunning = true;

                return true;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }

        public void StopServer()
        {
            if (isRunning == false) return;

            task.StopEventLoop();
            CloseSocket();

            foreach (InpegClientSession client in clientList)
                client.clientSock.Close();
            clientList.Clear();

            isRunning = false;
        }

        private void IncomingConnectionHandler(object data)
        {
            Socket clientSock = socket.Accept();
            clientSock.Blocking = false;
            clientSock.NoDelay = true;

            InpegClientSession client = new InpegClientSession(clientSock);
            clientList.Add(client);
            task.RegisterSocketHandler(clientSock, client.IncomingPacketHandler, this);

            if (ClientConnectHandler != null)
                ClientConnectHandler(client);
        }

        public void DisconnectAllClient()
        {
            foreach (InpegClientSession client in clientList)
            {
                client.clientSock.Shutdown(SocketShutdown.Send);
            }
        }
    }
}
