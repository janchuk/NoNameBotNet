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
    class serverSlave   //une classe (dans une classe, il y a des fonctions)
    {
        static void Main(string[] args)  // c'est un main (fonction)
        {

            ServerConnectors sc = new ServerConnectors(IPAddress.Parse("127.0.0.1"), 2107);
            sc.ListenAndReceiveData();
            Console.WriteLine(sc.status);
            //Use class mathod after
           
           
        }



    }

}
