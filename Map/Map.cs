using lampbearer.Utils;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    public class Map : RogueSharp.Map
    {
        private Color[,] _color;
        private char[,] _symbol;

        public new void Initialize(int width, int height)
        { 
            _color = new Color[width, height];
            _symbol = new char[width, height];
            base.Initialize(width, height);
        }
        public void SetCellProperties(int x, int y, bool isTransparent, bool isWalkable, Color color, char symbol, bool isExplored = false)
        {
            _color[x, y] = color;
            _symbol[x, y] = symbol;
            SetCellProperties(x, y, isTransparent, isWalkable, isExplored);
        }

        public new ICell GetCell(int x, int y)
        {
            ICell cell = base.GetCell(x, y);
            return new Cell(cell, _color[x, y], _symbol[x, y]);
        }


        public new IEnumerable<ICell> GetAllCells()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return GetCell(x, y);
                }
            }
        }

        internal void SetCellProperties(int x, int y, bool transparent, bool walkable, string color, char symbol)
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            foreach (var cell in GetAllCells())
            {
                DrawCell((Cell)cell);
            }
        }


        private void DrawCell(Cell cell)
        {
            ConsoleDrawer.Draw(cell.X, cell.Y, cell.Symbol, cell.Color);
        }
    }
}
