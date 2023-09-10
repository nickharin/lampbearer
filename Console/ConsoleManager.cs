using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Console
{
    public static class ConsoleManager
    {
        public static ConsoleKey getKey()
        {
            ConsoleKey key = System.Console.ReadKey(true).Key;
            return key;
        }
    }
}
