namespace ServerWinFormTest
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStatusClear = new System.Windows.Forms.Button();
            this.listBoxStatus = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReceiveDataClear = new System.Windows.Forms.Button();
            this.txtReceiveData = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "서버포트";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(71, 6);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(58, 21);
            this.txtServerPort.TabIndex = 1;
            this.txtServerPort.Text = "8010";
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Location = new System.Drawing.Point(154, 6);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btnOpenClose.TabIndex = 2;
            this.btnOpenClose.Text = "시작";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "상태정보";
            // 
            // btnStatusClear
            // 
            this.btnStatusClear.Location = new System.Drawing.Point(397, 47);
            this.btnStatusClear.Name = "btnStatusClear";
            this.btnStatusClear.Size = new System.Drawing.Size(75, 23);
            this.btnStatusClear.TabIndex = 4;
            this.btnStatusClear.Text = "Clear";
            this.btnStatusClear.UseVisualStyleBackColor = true;
            this.btnStatusClear.Click += new System.EventHandler(this.btnStatusClear_Click);
            // 
            // listBoxStatus
            // 
            this.listBoxStatus.FormattingEnabled = true;
            this.listBoxStatus.ItemHeight = 12;
            this.listBoxStatus.Location = new System.Drawing.Point(16, 82);
            this.listBoxStatus.Name = "listBoxStatus";
            this.listBoxStatus.Size = new System.Drawing.Size(456, 196);
            this.listBoxStatus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 310);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "수신데이터";
            // 
            // btnReceiveDataClear
            // 
            this.btnReceiveDataClear.Location = new System.Drawing.Point(397, 305);
            this.btnReceiveDataClear.Name = "btnReceiveDataClear";
            this.btnReceiveDataClear.Size = new System.Drawing.Size(75, 23);
            this.btnReceiveDataClear.TabIndex = 7;
            this.btnReceiveDataClear.Text = "Clear";
            this.btnReceiveDataClear.UseVisualStyleBackColor = true;
            this.btnReceiveDataClear.Click += new System.EventHandler(this.btnReceiveDataClear_Click);
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.Location = new System.Drawing.Point(18, 335);
            this.txtReceiveData.Multiline = true;
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.Size = new System.Drawing.Size(454, 214);
            this.txtReceiveData.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.txtReceiveData);
            this.Controls.Add(this.btnReceiveDataClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxStatus);
            this.Controls.Add(this.btnStatusClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenClose);
            this.Controls.Add(this.txtServerPort);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "서버 테스트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStatusClear;
        private System.Windows.Forms.ListBox listBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReceiveDataClear;
        private System.Windows.Forms.TextBox txtReceiveData;
    }
}

