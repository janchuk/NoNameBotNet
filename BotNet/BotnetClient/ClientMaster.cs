﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
//using System.Windows.Controls;
using System.Threading;
//using System.Windows.Threading;
using Botnet;

namespace BotnetClient
{
    class ClientMaster
    {

        static void Main(string[] args)
        {
            ClientConnectors cn = new ClientConnectors(IPAddress.Parse("127.0.0.1"), 2107);
            string msg = "coucou";
            cn.SendData(msg);
            Console.ReadKey();
            //Use class method after
        }


    }
}
