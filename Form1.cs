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
using static System.Windows.Forms.AxHost;

namespace Assignment1_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Gloab variables/values
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblIP_Click(object sender, EventArgs e)
        {

        }

        private void lblPort_Click(object sender, EventArgs e)
        {

        }

        //Constants
        Socket _client = null;
        string _ip = string.Empty;
        int _port = 1200;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            _ip = txtIP.Text;
            int.TryParse(txtPort.Text, out _port);

            try
            {
                _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _client.Connect(_ip, _port);

                MessageBox.Show("Connected");

                StateObj _state = new StateObj();
                _state.socket = _client;
                _client.BeginReceive(_state.buffer, 0, StateObj.buffersize, SocketFlags.None, new AsyncCallback(receiveMessage), _state);
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.ToString());
            }
        }

        private void receiveMessage(IAsyncResult iasync)
        {
            StateObj asyncMsgData = (StateObj)iasync.AsyncState;
            Socket handler = asyncMsgData.socket;

            try
            {
                int i = handler.EndReceive(iasync);

                //RecivedMsg converted into a string
                string receivedMsgString = Encoding.ASCII.GetString(asyncMsgData.buffer, 0, i);

                // Invoking method to display recived text to txtBox history
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.rtxtHistory.AppendText("Server: " + receivedMsgString + "\n");
                }));

                _client.BeginReceive(asyncMsgData.buffer, 0, StateObj.buffersize, SocketFlags.None, new AsyncCallback(receiveMessage), asyncMsgData);
            }
            catch (SocketException)
            {
                MessageBox.Show("Server Disconnected");
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.ToString());
            }
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string sendingMessage = txtMessage.Text;
            _client.Send(Encoding.ASCII.GetBytes(sendingMessage));

            this.Invoke(new MethodInvoker(delegate ()
            {
                this.txtMessage.Text = "";
                this.rtxtHistory.AppendText("Client: " + sendingMessage + "\n");
            }));
        }
    }

    public class StateObj
    {
        public Socket socket = null;
        public const int buffersize = 1024;
        public byte[] buffer = new byte[buffersize];
    }
}
