using RogueSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    internal class Map : RogueSharp.Map
    {
        private Color[,] _color;
        private char[,] _symbol;

        public new void Initialize(int width, int height)
        { 
            _color = new Color[width, height];
            _symbol = new char[width, height];
            Initialize(width, height);
        }
        public void SetCellProperties(int x, int y, bool isTransparent, bool isWalkable, bool isExplored, Color color, char symbol)
        {
            _color[x, y] = color;
            _symbol[x, y] = symbol;
            SetCellProperties(x, y, isTransparent, isWalkable, isExplored);
        }

        public new ICell GetCell(int x, int y)
        {
            ICell cell = GetCell(x, y);
            return new Cell(cell, _color[x, y], _symbol[x, y]);
        }
    }
}
