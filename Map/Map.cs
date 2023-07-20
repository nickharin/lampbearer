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

            ConsoleDrawer.Draw(41, 2, $"Camera x0:{camera.GetStartX(player.X)}, y0:{camera.GetStartY(player.Y)}");
            ConsoleDrawer.Draw(41, 3, $"Camera x1:{camera.GetEndX()}, y1:{camera.GetEndY()}");
            int wY = 0, wX = 0;
            for (int y = camera.Y; y < camera.GetEndY(); y++)
            {
                for (int x = camera.X; x < camera.GetEndX(); x++)
                { 
                    window.Draw(wX, wY, GetCell(x, y));

                    window.Draw(camera.GetInCameraX(player), camera.GetInCameraY(player), player);
                    wX++;
                }
               wX = 0;
               wY++;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="x">Координата, на которую пытаемся передвинуть игрока </param>
        /// <param name="y">Координата, на которую пытаемся передвинуть игрока </param>
        /// <returns></returns>
        public void MoveCamera(Player player, int x, int y)
        {
            /**Двигаем камеру + проверки
             * 1) Размеры карты, мы здесь мы их знаеа
             * 2) Координаты камеры (они в камере), (камера в игроке)
             * 3) Вопрос? Кто и где вычилсляет проверки с камерой
             * 
             * TODO изменить координаты камеры(игрок двигается), проверить пересекается ли границы камеры и карты
             *      
             * В СЛЕДУЮЩИЙ РАЗ:
                ПРОВЕРКИ
                ПРОБЛЕМА С +1\-1 С КАРТОЙ (ВРЕЗАЕМСЯ В ТРАВУ)
             * **/

            if (x >= Height - 1 || y >= Width - 1) return;

            if (player.Camera.X == Width || player.Camera.Y == Height) return;
           
            // TODO Сделать сетер вместо вот этого SetStartX
            player.Camera.X = player.Camera.GetStartX(x);
            player.Camera.Y = player.Camera.GetStartY(y);

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
            if (x > Width || y > Height || x < 0 || y < 0) { return false; } 

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
