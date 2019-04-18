using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InpegSocketLib;

namespace UDPTest
{
    public partial class MainForm : Form
    {
        private InpegUDPSocket sock = new InpegUDPSocket();

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

        private void WriteReceiveData(string message, byte[] buffer, int size)
        {
            Action doAction = delegate
            {
                txtReceiveData.Text += message;

                for (int i = 0; i < size; i++)
                    txtReceiveDataHex.Text += string.Format("0x{0:X2} ", buffer[i]);
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void ReceiveHandler(Socket sock, byte[] recvBuffer, int size)
        {
            string strBuffer = Encoding.UTF8.GetString(recvBuffer, 0, size);
            strBuffer += "\r\n";
            WriteReceiveData(strBuffer, recvBuffer, size);
        }

        private void BtnOpenCloseRecv_Click(object sender, EventArgs e)
        {
            if (!sock.IsOpened)
            {
                int port = int.Parse(txtRecvPort.Text.Trim());

                if (sock.CreateSocket(port))
                {
                    sock.ReceiveHandler = ReceiveHandler;
                    sock.StartRecv();

                    WriteStatusLog(string.Format("UDP 포트 {0} 열기 성공", port));
                    btnOpenCloseRecv.Text = "닫기";
                }
                else
                {
                    WriteStatusLog(string.Format("UDP 포트 {0} 열기 실패", port));
                    btnOpenCloseRecv.Text = "열기";
                }
            }
            else
            {
                sock.CloseSocket();
                sock.StopRecv();

                WriteStatusLog("UDP 포트 닫음");
                btnOpenCloseRecv.Text = "열기";
            }
        }

        private void BtnStatusClear_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void BtnReceiveDataClear_Click(object sender, EventArgs e)
        {
            txtReceiveData.Text = "";
            txtReceiveDataHex.Text = "";
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (sock.IsOpened)
            {
                string message = txtSendData.Text;
                if (message.Length > 0)
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    EndPoint remote = new IPEndPoint(IPAddress.Parse(txtSendIP.Text), int.Parse(txtSendPort.Text));
                    int ret = sock.Send(buffer, buffer.Length, remote);
                }
            }
        }

        private void BtnSendHex_Click(object sender, EventArgs e)
        {
            if (sock.IsOpened)
            {
                try
                {
                    string[] strTokens = txtSendDataHex.Text.Trim().Split(' ');
                    byte[] bytes = new byte[strTokens.Length];

                    for (int i = 0; i < strTokens.Length; i++)
                    {
                        bytes[i] = (byte)Convert.ToInt32(strTokens[i], 16);
                    }

                    EndPoint remote = new IPEndPoint(IPAddress.Parse(txtSendIP.Text), int.Parse(txtSendPort.Text));
                    int ret = sock.Send(bytes, bytes.Length, remote);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sock.CloseSocket();
            sock.StopRecv();
        }
    }
}
