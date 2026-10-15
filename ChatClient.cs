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

        private Socket _client;
        private readonly byte[] _buffer = new byte[1024];

        private readonly object _lockObj = new object();

        // Check if connected to the server
        public bool isConnected
        {

            //being inside of a lock means 
            get
            {
                lock (_lockObj)
                {
                    if (_client != null && _client.Connected)
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

        }
    }
}
