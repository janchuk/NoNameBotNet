using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Botnet
{
    class Executor
    {
        void protocolDecoder(string received)
        {

            int nbArg = Regex.Matches(received, "<ARG>").Count;
            int nbArg1 = Regex.Matches(received, "<CMD>").Count;
            
        }
    }
}
