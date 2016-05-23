namespace BTLync
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnScan = new System.Windows.Forms.Button();
            this.lstDevices = new System.Windows.Forms.ListBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtUserAlias = new System.Windows.Forms.TextBox();
            this.txtBTMsg = new System.Windows.Forms.TextBox();
            this.txtPin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTrigCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnPostFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imgVideo = new System.Windows.Forms.PictureBox();
            this.txtCapCode = new System.Windows.Forms.TextBox();
            this.imgCapture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(20, 20);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(112, 35);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lstDevices
            // 
            this.lstDevices.FormattingEnabled = true;
            this.lstDevices.ItemHeight = 20;
            this.lstDevices.Location = new System.Drawing.Point(176, 18);
            this.lstDevices.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(194, 164);
            this.lstDevices.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Enabled = false;
            this.btnConnect.Location = new System.Drawing.Point(20, 105);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 35);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(20, 149);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(112, 35);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtUserAlias
            // 
            this.txtUserAlias.Location = new System.Drawing.Point(177, 258);
            this.txtUserAlias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserAlias.Name = "txtUserAlias";
            this.txtUserAlias.Size = new System.Drawing.Size(193, 26);
            this.txtUserAlias.TabIndex = 4;
            this.txtUserAlias.Text = "achindrab@microsoft.com";
            // 
            // txtBTMsg
            // 
            this.txtBTMsg.Location = new System.Drawing.Point(410, 18);
            this.txtBTMsg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBTMsg.Multiline = true;
            this.txtBTMsg.Name = "txtBTMsg";
            this.txtBTMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBTMsg.Size = new System.Drawing.Size(358, 575);
            this.txtBTMsg.TabIndex = 5;
            this.txtBTMsg.TextChanged += new System.EventHandler(this.txtBTMsg_TextChanged);
            // 
            // txtPin
            // 
            this.txtPin.Location = new System.Drawing.Point(176, 208);
            this.txtPin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPin.Name = "txtPin";
            this.txtPin.Size = new System.Drawing.Size(194, 26);
            this.txtPin.TabIndex = 6;
            this.txtPin.Text = "1234";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 212);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "BT Device PIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 258);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Lync Call To";
            // 
            // txtTrigCode
            // 
            this.txtTrigCode.Location = new System.Drawing.Point(176, 300);
            this.txtTrigCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTrigCode.Name = "txtTrigCode";
            this.txtTrigCode.Size = new System.Drawing.Size(80, 26);
            this.txtTrigCode.TabIndex = 9;
            this.txtTrigCode.Text = "VideoCall";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 300);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Don\'t Bother";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(12, 520);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(358, 26);
            this.txtFileName.TabIndex = 11;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnPostFile
            // 
            this.btnPostFile.Location = new System.Drawing.Point(260, 560);
            this.btnPostFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPostFile.Name = "btnPostFile";
            this.btnPostFile.Size = new System.Drawing.Size(112, 35);
            this.btnPostFile.TabIndex = 12;
            this.btnPostFile.Text = "Post";
            this.btnPostFile.UseVisualStyleBackColor = true;
            this.btnPostFile.Click += new System.EventHandler(this.btnPostFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // imgVideo
            // 
            this.imgVideo.Location = new System.Drawing.Point(778, 18);
            this.imgVideo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgVideo.Name = "imgVideo";
            this.imgVideo.Size = new System.Drawing.Size(388, 283);
            this.imgVideo.TabIndex = 14;
            this.imgVideo.TabStop = false;
            this.imgVideo.Click += new System.EventHandler(this.imgVideo_Click);
            // 
            // txtCapCode
            // 
            this.txtCapCode.Location = new System.Drawing.Point(268, 300);
            this.txtCapCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCapCode.Name = "txtCapCode";
            this.txtCapCode.Size = new System.Drawing.Size(102, 26);
            this.txtCapCode.TabIndex = 15;
            this.txtCapCode.Text = "APic";
            // 
            // imgCapture
            // 
            this.imgCapture.Location = new System.Drawing.Point(778, 312);
            this.imgCapture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.imgCapture.Name = "imgCapture";
            this.imgCapture.Size = new System.Drawing.Size(388, 283);
            this.imgCapture.TabIndex = 16;
            this.imgCapture.TabStop = false;
            this.imgCapture.Click += new System.EventHandler(this.imgCapture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 708);
            this.Controls.Add(this.imgCapture);
            this.Controls.Add(this.txtCapCode);
            this.Controls.Add(this.imgVideo);
            this.Controls.Add(this.btnPostFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTrigCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPin);
            this.Controls.Add(this.txtBTMsg);
            this.Controls.Add(this.txtUserAlias);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lstDevices);
            this.Controls.Add(this.btnScan);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SecureCam";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCapture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListBox lstDevices;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtUserAlias;
        private System.Windows.Forms.TextBox txtBTMsg;
        private System.Windows.Forms.TextBox txtPin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTrigCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnPostFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox imgVideo;
        private System.Windows.Forms.TextBox txtCapCode;
        private System.Windows.Forms.PictureBox imgCapture;
    }
}

