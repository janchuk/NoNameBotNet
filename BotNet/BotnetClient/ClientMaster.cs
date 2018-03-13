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
    class master
    {
        public static Socket senderSock;

        static void Main(string[] args)
        {
            Console.WriteLine("coucou je suis le client");
            Console.ReadKey();
            SocketClient sc = new SocketClient();
            sc.Connect(2107);
            Console.WriteLine(sc.status);
            Console.ReadKey();

        }


    }
}
