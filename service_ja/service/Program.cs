using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace System.ServiceProcess
{
    class Program
    {
        public static object ServiceControllerStatus { get; private set; }

        static void Main(string[] args)
        {

            // Toggle the Telnet service - 
            // If it is started (running, paused, etc), stop the service.
            // If it is stopped, start the service.
            ServiceController sc = new ServiceController("firefox");
            Console.WriteLine("The Telnet service status is currently set to {0}",
                              sc.Status.ToString());

            if ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
                 (sc.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                // Start the service if the current status is stopped.

                Console.WriteLine("Starting the Telnet service...");
                sc.Start();
            }
            else
            {
                // Stop the service if its status is not set to "Stopped".

                Console.WriteLine("Stopping the Telnet service...");
                sc.Stop();
            }

            // Refresh and display the current service status.
            sc.Refresh();
            Console.WriteLine("The Telnet service status is now set to {0}.",
                               sc.Status.ToString());

        }
    }

    internal class ServiceController
    {
        private string v;

        public ServiceController(string v)
        {
            this.v = v;
        }

        public object Status { get; internal set; }

        internal void Start()
        {
            throw new NotImplementedException();
        }
    }
}
