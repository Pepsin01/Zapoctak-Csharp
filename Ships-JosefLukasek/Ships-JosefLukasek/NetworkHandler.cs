using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ships_JosefLukasek
{
    // Handles network communication.
    internal class NetworkHandler
    {
        Socket? handler;
        Socket? listener;
        bool running = false;
        Action<string> ReceiverCallback;
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkHandler"/> class.
        /// </summary>
        /// <param name="receiverCallback"> The receiver callback. </param>
        /// <param name="server"> True if this instance should run as server. </param>
        /// <param name="ip"> The IP address of this machine in LAN. </param>
        /// <param name="port"> Opened port for communication. </param>
        public NetworkHandler(Action<string> receiverCallback, bool server, string ip, int port)
        {
            this.ReceiverCallback = receiverCallback;

            try
            {
                IPAddress ipAddress = IPAddress.Parse(ip);
                IPEndPoint endPoint = new IPEndPoint(ipAddress, port);


                if (server)
                    StartServer(ipAddress, endPoint);
                else
                    StartClient(ipAddress, endPoint);
            }
            catch (FormatException) { 
                ReceiverCallback("[ERR] Invalid IP address <EOF>");
                ReceiverCallback("[ERR] CONNECTION_FAILED <EOF>");
            }
            catch (ArgumentOutOfRangeException) { 
                ReceiverCallback("[ERR] Invalid port <EOF>");
                ReceiverCallback("[ERR] CONNECTION_FAILED <EOF>");
            }
            catch (SocketException)
            {
                ReceiverCallback("[ERR] Connection failed <EOF>"); 
                ReceiverCallback("[ERR] CONNECTION_FAILED <EOF>");
            }


        }

        /// <summary>
        /// Initializes everything needed for server.
        /// </summary>
        /// <param name="ipAddress"> The IP address of this machine in LAN. </param>
        /// <param name="endPoint"> End point for communication. </param>
        private void StartServer(IPAddress ipAddress, IPEndPoint endPoint)
        {
            // Create a Socket that will use Tcp protocol
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // A Socket must be associated with an endpoint using the Bind method
            listener.Bind(endPoint);

            // We are expecting only one connection
            listener.Listen(1);

            ReceiverCallback("[STS] Waiting for a connection... <EOF>");

            // Start listening for connections.
            listener.BeginAccept(AcceptCallback, null);

        }

        /// <summary>
        /// Callback method when a client connection is accepted.
        /// </summary>
        private void AcceptCallback(IAsyncResult ar)
        {
            // Stop listening for new clients.
            handler = listener?.EndAccept(ar);

            ReceiverCallback("[STS] Client connected <EOF>");
            ReceiverCallback("[STS] CONNECTED <EOF>");

            // We don't need listener anymore.
            listener?.Close();
            listener = null;

            // Lunch a thread to receive messages from client.
            var receiveThread = new Thread(() => Receive());
            receiveThread.Start();
            running = true;
        }

        /// <summary>
        /// Initializes everything needed for client.
        /// </summary>
        /// <param name="ipAddress"> The IP address of this machine in LAN. </param>
        /// <param name="endPoint"> End point for communication. </param>
        private void StartClient(IPAddress ipAddress, IPEndPoint endPoint)
        {
            // Create a TCP/IP  socket.
            handler = new Socket(ipAddress.AddressFamily,
                                    SocketType.Stream, ProtocolType.Tcp);

            // Connect to Remote EndPoint
            handler.Connect(endPoint);

            ReceiverCallback("[STS] Socket connected to " + handler.RemoteEndPoint.ToString() + " <EOF>");
            ReceiverCallback("[STS] CONNECTED <EOF>");

            // Lunch a thread to receive messages from server.
            var receiveThread = new Thread(() => Receive());
            receiveThread.Start();
            running = true;
        }

        /// <summary>
        /// Body of the receive thread. Receives messages from the network and calls the callback.
        /// </summary>
        /// <param name="callback"> The callback function for received messages. </param>
        private void Receive()
        {
            string data;
            byte[] bytes;
            while (running)
            {
                data = "";

                // Data buffer for incoming data.
                bytes = new byte[1024];

                // Length of the message.
                int bytesRec = 0;

                // Receive the response from the remote device.
                try
                {
                    lock (handler)
                    {
                        bytesRec = handler?.Receive(bytes) ?? 0;
                    }
                }
                catch (SocketException)
                {
                    // If the connection is lost, close the connection and call the callback.
                    ReceiverCallback("[ERR] Connection lost <EOF>");
                    ReceiverCallback("[ERR] CONNECTION_LOST <EOF>");
                    Close();
                }

                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                // Passing the received message to the callback for further processing.
                ReceiverCallback(data);

                // Wait for 1 second before next receive to not overload the CPU.
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Send a message over the network.
        /// </summary>
        /// <param name="message"> The message to send. </param>
        public void Send(string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            try
            {
                lock (handler)
                {
                    handler?.Send(msg);
                }
            }
            catch (SocketException)
            {
                // If the connection is lost, close the connection and call the callback.
                ReceiverCallback("[ERR] Connection lost <EOF>");
                ReceiverCallback("[ERR] CONNECTION_LOST <EOF>");
                Close();
            }
        }

        /// <summary>
        /// Closes the network connection.
        /// </summary>
        public void Close()
        {
            running = false;
            lock (handler)
            {
                handler?.Shutdown(SocketShutdown.Both);
                handler?.Close();
                handler = null;
            }
        }
    }
}
