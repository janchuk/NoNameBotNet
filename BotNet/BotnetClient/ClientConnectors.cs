using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Botnet
{
    class ClientConnectors
    {
        public static string status;
        public static IPAddress iPAddress;
        public static int port;

        public ClientConnectors(IPAddress ipadd, int p)
        {
            iPAddress = ipadd;
            port = p;
        }
        static void SendData()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                IPAddress ipAddress = iPAddress;
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
                    Console.ReadKey();
                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                    // Send the data through the socket.  
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.  
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                }
                catch (ArgumentNullException e)
                {
                    status = "ArgumentNullException : {0}" + e.ToString();
                }
                catch (SocketException e)
                {
                    status = "SocketException : {0}" + e.ToString();
                }
                catch (Exception e)
                {
                    status = "Unexpected exception : {0}" + e.ToString();
                }

            }
            catch (Exception e)
            {
                status =  e.ToString();
            }
        }
    }
}
