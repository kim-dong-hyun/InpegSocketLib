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
        protected List<SocketHandler> sockList = new List<SocketHandler>();
        protected bool isRunning = false;
        protected Thread thread;
        protected int TIMEOUT = 1000;

        public InpegTaskScheduler()
        {
        }

        public void RegisterSocketHandler(Socket sock, SocketReadHandlerCallback handler, object data)
        {
            lock (this)
            {
                SocketHandler sockHandler = new SocketHandler();
                sockHandler.sock = sock;
                sockHandler.handler = handler;
                sockHandler.data = data;
                sockList.Add(sockHandler);
            }
        }

        public void UnregisterSocketHandler(Socket sock)
        {
            lock (this)
            {
                foreach (SocketHandler handler in sockList)
                {
                    if (handler.sock == sock)
                    {
                        sockList.Remove(handler);
                        break;
                    }
                }
            }
        }

        protected void SingleStep()
        {
            lock (this)
            {
                try
                {
                    ArrayList selectList = new ArrayList();
                    foreach (SocketHandler handler in sockList)
                    {
                        selectList.Add(handler.sock);
                    }

                    if (selectList.Count == 0)
                    {
                        Thread.Sleep(10);
                        return;
                    }

                    Socket.Select(selectList, null, null, TIMEOUT);

                    foreach (Socket sock in selectList)
                    {
                        foreach (SocketHandler handler in sockList)
                        {
                            if (handler.sock == sock)
                            {
                                handler.handler(handler.data);
                                break;
                            }
                        }
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
            sockList.Clear();
        }
    }
}
