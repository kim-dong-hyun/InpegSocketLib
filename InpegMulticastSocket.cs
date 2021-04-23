using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace InpegSocketLib
{
    public class InpegMulticastSocket : InpegSocket
    {
        protected bool isRunning = false;

        protected byte[] recvBuffer = new byte[1024 * 1024];

        public ClientReceiveHandlerCallback ReceiveHandler = null;

        public bool IsOpened
        {
            get
            {
                try
                {
                    if (socket != null && socket.IsBound) return true;
                    return false;
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                    return false;
                }
            }
        }

        public InpegMulticastSocket()
        {
        }

        public bool CreateSocket(string multicastIP, int port, bool exclusive)
        {
            try
            {                
                socket = CreateSocket(ProtocolType.Udp);
                socket.Blocking = false;
                socket.ExclusiveAddressUse = exclusive;

                if (!exclusive) socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);

                IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
                socket.Bind(endpoint);

                IPAddress ip = IPAddress.Parse(multicastIP);
                socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));                

                return true;
            }
            catch (Exception ex)
            {
                socket = null;
                Trace.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool StartRecv()
        {
            if (!IsOpened || isRunning) return false;

            task.RegisterSocketHandler(socket, IncomingPacketHandler, null);
            task.StartEventLoop();

            isRunning = true;

            return true;
        }

        public void StopRecv()
        {
            if (!isRunning) return;

            task.StopEventLoop();
            isRunning = false;
        }

        private void IncomingPacketHandler(object data)
        {
            try
            {
                EndPoint remote = new IPEndPoint(IPAddress.Any, 0);
                int ret = socket.ReceiveFrom(recvBuffer, 0, recvBuffer.Length, SocketFlags.None, ref remote);

                ReceiveHandler?.Invoke(socket, recvBuffer, ret, (IPEndPoint)remote);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        public int Send(byte[] buffer, int size, EndPoint remote)
        {
            try
            {
                if (!IsOpened) return 0;
                return socket.SendTo(buffer, size, SocketFlags.None, remote);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return 0;
            }
        }
    }
}
