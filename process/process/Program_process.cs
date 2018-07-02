using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace process
{
    class Program_process
    {

        static void Main(string[] args)
        {
            Process[] pname = Process.GetProcessesByName("process2");
            Console.WriteLine(pname.Length);
            
            Process Myprocess = new Process();
            Myprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Myprocess.StartInfo.FileName = @"C:\Users\yann\source\repos\process\process2\bin\Debug\process2.exe";
            pname = Process.GetProcessesByName("process2");
           
            try
            {
                while(true)
                {
                    pname = Process.GetProcessesByName("process2");
                    if (pname.Length == 0)
                    {
                        
                        Myprocess.Start();
                       
                       
                        Console.WriteLine(pname.Length);
                        
                    }
                    
                }

                

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }

        }
    }
}