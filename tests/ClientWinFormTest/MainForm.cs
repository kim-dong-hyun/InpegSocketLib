using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

using InpegSocketLib;

namespace ClientWinFormTest
{
    public partial class MainForm : Form
    {
        private InpegClientSocket client = new InpegClientSocket();

        public MainForm()
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

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void WriteReceiveData(string message)
        {
            Action doAction = delegate
            {
                txtReceiveData.Text += message;
                
                byte[] bytes = Encoding.ASCII.GetBytes(message);
                for (int i = 0; i < bytes.Length; i++)
                    txtReceiveDataHex.Text += string.Format("0x{0:X2} ", bytes[i]);
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void ReceiveHandler(Socket sock, byte[] recvBuffer, int size)
        {
            string strBuffer = Encoding.UTF8.GetString(recvBuffer, 0, size);
            strBuffer += "\r\n";
            WriteReceiveData(strBuffer);
        }

        private void DisconnectHandler(Socket sock)
        {
            WriteStatusLog("서버와의 연결이 끊어졌습니다");

            Action doAction = delegate
            {
                btnOpenClose.Text = "연결";
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
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
                        btnOpenClose.Text = "종료";
                    }
                    else
                    {
                        WriteStatusLog("서버 접속에 실패했습니다");
                    }
                };
                this.BeginInvoke(doAction);
            }
            else
            {
                client.Disconnect();
                WriteStatusLog("서버 접속을 종료하였습니다");
                btnOpenClose.Text = "연결";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
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

        private void btnSendHex_Click(object sender, EventArgs e)
        {
            if (client.IsConnected)
            {
                try
                {
                    string[] strTokens = txtSendDataHex.Text.Trim().Split(' ');
                    byte[] bytes = new byte[strTokens.Length];
                    
                    for (int i = 0; i < strTokens.Length; i++)
                    {
                        bytes[i] = (byte)Convert.ToInt32(strTokens[i], 16);
                    }

                    int ret = client.Send(bytes, bytes.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void btnStatusClear_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void btnReceiveDataClear_Click(object sender, EventArgs e)
        {
            txtReceiveData.Text = "";
            txtReceiveDataHex.Text = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }
    }
}
