using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    internal class FileMapGenerator : IMapGenerator
    {
        private readonly String _path = "./Resources/map.txt";

        public IMap? GenerateMap()
        {
            return null;
        }
    }
}
