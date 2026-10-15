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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.rtxtHistory = new System.Windows.Forms.RichTextBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTxtIP = new System.Windows.Forms.ToolStripTextBox();
            this.portToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTxtPort = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripBtnAutoFill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripBtnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(17, 458);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(790, 26);
            this.txtMessage.TabIndex = 4;
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
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 33);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iPToolStripMenuItem,
            this.portToolStripMenuItem,
            this.toolStripBtnAutoFill,
            this.toolStripBtnConnect});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 29);
            this.toolStripMenuItem1.Text = "Network";
            // 
            // iPToolStripMenuItem
            // 
            this.iPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTxtIP});
            this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
            this.iPToolStripMenuItem.Size = new System.Drawing.Size(230, 34);
            this.iPToolStripMenuItem.Text = "IP";
            // 
            // toolStripTxtIP
            // 
            this.toolStripTxtIP.AcceptsReturn = true;
            this.toolStripTxtIP.AccessibleDescription = "";
            this.toolStripTxtIP.AccessibleName = "";
            this.toolStripTxtIP.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripTxtIP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTxtIP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTxtIP.ForeColor = System.Drawing.SystemColors.InfoText;
            this.toolStripTxtIP.Name = "toolStripTxtIP";
            this.toolStripTxtIP.Size = new System.Drawing.Size(100, 24);
            this.toolStripTxtIP.Text = "Replace Me";
            // 
            // portToolStripMenuItem
            // 
            this.portToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTxtPort});
            this.portToolStripMenuItem.Name = "portToolStripMenuItem";
            this.portToolStripMenuItem.Size = new System.Drawing.Size(230, 34);
            this.portToolStripMenuItem.Text = "Port";
            // 
            // toolStripTxtPort
            // 
            this.toolStripTxtPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTxtPort.Name = "toolStripTxtPort";
            this.toolStripTxtPort.Size = new System.Drawing.Size(100, 31);
            this.toolStripTxtPort.Text = "Replace Me";
            // 
            // toolStripBtnAutoFill
            // 
            this.toolStripBtnAutoFill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.toolStripBtnAutoFill.ForeColor = System.Drawing.Color.Red;
            this.toolStripBtnAutoFill.Name = "toolStripBtnAutoFill";
            this.toolStripBtnAutoFill.Size = new System.Drawing.Size(230, 34);
            this.toolStripBtnAutoFill.Text = "Fill Ip and Port";
            this.toolStripBtnAutoFill.Click += new System.EventHandler(this.toolStripBtnAutoFill_Click);
            // 
            // toolStripBtnConnect
            // 
            this.toolStripBtnConnect.Name = "toolStripBtnConnect";
            this.toolStripBtnConnect.Size = new System.Drawing.Size(230, 34);
            this.toolStripBtnConnect.Text = "CONNECT";
            this.toolStripBtnConnect.Click += new System.EventHandler(this.toolStripBtnConnect_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(21, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 385);
            this.panel1.TabIndex = 11;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(180, 153);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(560, 75);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "GAME GOES HERE";
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 882);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.rtxtHistory);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Assignment 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.RichTextBox rtxtHistory;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtIP;
        private System.Windows.Forms.ToolStripMenuItem portToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtPort;
        private System.Windows.Forms.ToolStripMenuItem toolStripBtnConnect;
        private System.Windows.Forms.ToolStripMenuItem toolStripBtnAutoFill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

