namespace UDPTest
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSendPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSendIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpenCloseRecv = new System.Windows.Forms.Button();
            this.txtRecvPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStatusClear = new System.Windows.Forms.Button();
            this.txtReceiveDataHex = new System.Windows.Forms.TextBox();
            this.btnReceiveDataClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSendHex = new System.Windows.Forms.Button();
            this.txtSendDataHex = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSendPort
            // 
            this.txtSendPort.Location = new System.Drawing.Point(297, 50);
            this.txtSendPort.Name = "txtSendPort";
            this.txtSendPort.Size = new System.Drawing.Size(100, 21);
            this.txtSendPort.TabIndex = 8;
            this.txtSendPort.Text = "8010";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "전송 포트";
            // 
            // txtSendIP
            // 
            this.txtSendIP.Location = new System.Drawing.Point(76, 50);
            this.txtSendIP.Name = "txtSendIP";
            this.txtSendIP.Size = new System.Drawing.Size(139, 21);
            this.txtSendIP.TabIndex = 6;
            this.txtSendIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "전송 IP";
            // 
            // btnOpenCloseRecv
            // 
            this.btnOpenCloseRecv.Location = new System.Drawing.Point(203, 12);
            this.btnOpenCloseRecv.Name = "btnOpenCloseRecv";
            this.btnOpenCloseRecv.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCloseRecv.TabIndex = 12;
            this.btnOpenCloseRecv.Text = "열기";
            this.btnOpenCloseRecv.UseVisualStyleBackColor = true;
            this.btnOpenCloseRecv.Click += new System.EventHandler(this.BtnOpenCloseRecv_Click);
            // 
            // txtRecvPort
            // 
            this.txtRecvPort.Location = new System.Drawing.Point(76, 14);
            this.txtRecvPort.Name = "txtRecvPort";
            this.txtRecvPort.Size = new System.Drawing.Size(100, 21);
            this.txtRecvPort.TabIndex = 10;
            this.txtRecvPort.Text = "8010";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "수신 포트";
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 12;
            this.listBoxStatus.Location = new System.Drawing.Point(8, 183);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(469, 136);
            this.listBoxStatus.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "상태정보";
            // 
            // btnStatusClear
            // 
            this.btnStatusClear.Location = new System.Drawing.Point(402, 158);
            this.btnStatusClear.Name = "btnStatusClear";
            this.btnStatusClear.Size = new System.Drawing.Size(75, 23);
            this.btnStatusClear.TabIndex = 15;
            this.btnStatusClear.Text = "Clear";
            this.btnStatusClear.UseVisualStyleBackColor = true;
            this.btnStatusClear.Click += new System.EventHandler(this.BtnStatusClear_Click);
            // 
            // txtReceiveDataHex
            // 
            this.txtReceiveDataHex.Location = new System.Drawing.Point(8, 360);
            this.txtReceiveDataHex.Multiline = true;
            this.txtReceiveDataHex.Name = "txtReceiveDataHex";
            this.txtReceiveDataHex.Size = new System.Drawing.Size(467, 249);
            this.txtReceiveDataHex.TabIndex = 19;
            // 
            // btnReceiveDataClear
            // 
            this.btnReceiveDataClear.Location = new System.Drawing.Point(400, 331);
            this.btnReceiveDataClear.Name = "btnReceiveDataClear";
            this.btnReceiveDataClear.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveDataClear.TabIndex = 17;
            this.btnReceiveDataClear.Text = "Clear";
            this.btnReceiveDataClear.UseVisualStyleBackColor = true;
            this.btnReceiveDataClear.Click += new System.EventHandler(this.BtnReceiveDataClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "수신데이터";
            // 
            // btnSendHex
            // 
            this.btnSendHex.Location = new System.Drawing.Point(407, 120);
            this.btnSendHex.Name = "btnSendHex";
            this.btnSendHex.Size = new System.Drawing.Size(75, 23);
            this.btnSendHex.TabIndex = 25;
            this.btnSendHex.Text = "전송";
            this.btnSendHex.UseVisualStyleBackColor = true;
            this.btnSendHex.Click += new System.EventHandler(this.BtnSendHex_Click);
            // 
            // txtSendDataHex
            // 
            this.txtSendDataHex.Location = new System.Drawing.Point(76, 122);
            this.txtSendDataHex.Name = "txtSendDataHex";
            this.txtSendDataHex.Size = new System.Drawing.Size(321, 21);
            this.txtSendDataHex.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "전송 HEX";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(407, 85);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 22;
            this.btnSend.Text = "전송";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(76, 87);
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(321, 21);
            this.txtSendData.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "전송문자";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 618);
            this.Controls.Add(this.btnSendHex);
            this.Controls.Add(this.txtSendDataHex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtReceiveDataHex);
            this.Controls.Add(this.btnReceiveDataClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnStatusClear);
            this.Controls.Add(this.listBoxStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenCloseRecv);
            this.Controls.Add(this.txtRecvPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSendPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSendIP);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "UDP 테스트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSendPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSendIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenCloseRecv;
        private System.Windows.Forms.TextBox txtRecvPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStatusClear;
        private System.Windows.Forms.TextBox txtReceiveDataHex;
        private System.Windows.Forms.Button btnReceiveDataClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSendHex;
        private System.Windows.Forms.TextBox txtSendDataHex;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Label label7;
    }
}

