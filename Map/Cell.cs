using RogueSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    internal class Cell : RogueSharp.Cell
    {
        public char Symbol { get; set; }
        public Color Color { get; set; }


        public Cell(ICell cell, Color color, char symbol)
            : base(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, cell.IsInFov, cell.IsExplored)
        {
            Color = color;
            Symbol = symbol;
        }

        public Cell(int x, int y, bool isTransparent, bool isWalkable, bool isInFov, bool isExplored, Color color, char symbol)
            : base(x, y, isTransparent, isWalkable, isInFov, isExplored)
        {
            Color = color;
            Symbol = symbol;
        }
    }
}
