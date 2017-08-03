using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace InpegSocketLib
{
    public delegate void ClientConnectHandlerCallback(Socket sock);
    public delegate void ClientReceiveHandlerCallback(Socket sock, byte[] recvBuffer, int size);

    public class InpegClientSocket : InpegSocket
    {
        protected Socket clientSock;
        protected InpegTaskScheduler task = new InpegTaskScheduler();
        public bool IsConnected
        {
            get
            {
                try
                {
                    if (clientSock == null) return false;
                    return clientSock.Connected;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return false;
                }
            }
        }
        protected byte[] recvBuffer = new byte[1024 * 1024];

        public ClientReceiveHandlerCallback ReceiveHandler = null;
        public ClientConnectHandlerCallback DisconnectHandler = null;

        public InpegClientSocket()
        {
        }

        public bool Connect(string serverIP, int serverPort, int timeout)
        {
            try
            {
                IPAddress ipAddress;
                if (IPAddress.TryParse(serverIP, out ipAddress))
                {
                    return Connect(ipAddress, serverPort, timeout);
                }
                else
                {
                    IPHostEntry hostEntry = Dns.GetHostEntry(serverIP);

                    if (hostEntry.AddressList.Length > 0)
                    {
                        foreach (var address in hostEntry.AddressList)
                        {
                            if (Connect(address, serverPort, timeout)) return true;
                        }
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return true;
        }

        public bool Connect(IPAddress serverIP, int serverPort, int timeout)
        {
            if (IsConnected == true) return false;

            if (clientSock != null)
            {
                task.UnregisterSocketHandler(clientSock);
                CloseSocket();
            }

            clientSock = CreateSocket(ProtocolType.Tcp);
            clientSock.Blocking = false;
            clientSock.NoDelay = true;

            try
            {
                clientSock.Connect(serverIP, serverPort);

                task.RegisterSocketHandler(clientSock, IncomingPacketHandler, null);
                task.StartEventLoop();

                return true;
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.WouldBlock)
                {
                    ArrayList selectArray = new ArrayList();
                    selectArray.Add(clientSock);

                    Socket.Select(null, selectArray, null, timeout * 1000);

                    if (selectArray.Count == 0)
                        goto connect_fail;

                    task.RegisterSocketHandler(clientSock, IncomingPacketHandler, null);
                    task.StartEventLoop();
                    return true;
                }

            connect_fail:
                CloseSocket();
                Trace.WriteLine(ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                CloseSocket();
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }

        protected void CloseSocket()
        {
            if (clientSock != null)
            {
                clientSock.Close();
                clientSock = null;
            }
        }

        public void Disconnect()
        {
            task.UnregisterSocketHandler(clientSock);
            CloseSocket();
            task.StopEventLoop();
        }

        private void IncomingPacketHandler(object data)
        {
            try
            {
                int ret = clientSock.Receive(recvBuffer, 0, recvBuffer.Length, SocketFlags.None);
                if (ret <= 0)
                {
                    task.UnregisterSocketHandler(clientSock);                    

                    if (DisconnectHandler != null)
                        DisconnectHandler(clientSock);

                    CloseSocket();

                    task.StopEventLoop();
                }
                else
                {
                    if (ReceiveHandler != null)
                        ReceiveHandler(clientSock, recvBuffer, ret);
                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine("[SocketException] " + ex.ToString());

                if (ex.SocketErrorCode == SocketError.ConnectionAborted || ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    task.UnregisterSocketHandler(clientSock);                    

                    if (DisconnectHandler != null)
                        DisconnectHandler(clientSock);

                    CloseSocket();

                    task.StopEventLoop();
                }
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
                if (IsConnected == false) return 0;
                return WriteSocket(clientSock, buffer, size);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
