namespace MulticastTest
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
            this.txtReceiveDataHex = new System.Windows.Forms.TextBox();
            this.btnReceiveDataClear = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStatusClear = new System.Windows.Forms.Button();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkExclusive = new System.Windows.Forms.CheckBox();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.textRecvPort = new System.Windows.Forms.TextBox();
            this.textRecvIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSendHex = new System.Windows.Forms.Button();
            this.txtSendDataHex = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOpenCloseSend = new System.Windows.Forms.Button();
            this.textSendPort = new System.Windows.Forms.TextBox();
            this.textSendIP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReceiveDataHex
            // 
            this.txtReceiveDataHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReceiveDataHex.Location = new System.Drawing.Point(0, 28);
            this.txtReceiveDataHex.Multiline = true;
            this.txtReceiveDataHex.Name = "txtReceiveDataHex";
            this.txtReceiveDataHex.ReadOnly = true;
            this.txtReceiveDataHex.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReceiveDataHex.Size = new System.Drawing.Size(492, 162);
            this.txtReceiveDataHex.TabIndex = 24;
            // 
            // btnReceiveDataClear
            // 
            this.btnReceiveDataClear.Location = new System.Drawing.Point(405, 2);
            this.btnReceiveDataClear.Name = "btnReceiveDataClear";
            this.btnReceiveDataClear.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveDataClear.TabIndex = 23;
            this.btnReceiveDataClear.Text = "Clear";
            this.btnReceiveDataClear.UseVisualStyleBackColor = true;
            this.btnReceiveDataClear.Click += new System.EventHandler(this.BtnReceiveDataClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "수신데이터";
            // 
            // btnStatusClear
            // 
            this.btnStatusClear.Location = new System.Drawing.Point(397, 6);
            this.btnStatusClear.Name = "btnStatusClear";
            this.btnStatusClear.Size = new System.Drawing.Size(75, 23);
            this.btnStatusClear.TabIndex = 21;
            this.btnStatusClear.Text = "Clear";
            this.btnStatusClear.UseVisualStyleBackColor = true;
            this.btnStatusClear.Click += new System.EventHandler(this.BtnStatusClear_Click);
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 12;
            this.listBoxStatus.Location = new System.Drawing.Point(3, 35);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(477, 136);
            this.listBoxStatus.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "상태정보";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkExclusive);
            this.groupBox1.Controls.Add(this.btnOpenClose);
            this.groupBox1.Controls.Add(this.textRecvPort);
            this.groupBox1.Controls.Add(this.textRecvIP);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 92);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "멀티캐스트 수신";
            // 
            // checkExclusive
            // 
            this.checkExclusive.AutoSize = true;
            this.checkExclusive.Checked = true;
            this.checkExclusive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkExclusive.Location = new System.Drawing.Point(281, 20);
            this.checkExclusive.Name = "checkExclusive";
            this.checkExclusive.Size = new System.Drawing.Size(78, 16);
            this.checkExclusive.TabIndex = 10;
            this.checkExclusive.Text = "exclusive";
            this.checkExclusive.UseVisualStyleBackColor = true;
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(384, 15);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btnOpenClose.TabIndex = 9;
            this.btnOpenClose.Text = "열기";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.BtnOpenClose_Click);
            // 
            // textRecvPort
            // 
            this.textRecvPort.Location = new System.Drawing.Point(164, 47);
            this.textRecvPort.Name = "textRecvPort";
            this.textRecvPort.Size = new System.Drawing.Size(111, 21);
            this.textRecvPort.TabIndex = 8;
            // 
            // textRecvIP
            // 
            this.textRecvIP.Location = new System.Drawing.Point(164, 20);
            this.textRecvIP.Name = "textRecvIP";
            this.textRecvIP.Size = new System.Drawing.Size(111, 21);
            this.textRecvIP.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "멀티캐스트 수신 포트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "멀티캐스트 수신 IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSendHex);
            this.groupBox2.Controls.Add(this.txtSendDataHex);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnOpenCloseSend);
            this.groupBox2.Controls.Add(this.textSendPort);
            this.groupBox2.Controls.Add(this.textSendIP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(3, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 128);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "멀티캐스트 송신";
            // 
            // btnSendHex
            // 
            this.btnSendHex.Location = new System.Drawing.Point(384, 88);
            this.btnSendHex.Name = "btnSendHex";
            this.btnSendHex.Size = new System.Drawing.Size(75, 23);
            this.btnSendHex.TabIndex = 40;
            this.btnSendHex.Text = "전송";
            this.btnSendHex.UseVisualStyleBackColor = true;
            this.btnSendHex.Click += new System.EventHandler(this.BtnSendHex_Click);
            // 
            // txtSendDataHex
            // 
            this.txtSendDataHex.Location = new System.Drawing.Point(76, 88);
            this.txtSendDataHex.Name = "txtSendDataHex";
            this.txtSendDataHex.Size = new System.Drawing.Size(292, 21);
            this.txtSendDataHex.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "전송 HEX";
            // 
            // btnOpenCloseSend
            // 
            this.btnOpenCloseSend.Location = new System.Drawing.Point(384, 20);
            this.btnOpenCloseSend.Name = "btnOpenCloseSend";
            this.btnOpenCloseSend.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCloseSend.TabIndex = 37;
            this.btnOpenCloseSend.Text = "열기";
            this.btnOpenCloseSend.UseVisualStyleBackColor = true;
            this.btnOpenCloseSend.Click += new System.EventHandler(this.BtnOpenCloseSend_Click);
            // 
            // textSendPort
            // 
            this.textSendPort.Location = new System.Drawing.Point(157, 59);
            this.textSendPort.Name = "textSendPort";
            this.textSendPort.Size = new System.Drawing.Size(111, 21);
            this.textSendPort.TabIndex = 36;
            // 
            // textSendIP
            // 
            this.textSendIP.Location = new System.Drawing.Point(157, 26);
            this.textSendIP.Name = "textSendIP";
            this.textSendIP.Size = new System.Drawing.Size(111, 21);
            this.textSendIP.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "멀티캐스트 송신 포트";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "멀티캐스트 송신 IP";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 239);
            this.panel1.TabIndex = 35;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.listBoxStatus);
            this.panel2.Controls.Add(this.btnStatusClear);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 239);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 182);
            this.panel2.TabIndex = 36;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtReceiveDataHex);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 421);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(492, 190);
            this.panel3.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnReceiveDataClear);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(492, 28);
            this.panel4.TabIndex = 25;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 611);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "멀티캐스트 테스트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtReceiveDataHex;
        private System.Windows.Forms.Button btnReceiveDataClear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStatusClear;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.TextBox textRecvPort;
        private System.Windows.Forms.TextBox textRecvIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSendHex;
        private System.Windows.Forms.TextBox txtSendDataHex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOpenCloseSend;
        private System.Windows.Forms.TextBox textSendPort;
        private System.Windows.Forms.TextBox textSendIP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkExclusive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

