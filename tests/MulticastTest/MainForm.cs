using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using InpegSocketLib;

namespace MulticastTest
{
    public partial class MainForm : Form
    {
        private InpegMulticastSocket sock = new InpegMulticastSocket();

        private long receiveCount = 0;

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

        private void WriteReceiveData(byte[] buffer, int size)
        {
            Action doAction = delegate
            {
                txtReceiveDataHex.Text += string.Format("size : {0} ", size);
                if (size > 20) size = 20;

                for (int i = 0; i < size; i++)
                    txtReceiveDataHex.Text += string.Format("{0:X2} ", buffer[i]);
                txtReceiveDataHex.Text += "\r\n";

                Interlocked.Decrement(ref receiveCount);
            };

            if (Interlocked.Read(ref receiveCount) == 0)
            {
                Interlocked.Increment(ref receiveCount);
                if (this.InvokeRequired) this.BeginInvoke(doAction);
                else doAction();
            }
        }

        private void ReceiveHandler(Socket sock, byte[] recvBuffer, int size)
        {
            WriteReceiveData(recvBuffer, size);

            Console.WriteLine("size : {0}", size);
            if (size > 100) size = 100;
            for (int i = 0; i < size; i++)
                Console.Write("{0:X2} ", recvBuffer[i]);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
        }

        private void BtnOpenClose_Click(object sender, EventArgs e)
        {
            if (!sock.IsOpened)
            {
                string ip = textRecvIP.Text.Trim();
                int port = int.Parse(textRecvPort.Text.Trim());

                if (sock.CreateSocket(ip, port))
                {
                    sock.ReceiveHandler = ReceiveHandler;
                    sock.StartRecv();

                    WriteStatusLog(string.Format("멀티캐스트 수신 {0}:{1} 열기 성공", ip, port));
                    btnOpenClose.Text = "닫기";
                }
                else
                {
                    WriteStatusLog(string.Format("멀티캐스트 수신 {0}:{1} 열기 실패", ip, port));
                    btnOpenClose.Text = "열기";
                }
            }
            else
            {
                sock.StopRecv();
                sock.CloseSocket();

                WriteStatusLog("멀티캐스트 수신 닫음");
                btnOpenClose.Text = "열기";
            }
        }

        private void BtnOpenCloseSend_Click(object sender, EventArgs e)
        {
            if (!sock.IsSendOpened)
            {
                string ip = textSendIP.Text.Trim();
                int port = int.Parse(textSendPort.Text.Trim());

                if (sock.CreateSendSocket(ip, port))
                {
                    WriteStatusLog(string.Format("멀티캐스트 송신 {0}:{1} 열기 성공", ip, port));
                    btnOpenCloseSend.Text = "닫기";
                }
                else
                {
                    WriteStatusLog(string.Format("멀티캐스트 송신 {0}:{1} 열기 실패", ip, port));
                }
            }
            else
            {
                sock.CloseSendSocket();
                WriteStatusLog("멀티캐스트 송신 닫음");
                btnOpenCloseSend.Text = "열기";
            }
        }

        private void BtnStatusClear_Click(object sender, EventArgs e)
        {
            listBoxStatus.Items.Clear();
        }

        private void BtnReceiveDataClear_Click(object sender, EventArgs e)
        {
            txtReceiveDataHex.Text = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sock.StopRecv();
            sock.CloseSocket();
            sock.CloseSendSocket();
        }

        private void BtnSendHex_Click(object sender, EventArgs e)
        {
            if (sock.IsSendOpened)
            {
                try
                {
                    string[] strTokens = txtSendDataHex.Text.Trim().Split(' ');
                    byte[] bytes = new byte[strTokens.Length];

                    for (int i = 0; i < strTokens.Length; i++)
                    {
                        bytes[i] = (byte)Convert.ToInt32(strTokens[i], 16);
                    }

                    int ret = sock.Send(bytes, bytes.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
