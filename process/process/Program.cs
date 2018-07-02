using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace process
{
    class Program
    {

        static void Main(string[] args)
        {
            Process[] pname = Process.GetProcessesByName("cmd");
            Console.WriteLine(pname.Length);
            //Console.ReadKey();
            Process Myprocess = new Process();
            Myprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Myprocess.StartInfo.FileName = "cmd";
            pname = Process.GetProcessesByName("cmd");
            //Myprocess.Start();
            // Myprocess = true;
            try
            {
                while(true)
                {
                    pname = Process.GetProcessesByName("cmd");
                    if (pname.Length == 0)
                    {
                        //Myprocess.Start();
                        Myprocess.Start();
                       // Console.ReadKey();
                       // pname = Process.GetProcessesByName("cmd");
                        Console.WriteLine(pname.Length);
                        // Console.ReadKey();
                    }
                    
                }

                /* else
                 {
                     Console.WriteLine("running");
                 }         */



                /* Process[] processlist = Process.GetProcesses();
                 Console.ReadKey();
                 foreach (Process theprocess in processlist)
                 {
                     Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
                     //Console.ReadKey();
                     //Console.WriteLine(theprocess);
                     //Console.ReadKey();
                 }
                // Console.ReadKey();
                 Console.ReadKey();
                 //if(processlist.Length == 0)
                 //Console.WriteLine(processlist.length);
                 //Console.ReadKey();*/

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}