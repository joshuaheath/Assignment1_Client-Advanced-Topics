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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void receiveMessage(IAsyncResult iasync)
        {
            //Recasts "iasync" as StateObj
            StateObj asyncMsgData = (StateObj)iasync.AsyncState;
            Socket handler = asyncMsgData.socket;

            try
            {
                //Num of bytes recived
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


        private void rtxtHistory_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            string sendingMessage = txtMessage.Text;
            _client.Send(Encoding.ASCII.GetBytes(sendingMessage + "\n"));

            this.Invoke(new MethodInvoker(delegate ()
            {
                //Resets Message box for nexttime
                this.txtMessage.Text = "";
                this.rtxtHistory.AppendText("Client: " + sendingMessage + "\n");
            }));
        }

        //Class level variables (Any class can use them)
        Socket _client = null;
        string _ip = "127.0.0.1";
        int _port = 1200;

        private void toolStripBtnConnect_Click(object sender, EventArgs e)
        {
            _ip = toolStripTxtIP.Text;
            int.TryParse(toolStripTxtPort.Text, out _port);

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
                //MessageBox.Show(_e.ToString());
                //MessageBox.Show(_e.Message);
                MessageBox.Show("Invalid IP or Port, Try Again");
                Console.WriteLine(_e.Message);
                Console.WriteLine(_e.ToString());
            }
        }

        private void toolStripTxtIP_Click(object sender, EventArgs e)
        {

        }

        private void toolStripBtnAutoFill_Click(object sender, EventArgs e)
        {
            toolStripTxtIP.Text = "127.0.0.1";
            toolStripTxtPort.Text = "13000";
        }
    }

    public class StateObj
    {
        public Socket socket = null;
        public const int buffersize = 1024;
        public byte[] buffer = new byte[buffersize];
    }
}
