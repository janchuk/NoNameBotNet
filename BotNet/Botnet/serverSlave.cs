﻿using System;
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
            
            Socket ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = IPAddress.Parse("127.0.0.1");

            IPEndPoint ipEnd = new IPEndPoint(ipaddr, 2107);
            byte[] buff = new byte[1024];
            string data = null;

            Console.WriteLine("Press enter to listen");
            Console.ReadKey();
            try
            {
                ss.Bind(ipEnd);
                ss.Listen(1);

                while(true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = ss.Accept();

                    while(true)
                    {
                        buff = new byte[1024];
                        int bytesRec = handler.Receive(buff);
                        data += Encoding.ASCII.GetString(buff, 0, bytesRec);

                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Text received : {0}", data);
                }
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
           
           
        }



    }

}
