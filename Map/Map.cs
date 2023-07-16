using lampbearer.Actor;
using lampbearer.Drawing;
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

        public new Cell GetCell(int x, int y)
        {
            ICell cell = base.GetCell(x, y);
            return new Cell(cell, _color[x, y], _symbol[x, y]);
        }


        internal void SetCellProperties(int x, int y, bool transparent, bool walkable, string color, char symbol)
        {
            throw new NotImplementedException();
        }

        public void Draw(Player player, Window window)
        {
            Camera camera = player.Camera;
            
            for (int y = camera.getStartY(player.Y); y < camera.getEndY(player.Y); y++)
            {
                for (int x = camera.getStartX(player.X); x < camera.getEndX(player.X); x++)
                { 
                    window.Draw(x, y, GetCell(x, y));
                    window.Draw(player);
                }
            }
        }

        /// <summary>
        /// Returns true when able to place the Actor on the cell or false otherwise
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool SetActorPosition(IActor actor, int x, int y)
        {
            // Only allow actor placement if the cell is walkable
            if (GetCell(x, y).IsWalkable)
            {
                // The cell the actor was previously on is now walkable
                SetIsWalkable(actor.X, actor.Y, true);
                // Update the actor's position
                actor.X = x;
                actor.Y = y;
                // The new cell the actor is on is now not walkable
                SetIsWalkable(actor.X, actor.Y, false);
                // Try to open a door if one exists here
                
                return true;
            }
            return false;
        }

        public void SetIsWalkable(int x, int y, bool isWalkable)
        {
            Cell cell = GetCell(x, y);
            SetCellProperties(cell.X, cell.Y, cell.IsTransparent, isWalkable, cell.IsExplored);
        }
    }
}
