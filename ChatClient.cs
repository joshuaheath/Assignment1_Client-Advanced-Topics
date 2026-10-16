using System;
using System.Net.Sockets;
using System.Text;

namespace Assignment1_Client
{

    public class MessageReceivedEventArgs : EventArgs
    {
        public string Message { get; }

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
        // Decoding 
        // Encoding
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public event EventHandler<ConnectionClosedEventArgs> ConnectionClosed;
        //To raise these two write the following
        // MessageReceived?.Invoke(this, args)
        // ConnectionClosed?.Invoke(this, args)

        private Socket _socket;
        private readonly byte[] _buffer = new byte[1024];

        private readonly object _lockObj = new object();

        // Check if connected to the server
        public bool IsConnected
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
                Socket locSoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    locSoc.Connect(ip, port);
                }
                catch
                {
                    locSoc.Close(); // Makes sure the socket doesnt leak if the connection someohow fails
                    throw;
                }

                //gets here if connection succeds and can update local class variable
                _socket = locSoc;
                locSoc.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, On_Receive_Callback, locSoc);
            }
        }

        //From this point further when accessing the socket to communicate with the server make sure you do (s = _socket;) in a lock block
        public void Send(string message) 
        {
            Socket locSoc;

            lock (_lockObj)
            {
                locSoc = _socket;  // After this we can now use the locSoc to communicate with the server
                if (_socket == null) { throw new InvalidOperationException("Not Connected"); }
            }
            //Convertes message into data that can be sent through the socket
            byte[] data = Encoding.UTF8.GetBytes(message + "\n");

            //Starts sending the data asynchronusly, callback completes send operation safely
            locSoc.BeginSend(data, 0, data.Length, SocketFlags.None, On_Sent_Callback, locSoc);
        }


        public void Disconnect()
        {
            Socket locSoc;

            lock (_lockObj)
            {
                locSoc = _socket;  // After this we can now use the locSoc to communicate with the server
                if (_socket == null && locSoc == null) { return; }

                try { locSoc.Shutdown(SocketShutdown.Both); } 
                catch (SocketException) { }
                locSoc.Close();
                //Clears socket
                _socket = null;
            }

            ConnectionClosed?.Invoke(this, new ConnectionClosedEventArgs(false));
        }


        //This is an asyncronus callback whenever client recives something and decodes it
        private void On_Receive_Callback(IAsyncResult iasync)
        {
            Socket locSoc = (Socket)iasync.AsyncState;
            try
            {
                //completes the operation started by "BeginReceive" and converts how many bytes were recivied
                int bytes = locSoc.EndReceive(iasync);

                // We disconnected
                lock(_lockObj) { if (_socket != locSoc) return; } 
                
                //True due if server closed the connection. Calls event to notify UI
                if (bytes == 0) { Server_Disconnected(locSoc); return; }

                //Decodes bytes from socket
                string text = Encoding.UTF8.GetString(_buffer, 0, bytes);
                MessageReceived?.Invoke(this, new MessageReceivedEventArgs(text));

                //starts back the receving on a background thread
                locSoc.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, On_Receive_Callback, locSoc);
            }
            catch (ObjectDisposedException) { } // closed from client
            catch (SocketException) { Server_Disconnected(locSoc);}  //Connection Lost
        }

        // Safely closes async sending
        private void On_Sent_Callback(IAsyncResult iasync)
        {
            Socket s = (Socket)iasync.AsyncState;
            try { s.EndSend(iasync); }
            catch (Exception) 
            { 
                Server_Disconnected(s); 
                s.Close();
            }
        }

        private void Server_Disconnected(Socket s)
        {
            lock (_lockObj)
            {
                if (_socket != s) return; //Already handled by Disconnect or another callback

                _socket.Close();
                //Reset the socket
                _socket = null;
            }
            //Invoke event to update UI that server disconnected
            ConnectionClosed?.Invoke(this, new ConnectionClosedEventArgs(true)); 
            
        }
    }
}
