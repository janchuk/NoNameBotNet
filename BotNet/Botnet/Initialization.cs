using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botnet
{
    //Cette classe contiendra tout ce qu'il faut faut serveur au moment de l'infection: installation, envoie de données au C&C
    class Initialization
    {
        Initialization()
        {

        }

        public bool IsAlreadyInstalled()
        {

            return false;
        }

        public void Install()
        {

        }

        public void sendInfoToCNC()
        {
            //Envoyer l'ip, le port, le nom de machine et autres infos essentielles pour pouvoir contrôler les victimes (via HTTP/s?)
        }
    }
}
