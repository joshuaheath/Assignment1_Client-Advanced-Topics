using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1_Client
{

    public class MessageReceivedEventArgs : EventArgs
    {
        //Property
        public string Message { get; }

        //Constructor
        public MessageReceivedEventArgs(string message) { Message = message; }
    }
    public class ConnectionClosedEventArgs : EventArgs
    {
        public bool ServerDisconnected { get; }
        public ConnectionClosedEventArgs(bool serverDisconnected) { ServerDisconnected = serverDisconnected; }
    }

    public class ChatClient
    {
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public event EventHandler<ConnectionClosedEventArgs> ConnectionClosed;
        //To raise these two write the following
        // MessageReceived?.Invoke(this, args)
        // ConnectionClosed?.Invoke(this, args)

        private Socket _socket;
        private readonly byte[] _buffer = new byte[1024];

        private readonly object _lockObj = new object();

        // Check if connected to the server
        public bool isConnected
        {

            //being inside of a lock means that only one thread can access it at a time
            get
            {
                lock (_lockObj)
                {
                    if (_socket != null && _socket.Connected)
                    { return true; }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public void Connect(string ip, int port)
        {

            lock (_lockObj) 
            {
                //Make sure were already not connected
                if (_socket != null)
                {
                    throw new InvalidOperationException("Already Connected");
                }

                //Create socket to connect to 
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    s.Connect(ip, port);
                }
                catch
                {
                    s.Close(); // Makes sure the socket doesnt leak if the connection someohow fails
                    throw;
                }

                //gets here if connection succeds and can update local class variable
                _socket = s;
                s.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, callback, s);
            }
        }


    }
}
