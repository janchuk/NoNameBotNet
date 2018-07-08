using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Security.Permissions;

namespace process
{
    class Program_process
    {

        static void Main(string[] args)
        {
            string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string destinationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            Process[] pname = Process.GetProcessesByName("process2");
            Console.WriteLine(destinationDirectory);
            Console.WriteLine(pname.Length);
            string appName = AppDomain.CurrentDomain.FriendlyName;

            if (File.Exists(destinationDirectory + "\\" + appName))
            {
                Console.WriteLine("fichier existe");
            }
            else if (Directory.Exists(destinationDirectory))
            {
                File.Copy(path + "\\" + appName, destinationDirectory + "\\" + appName);
                //File.Copy(destinationDirectory, path + "\\" + appName);
                //File.Copy(@"C:\startup.log", @"C:\usr\startupcopy.log");
            }

            else
            {
                Directory.CreateDirectory(destinationDirectory);
                //ajouter instructions
            }


            // Process.Start(path + "\\" + appName);
            // System.Environment.Exit(1);



            //Console.WriteLine(path + "\\" + appName);
            //Console.WriteLine(appName);
           // Console.ReadKey();


            
            /*RegistryPermission f = new RegistryPermission(RegistryPermissionAccess.AllAccess, "HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            RegistryKey regKey = Registry.LocalMachine;

            regKey = regKey.OpenSubKey("SOFTWARE");
            regKey = regKey.OpenSubKey("Microsoft");
            regKey = regKey.OpenSubKey("Windows");
            regKey = regKey.OpenSubKey("CurrentVersion");
            regKey = regKey.OpenSubKey("Run", true);
            */
            //RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            //RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue(AppDomain.CurrentDomain.FriendlyName, path);
            //rk.SetValue("application",.ExecutablePath.ToString());
            //Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);

          //  Console.ReadKey();      //Va attendre une touche du clavier pour lancer la suite (ReadKey)
            

            Process Myprocess = new Process();
            Myprocess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Myprocess.StartInfo.FileName = @"C:\Users\yann\source\repos\process\process2\bin\Debug\process2.exe";
            pname = Process.GetProcessesByName("process2");
          //  Myprocess.StartInfo.UseShellExecute = true;
            //Myprocess.StartInfo.Verb = "runas";

            try
            {
                while(true)
                {
                    pname = Process.GetProcessesByName("process2");
                    if (pname.Length == 1)
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