using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClientLib;

namespace Assignment1_Client
{
    public partial class Form1 : Form
    {
        #region
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        #endregion
        private readonly ChatClient _chatClient = new ChatClient();
        public Form1()
        {
            InitializeComponent();
           _chatClient.MessageReceived += Chat_MessageReceived;
           _chatClient.ConnectionClosed += Chat_ConnectionClosed;
            FormClosing += (s, e) => _chatClient.Disconnect();
        }

        private void AppendHistory(string message)
        {
            if (IsDisposed) { return; }


            if (InvokeRequired)
            {
                try { BeginInvoke(new Action(() => AppendHistory(message))); }
                catch (ObjectDisposedException) { MessageBox.Show("NETWORK: Disconnected while appending"); }
                catch (InvalidOperationException) { }
            }
            else
            {
                rtxtHistory.AppendText(message);
                rtxtHistory.ScrollToCaret();
            }
        }

        private void Chat_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            AppendHistory("Server: " + e.Message.TrimEnd('\r', '\n') + "\n");
        }

        private void Chat_ConnectionClosed(object sender, ConnectionClosedEventArgs e)
        {
            AppendHistory(e.ServerDisconnected ? 
                "NETWORK: Server Disconnected\n" :
                "NETWORK: Disconnected\n");
        }
        private void toolStripBtnConnect_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(toolStripTxtPort.Text, out int port))
            {
                MessageBox.Show("ERROR: Port must be a number");
                return;
            }

            try
            {
                _chatClient.Connect(toolStripTxtIP.Text, port);
                AppendHistory("NETWORK: Connected\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR - Could Not connect. Reason:\n" + ex.Message);
            }
            
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!_chatClient.IsConnected) 
            {
                MessageBox.Show("Not Connected to a server");
                return;
            }

            string messsage = txtMessage.Text;
            if (messsage.Length == 0) { return; }

            try
            {
                _chatClient.Send(messsage);
                AppendHistory("Client: " + messsage + "\n");

                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: Send failded: " + ex.Message);
            }
        }
        private void toolStripBtnDisconnect_Click(object sender, EventArgs e)
        {
            if (!_chatClient.IsConnected)
            {
                MessageBox.Show("ERROR: Not Connected to a server");
                return;
            }

            _chatClient.Disconnect();
        }


        private void toolStripBtnAutoFill_Click(object sender, EventArgs e)
        {
            toolStripTxtIP.Text = "127.0.0.1";
            toolStripTxtPort.Text = "13000";
        }

    }
}
