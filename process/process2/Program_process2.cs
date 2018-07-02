using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace process2
{
    class Program_process2
    {
        static void Main(string[] args)
        {
            Process[] pname = Process.GetProcessesByName("process");
            Console.WriteLine(pname.Length);

            Process Myprocess = new Process();
            Myprocess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Myprocess.StartInfo.FileName = @"C:\Users\yann\source\repos\process\process\bin\Debug\process.exe";
            pname = Process.GetProcessesByName("process");

            try
            {
                while (true)
                {
                    pname = Process.GetProcessesByName("process");
                    if (pname.Length == 0)
                    {

                        Myprocess.Start();


                        Console.WriteLine(pname.Length);

                    }

                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}
