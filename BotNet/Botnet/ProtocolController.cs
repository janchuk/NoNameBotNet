using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botnet
{
    class ProtocolController
    {
        ProtocolController()
        {

        }

        public bool DataIntegrity(string data)
        {
            int i = data.Length;

            //Si la donnée ne commence pas par <SFC>
            if (data.Substring(0, 5) != "<SOC>")
            {
                return false;
            }

            //Si la donnée ne termine pas par <EFC>
            if (data.Substring(data.Length - 5) != "<EOC>")
            {
                return false;
            }
            return true;
        }
    }
}
