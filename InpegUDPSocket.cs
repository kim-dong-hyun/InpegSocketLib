using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace InpegSocketLib
{
    public class InpegUDPSocket : InpegSocket
    {
        protected bool isRunning = false;

        protected byte[] recvBuffer = new byte[1024 * 1024];

        public event ClientReceiveHandlerCallback ReceiveHandler = null;

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

        public bool IsRunning {  get { return isRunning; } }

        public InpegUDPSocket()
        {
        }

        public bool CreateSocket(int port, bool exclusive)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);
                socket = CreateSocket(ProtocolType.Udp);

                if (!exclusive) socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
#if true
                uint IOC_IN = 0x80000000;
                uint IOC_VENDOR = 0x18000000;
                uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
                socket.IOControl((int)SIO_UDP_CONNRESET, new byte[] { Convert.ToByte(false) }, null);
#endif
                socket.Blocking = false;
                socket.Bind(endPoint);                

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

                ReceiveHandler?.Invoke(socket, (IPEndPoint)remote, recvBuffer, ret);
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
