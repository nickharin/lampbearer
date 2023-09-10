using RogueSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Drawing
{
    internal interface IDrawable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }
        public char Symbol { get; set; }

        public void Draw(IMap map);
    }
}
