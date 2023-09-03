using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ships_JosefLukasek
{
    internal class ServerHandler
    {
        public static void StartServer()
        {
            IPAddress ipAddress = IPAddress.Parse("192.168.0.80");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 6666);

            try
            {

                // Create a Socket that will use Tcp protocol
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method
                listener.Bind(localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.
                // We will listen 10 requests at a time
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();

                // Incoming data from the client.
                string data = null;
                byte[] bytes = null;

                while (true)
                {
                    data = "";
                    /*
                    while (true)
                    {

                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }
                    */
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);


                    Console.WriteLine("Text received : {0}", data);
                    Console.WriteLine("Enter message:");
                    string entered = Console.ReadLine() ?? "null message entered";

                    if (entered == "exit")
                        break;

                    byte[] msg = Encoding.ASCII.GetBytes(entered + " <EOF>");

                    handler.Send(msg);
                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
