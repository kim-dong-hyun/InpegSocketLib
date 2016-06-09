using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

using InpegSocketLib;

namespace ServerTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private InpegServerSocket server = new InpegServerSocket();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void WriteStatusLog(string message)
        {
            Action doAction = delegate
            {
                listBoxStatus.Items.Insert(0, message);
                listBoxStatus.SelectedIndex = 0;
            };

            if (this.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                doAction();
            else
                this.Dispatcher.BeginInvoke(doAction);
        }

        private void WriteReceiveData(string message)
        {
            Action doAction = delegate
            {
                txtReceiveData.Text += message;
            };

            if (this.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                doAction();
            else
                this.Dispatcher.BeginInvoke(doAction);
        }

        private bool StartServer(int port)
        {
            if (!server.IsRunning)
            {
                server.ClientConnectHandler = ClientConnectHandler;
                server.ClientDisconnectHandler = ClientDisconnectHandler;
                server.ReceiveHandler = ClientReceiveHandler;
                return server.StartServer(port);
            }
            return false;
        }

        private void ClientConnectHandler(InpegClientSession client)
        {
            IPEndPoint clientAddress = (IPEndPoint)client.clientSock.RemoteEndPoint;
            WriteStatusLog(string.Format("클라이언트 {0}:{1} 접속되었습니다", clientAddress.Address.ToString(), clientAddress.Port));
        }

        private void ClientDisconnectHandler(InpegClientSession client)
        {
            IPEndPoint clientAddress = (IPEndPoint)client.clientSock.RemoteEndPoint;
            WriteStatusLog(string.Format("클라이언트 {0}:{1} 접속이 끊어졌습니다", clientAddress.Address.ToString(), clientAddress.Port));
        }

        private void ClientReceiveHandler(InpegClientSession client, byte[] recvBuffer, int size)
        {
            string strBuffer = Encoding.UTF8.GetString(recvBuffer, 0, size);
            client.Send(recvBuffer, size);
            strBuffer += "\n";
            WriteReceiveData(strBuffer);
        }

        private void btnOpenClose_Click(object sender, RoutedEventArgs e)
        {
            if (!server.IsRunning)
            {
                int port = 8080;
                try
                {
                    port = int.Parse(txtServerPort.Text);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    WriteStatusLog("잘못된 포트번호 입니다");
                    return;
                }

                if (StartServer(port))
                {
                    WriteStatusLog(string.Format("서버 {0} 를 시작했습니다", port));
                    btnOpenClose.Content = "종료";
                }
                else
                {
                    WriteStatusLog("서버 시작에 실패했습니다");
                    btnOpenClose.Content = "시작";
                }
            }
            else
            {
                WriteStatusLog("서버를 종료중입니다...");
                server.StopServer();
                WriteStatusLog("서버를 종료하였습니다");
                btnOpenClose.Content = "시작";
            }
        }

        private void winMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            server.StopServer();
        }

        private void btnStatusClear_Click(object sender, RoutedEventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void btnReceiveDataClear_Click(object sender, RoutedEventArgs e)
        {
            txtReceiveData.Text = "";
        }
    }
}
