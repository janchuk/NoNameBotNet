using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Botnet
{
    //Cette classe sert à contrôle l'intégrité des données reçu et d'en extraire les données utiles
    class ProtocolController
    {
        public string data = "";
        public string action = "";
        public string target = "";
        public List<string> arguments = new List<string>();
        public string response = "";

        public ProtocolController(string dataToControl)
        {
            data = dataToControl;

            //Si la donnée est valide on continue son traitement
            if (DataIntegrity(data) == true)
            {
                action = GetAction();
                target = GetTarget();
                GetArguments();
            }

        }

        public bool DataIntegrity(string data)
        {
            //Si la donnée ne commence pas par <SOC> Start Of Communcation
            if (data.Substring(0, 5) != "<SOC>")
            {
                response = "<SOC>Received a misformed message: {" + data + "}<EOC>";
                return false;
            }

            //Si la donnée ne termine pas par <EOC> End Of Communication
            if (data.Substring(data.Length - 5) != "<EOC>")
            {
                response = "<SOC>Received a misformed message: {" + data + "}<EOC>";
                return false;
            }

            //Si la donnée ne contient pas de commande ou si les balises sont mal formatées
            if (!data.Contains("<CMD>") || !data.Contains("</CMD>"))
            {
                response = "<SOC>Misformed command or no command received: {" + data + "}<EOC>";
                return false;
            }

            //Si tout va bien
            response = "<SOC>Integrity OK<EOC>";
            return true;
        }

        //Extraire l'action de la requête
        private string GetAction()
        {
            return data.Substring(data.IndexOf("<CMD>") + 5, data.IndexOf("</CMD>") - data.IndexOf("<CMD>") - 5);
        }

        //Extraire l'action de la requête
        private string GetTarget()
        {
            return data.Substring(data.IndexOf("<TARGET>") + 8, data.IndexOf("</TARGET>") - data.IndexOf("<TARGET>") - 8);
        }

        //Extraire l'action de la requête
        private void GetArguments()
        {
            //Regex qui selectionne dans une string <ARG*>xxxx</ARG*>
            string pattern = @"<ARG\d>\w*<\/ARG\d>";
            
            //Contiendra les arguments sans les balises <ARG>:
            string[] withoutTag;

            //On filtre pour ne boucler que sur les balises <ARG*>xxxx</ARG*>, et les stocker dans le tableau des arguments
            foreach (Match m in Regex.Matches(data, pattern))
            {
                //Pour supprimer la balise d'ouverture <ARG*>
                pattern = @"<ARG\d>";
                withoutTag = Regex.Split(m.Value, pattern);

                //Pour supprimer la balise de fermeture </ARG*>
                pattern = @"</ARG\d>";
                withoutTag = Regex.Split((string.Join("", withoutTag)), pattern);

                //On ajoute l'argument dans le tableau des argument:
                arguments.Add(string.Join("", withoutTag));

                //nbp: string.Join("", withoutTag) sert à convertir le type string[] en type string
            }


        }
    }
}
