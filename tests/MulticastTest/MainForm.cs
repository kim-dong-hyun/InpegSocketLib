using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
        private InpegUDPSocket sendSock = new InpegUDPSocket();

        public MainForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            UpdateStyles();
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
                string text = "";
                text += string.Format("size : {0} ", size);

                for (int i = 0; i < size; i++)
                    text += string.Format("{0:X2} ", buffer[i]);
                text += "\r\n";

                txtReceiveDataHex.Text = txtReceiveDataHex.Text.Insert(0, text);

                if (txtReceiveDataHex.Text.Length > 100000) txtReceiveDataHex.Text = "";
            };

            if (this.InvokeRequired) this.BeginInvoke(doAction);
            else doAction();
        }

        private void ReceiveHandler(Socket sock, byte[] recvBuffer, int size, IPEndPoint remote)
        {
            WriteReceiveData(recvBuffer, size);

            Console.WriteLine("size : {0}", size);

            for (int i = 0; i < size; i++)
                Console.Write("{0:X2} ", recvBuffer[i]);
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
        }

        private void BtnOpenClose_Click(object sender, EventArgs e)
        {
            if (!sock.IsOpened)
            {
                try
                {
                    string ip = textRecvIP.Text.Trim();
                    int port = int.Parse(textRecvPort.Text.Trim());

                    if (sock.CreateSocket(ip, port, checkExclusive.Checked))
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
                catch (Exception ex)
                {
                    MessageBox.Show(this, string.Format("멀티캐스트 열기 실패\n{0}", ex.ToString()));
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
            if (!sendSock.IsOpened)
            {
                if (sendSock.CreateSocket(0, false))
                {
                    WriteStatusLog(string.Format("멀티캐스트 송신 열기 성공"));
                    btnOpenCloseSend.Text = "닫기";
                }
                else
                {
                    WriteStatusLog(string.Format("멀티캐스트 송신 열기 실패"));
                }
            }
            else
            {
                sock.CloseSocket();
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
            sendSock.CloseSocket();
        }

        private void BtnSendHex_Click(object sender, EventArgs e)
        {
            if (sendSock.IsOpened)
            {
                try
                {
                    string[] strTokens = txtSendDataHex.Text.Trim().Split(' ');
                    byte[] bytes = new byte[strTokens.Length];

                    for (int i = 0; i < strTokens.Length; i++)
                    {
                        bytes[i] = (byte)Convert.ToInt32(strTokens[i], 16);
                    }

                    string ip = textSendIP.Text.Trim();
                    int port = int.Parse(textSendPort.Text.Trim());

                    EndPoint remote = new IPEndPoint(IPAddress.Parse(ip), port);
                    int ret = sendSock.Send(bytes, bytes.Length, remote);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
