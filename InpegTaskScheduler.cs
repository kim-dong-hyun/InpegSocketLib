using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;

namespace InpegSocketLib
{
    public delegate void SocketReadHandlerCallback(Object data);

    public class SocketHandler
    {
        public Socket sock;
        public SocketReadHandlerCallback handler;
        public object data;
    }

    public class InpegTaskScheduler
    {
        protected Dictionary<Socket, SocketHandler> sockHandlerTable = new Dictionary<Socket, SocketHandler>();
        protected bool isRunning = false;
        protected Thread thread;
        protected int TIMEOUT = 10000;

        public InpegTaskScheduler()
        {
        }

        public void RegisterSocketHandler(Socket sock, SocketReadHandlerCallback handler, object data)
        {
            lock (sockHandlerTable)
            {
                if (sock != null)
                {
                    SocketHandler sockHandler = new SocketHandler();
                    sockHandler.sock = sock;
                    sockHandler.handler = handler;
                    sockHandler.data = data;
                    sockHandlerTable.Add(sockHandler.sock, sockHandler);
                }
            }
        }

        public void UnregisterSocketHandler(Socket sock)
        {
            lock (sockHandlerTable)
            {
                if (sock != null && sockHandlerTable.ContainsKey(sock))
                {
                    sockHandlerTable.Remove(sock);
                }
            }
        }

        protected void SingleStep()
        {
            lock (sockHandlerTable)
            {
                try
                {
                    ArrayList selectList = new ArrayList();
                    foreach (var handler in sockHandlerTable)
                    {
                        selectList.Add(handler.Key);
                    }

                    if (selectList.Count == 0)
                    {
                        Thread.Sleep(10);
                        return;
                    }

                    Socket.Select(selectList, null, null, TIMEOUT);

                    foreach (Socket sock in selectList)
                    {
                        var handler = sockHandlerTable[sock];
                        if (handler != null && handler.handler != null) handler.handler(handler.data);
                    }                    
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

        protected void DoEventLoop()
        {
            while (isRunning == true)
            {
                SingleStep();
            }
        }

        public void StartEventLoop()
        {
            if (isRunning == true) return;

            thread = new Thread(new ThreadStart(DoEventLoop));
            thread.IsBackground = true;
            isRunning = true;
            thread.Start();
        }

        public void StopEventLoop()
        {
            isRunning = false;
            if (thread != null)
            {
                if (Thread.CurrentThread != thread)
                {
                    thread.Join();
                    thread = null;
                }
            }
            sockHandlerTable.Clear();
        }
    }
}
