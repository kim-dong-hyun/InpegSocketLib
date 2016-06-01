using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Collections;

namespace InpegSocketLib
{
    public abstract class InpegSocket
    {
        protected InpegSocket()
        {
        }

        protected Socket CreateSocket(ProtocolType type)
        {
            Socket sock = null;

            if (type == ProtocolType.Tcp)
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            else if (type == ProtocolType.Udp)
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            return sock;
        }

        protected ArrayList BlockUntilReadable(Socket sock, int timeout)
        {
            try
            {
                ArrayList selectList = new ArrayList();
                selectList.Add(sock);

                Socket.Select(selectList, null, null, timeout);

                return selectList;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return null;
            }
        }

        protected int ReadSocket(Socket sock, byte[] recvBuffer, int offset, int size, EndPoint from, int timeout)
        {
            int bytesRead = -1;

            try
            {
                ArrayList readableList = BlockUntilReadable(sock, timeout);
                if (readableList != null)
                {
                    bytesRead = sock.ReceiveFrom(recvBuffer, offset, size, SocketFlags.None, ref from);
                }

                return bytesRead;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
                return bytesRead;
            }
        }

        protected int ReadSocketExact(Socket sock, byte[] recvBuffer, int size, EndPoint from, int timeout)
        {
            int bsize = size;
            int bytesRead = 0;
            int totalBytesRead = 0;

            do
            {
                bytesRead = ReadSocket(sock, recvBuffer, totalBytesRead, bsize, from, timeout);
                if (bytesRead <= 0) break;
                totalBytesRead += bytesRead;
                bsize -= bytesRead;
            } while (bsize != 0);

            return totalBytesRead;
        }

        protected int WriteSocket(Socket sock, byte[] buffer, int size)
        {
            return sock.Send(buffer, 0, size, SocketFlags.None);
        }
    }
}
