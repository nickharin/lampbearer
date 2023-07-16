using RogueSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    internal interface IMapGenerator
    {
        IMap GenerateMap();
    }
}
