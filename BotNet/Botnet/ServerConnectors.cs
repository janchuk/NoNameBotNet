using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Botnet
{
    public class ServerConnectors
    {
        public static string status;
        public static IPAddress iPAddress;
        public static int port;

        public ServerConnectors(IPAddress ipadd, int p)
        {
            iPAddress = ipadd;
            port = p;
        }

        public static void ListenAndReceiveData() 
        {
            Socket ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddr = iPAddress;
            IPEndPoint ipEnd = new IPEndPoint(ipaddr, port);
            byte[] buff = new byte[1024];
            string data = null;

            try
            {
                ss.Bind(ipEnd);
                ss.Listen(1);

                while (true)
                {
                    status = "Waiting for a connection...";
                    Socket handler = ss.Accept();

                    while (true)
                    {
                        buff = new byte[1024];
                        int bytesRec = handler.Receive(buff);
                        data += Encoding.ASCII.GetString(buff, 0, bytesRec);

                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    status = "Text received : {0}" + data;
                }
            }

            catch (Exception e)
            {
                status = e.Message;
            }

        }
    }
}
