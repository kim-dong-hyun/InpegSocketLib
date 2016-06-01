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
using System.Net.Sockets;
using System.Net;

using InpegSocketLib;

namespace ClientTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private InpegClientSocket client = new InpegClientSocket();

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

        private void ReceiveHandler(Socket sock, byte[] recvBuffer, int size)
        {
            string strBuffer = Encoding.UTF8.GetString(recvBuffer, 0, size);
            strBuffer += "\n";
            WriteReceiveData(strBuffer);
        }

        private void DisconnectHandler(Socket sock)
        {
            WriteStatusLog("서버와의 연결이 끊어졌습니다");
            
            Action doAction = delegate
            {
                btnOpenClose.Content = "연결";
            };

            if (this.Dispatcher.Thread == System.Threading.Thread.CurrentThread)
                doAction();
            else
                this.Dispatcher.BeginInvoke(doAction);
        }

        private void btnOpenClose_Click(object sender, RoutedEventArgs e)
        {
            if (!client.IsConnected)
            {
                client.ReceiveHandler = ReceiveHandler;
                client.DisconnectHandler = DisconnectHandler;

                WriteStatusLog("서버에 접속중...");

                Action doAction = delegate
                {
                    if (client.Connect(IPAddress.Parse(txtServerIP.Text), int.Parse(txtServerPort.Text), 3000))
                    {
                        WriteStatusLog("서버에 접속했습니다");
                        btnOpenClose.Content = "종료";
                    }
                    else
                    {
                        WriteStatusLog("서버 접속에 실패했습니다");
                    }
                };
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, doAction);
            }
            else
            {
                client.Disconnect();
                WriteStatusLog("서버 접속을 종료하였습니다");
                btnOpenClose.Content = "연결";
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (client.IsConnected)
            {
                string message = txtSendData.Text;
                if (message.Length > 0)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    int ret = client.Send(buffer, buffer.Length);
                }
            }
        }

        private void btnStatusClear_Click(object sender, RoutedEventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void btnReceiveDataClear_Click(object sender, RoutedEventArgs e)
        {
            txtReceiveData.Text = "";
        }

        private void winMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Disconnect();
        }
    }
}
