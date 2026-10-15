using System;
using System.Diagnostics.Eventing.Reader;
using System.Net.Sockets;
using System.Text;
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

        //What are the operations that need to happen to chat with a server
        // Connecting
        // Sending
        // Receviing
        // Disconnecting
        // 
        //
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
                s.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, onConnectCallback, s);
            }
        }

        //From this point further when accessing the socket to communicate with the server make sure you do (s = _socket;) in a lock block
        public void Send(string message) 
        {
            Socket locSoc;

            lock (_lockObj) { locSoc = _socket; } // After this we can now use the locSoc to communicate with the server
            if (_socket == null) { throw new InvalidOperationException("Not Connected"); }

            //Convertes message into data that can be sent through the socket
            byte[] data = Encoding.UTF8.GetBytes(message + "\n");

            locSoc.BeginSend(data, 0, data.Length, SocketFlags.None, OnSentCallback, s);
        }


        public void Disconnect()
        {
            Socket locSoc;

            lock (_lockObj) { locSoc = _socket; } // After this we can now use the locSoc to communicate with the server
            if (_socket == null) { throw new InvalidOperationException("Not Connected"); }

            try { locSoc.Shutdown(SocketShutdown.Both); } 
            catch (SocketException) { }
            locSoc.Close();

            //Check if the socket closed
            ConnectionClosed?.Invoke(this, new ConnectionClosedEventArgs(false));
        }

    }
}
