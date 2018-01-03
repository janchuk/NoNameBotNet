using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
//using System.Windows.Controls;
using System.Threading;
//using System.Windows.Threading;

namespace BotnetClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("coucou je suis le client");
            Console.ReadKey();

            // Receiving byte array  
            byte[] bytes = new byte[1024];
            Socket senderSock;

            try
            {
                //détermine les permissions du socket (obligatoire pour un socket)
                SocketPermission permission = new SocketPermission(NetworkAccess.Connect, TransportType.Tcp, "", SocketPermission.AllPorts);

                //Permet de passer les exceptions de sécurité
                permission.Demand();

                //Permet de mettre un DNS en IP
                IPHostEntry ipHost = Dns.GetHostEntry("");
                //Prend la 1ere IP stockée dans l'objet ipHost
                IPAddress ipAddr = ipHost.AddressList[0];

                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 2107);

                //Création du Socket
                senderSock = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                senderSock.NoDelay = false;

                //Etablit la connexion vers le serveur distant en écoute
                senderSock.Connect(ipEndPoint);
                Console.WriteLine("Socket connecté à " + senderSock.RemoteEndPoint.ToString());
                Console.ReadKey();

            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
                Console.ReadKey();
            }
        }
    }
}
