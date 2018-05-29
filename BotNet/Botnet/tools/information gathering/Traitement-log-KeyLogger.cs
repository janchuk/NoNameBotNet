using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_lecture_ecriture
{
    class Program
    {
        static void mainTraitement(string[] arsgs)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Paul\source\repos\ConsoleApp2\ConsoleApp2\bin\Debug\log.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                // Faire fonction qui copi le fichier avant le remplacement pour sauvegarde
                // Faire boucle de remplacement entre deux maj car pas les memes caractéres en maj
                // Faire boucle de remplacement en Shift
                // Faire boucle de remplacement après touche Fn (LButton, OemClear) pour fonction
                // Mot en terme capital = action
                // Faire Back (effacer)

                // remplacement SANS MAJ
                line = line.Replace("Back", "RETOUR");
                line = line.Replace("Space", " ");
                line = line.Replace("D0", "à");
                line = line.Replace("D1", "&");
                line = line.Replace("D2", "é");
                line = line.Replace("D3", " "); // comment ajouter "
                line = line.Replace("D4", " "); // comment ajouter '
                line = line.Replace("D5", "(");
                line = line.Replace("D6", "-");
                line = line.Replace("D7", "è");
                line = line.Replace("D8", "_");
                line = line.Replace("D9", "ç");
                line = line.Replace("Escape", "ECHAP");
                line = line.Replace("Oem7", "²");
                line = line.Replace("Tab", "TABULATION");
                line = line.Replace("LControl", "CTRLGAUCHE");
                line = line.Replace("RControlKey", "CTRLDROITE");
                line = line.Replace("KeyLWin", "WINDOWSGAUCHE");
                line = line.Replace("PrintScreen", "SCREEN");
                line = line.Replace("OemBackslash", "<");
                line = line.Replace("Oemcomma", ",");
                line = line.Replace("OemPeriod", ";");
                line = line.Replace("OemQuestion", ":");
                line = line.Replace("Oem8", "!");
                line = line.Replace("OemOpenBrackets", ")");
                line = line.Replace("Oemplus", "=");
                line = line.Replace("Return", "ENTREE");
                line = line.Replace("Left", "FLECHE-GAUCHE");
                line = line.Replace("Down", "FLECHE-BAS");
                line = line.Replace("Right", "FLECHE-DROITE");
                line = line.Replace("PageUp", "FLECHE-HAUT-LOIN");
                line = line.Replace("Up", "FLECHE-HAUT");
                line = line.Replace("Next", "FLECHE-BASSE-LOIN");
                line = line.Replace("VolumeMute", "VOLUME-MUTE");
                line = line.Replace("VolumeDown", "VOLUME-BAS");
                line = line.Replace("VolumeUp", "VOLUME-UP");
                line = line.Replace("LWinP", "PROJECTION");
                line = line.Replace("LWinA", "ACT-DES-WIRELESS");
                line = line.Replace("LWinI", "PARAMETRE");
                line = line.Replace("LWinILWinS", "RECHERCHE-W");
                line = line.Replace("LControlKeyLMenuTabP", "MULTI-TASK");
                line = line.Replace("LWinUpReturn", "MULTI-LOGICIEL");

                // remplacement avec MAJ


                System.Console.WriteLine(line);
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
