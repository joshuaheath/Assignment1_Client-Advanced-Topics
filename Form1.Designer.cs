namespace Assignment1_Client
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
            this.lblIP = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rtxtHistory = new System.Windows.Forms.RichTextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(13, 341);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(24, 20);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "IP";
            this.lblIP.Click += new System.EventHandler(this.lblIP_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(291, 341);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(52, 20);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "PORT";
            this.lblPort.Click += new System.EventHandler(this.lblPort_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(17, 365);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(239, 26);
            this.txtIP.TabIndex = 2;
            this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(295, 364);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(215, 26);
            this.txtPort.TabIndex = 3;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(17, 458);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(790, 26);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(13, 424);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(74, 20);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "Message";
            // 
            // rtxtHistory
            // 
            this.rtxtHistory.Location = new System.Drawing.Point(17, 532);
            this.rtxtHistory.Name = "rtxtHistory";
            this.rtxtHistory.Size = new System.Drawing.Size(944, 338);
            this.rtxtHistory.TabIndex = 6;
            this.rtxtHistory.Text = "";
            this.rtxtHistory.TextChanged += new System.EventHandler(this.rtxtHistory_TextChanged);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new System.Drawing.Point(17, 506);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(58, 20);
            this.lblHistory.TabIndex = 7;
            this.lblHistory.Text = "History";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(830, 458);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(109, 34);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(530, 364);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(119, 36);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 882);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.rtxtHistory);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblIP);
            this.Name = "Form1";
            this.Text = "Assignment 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RichTextBox rtxtHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
    }
}

