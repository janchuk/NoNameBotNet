// Fonction permettant de récupérer l@ IP de la machine
string IPAddress = GetIPAddress();

public string GetIPAddress()
{
    IPHostEntry Host = default(IPHostEntry);
    string Hostname = null;
    Hostname = System.Environment.MachineName;
    Host = Dns.GetHostEntry(Hostname);
    foreach (IPAddress IP in Host.AddressList) {
        if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
            IPAddress = Convert.ToString(IP);
        }
    }
    return IPAddress;
}

public void CheckIP()
{
	GetIPAddress()
	
// Boucle infinie pour savoir si l@ IP de l'état précédent est tjrs la m que l'état actuelle
bool letsgo = true
while (letsgo == true) 
        {
					IPprec = IPAddress
					GetIPAddress()
					if(IPAddress != IPprec)
					{
						IPprec = IPAddress
						#Send la nouvelle IP au serveur avec le nom, pour que côté serveur le script fasse matcher les deux
					}
        }

}		
// Côté serveur cela devra faire le lien entre les différentes IP et l@ MAC du PC pour ne pas avoir de doublons