using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ships_JosefLukasek
{
    internal class ClientHandler
    {
        public static void StartClient()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPAddress ipAddress = IPAddress.Parse("192.168.0.80");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 6666);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    while (true)
                    {
                        // Encode the data string into a byte array.
                        Console.WriteLine("Enter message:");
                        string entered = Console.ReadLine() ?? "null message entered";

                        if (entered == "exit")
                            break;

                        byte[] msg = Encoding.ASCII.GetBytes(entered + "<EOF>");

                        // Send the data through the socket.
                        int bytesSent = sender.Send(msg);

                        Console.WriteLine("Waiting for reply...");

                        // Receive the response from the remote device.
                        int bytesRec = sender.Receive(bytes);
                        Console.WriteLine("Recieved message = {0}",
                            Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    }

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
