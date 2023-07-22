using lampbearer.Actor;
using lampbearer.Drawing;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    public class Map : RogueSharp.Map
    {

        private List<Light.Light> _lights = new List<Light.Light>();

        public List<Light.Light> Lights
        {
            get { return _lights; }
            set { _lights = value; }
        }

        private Color[,] _color;
        private char[,] _symbol;
        private FieldOfView _fieldOfView;
        private readonly Color DEFAULT_NON_LIGHT_COLOR = Color.DarkGray;

        public new void Initialize(int width, int height)
        { 
            _color = new Color[width, height];
            _symbol = new char[width, height];
            _fieldOfView = new FieldOfView(this);
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

        public void Draw(Camera camera, Window window)
        {
            ConsoleDrawer.Draw(41, 2, $"Camera x0:{camera.X}, y0:{camera.Y}");
            ConsoleDrawer.Draw(41, 3, $"Camera x1:{camera.GetCameraEndX()}, y1:{camera.GetCameraEndY()}");
            //TODO: Весь этот код и код отрисовки в карте сосет жопу все через костыли, надо переделать
            int wY = 0, wX = 0;
            for (int y = camera.Y; y < camera.GetCameraEndY(); y++)
            {
                for (int x = camera.X; x < camera.GetCameraEndX(); x++)
                {
                    //ТО что в свете, не нужно отрисовывать. потому что оно отрисуется при отрисовке света
                    if (isNotInLight(y, x))
                    {
                        window.Draw(wX, wY, GetCell(x, y), DEFAULT_NON_LIGHT_COLOR);
                    }
                    wX++;
                }
                wX = 0;
               wY++;
            }
        }

        private bool isNotInLight(int y, int x)
        {
            return !_fieldOfView.IsInFov(x, y);
        }

        internal void DrawActor(Player player, Window window)
        {
            Camera camera = player.Camera;
            window.Draw(camera.GetInCameraX(player.X), camera.GetInCameraY(player.Y), player);
        }

        public void DrawLight(Camera camera, Window window)
        {
            foreach(var light in Lights)
            {
                foreach(var cell in GetCellsForLight(light))
                {
                    //TODO: -1 - Временный костыль, у игрока не надо вычитать, а тут почему-то надо... разобраться
                    window.Draw(camera.GetInCameraX(cell.X - 1), camera.GetInCameraY(cell.Y - 1), GetCell(cell.X, cell.Y), light);
                }
            }
        }

        private IEnumerable<ICell> GetCellsForLight(Light.Light light)
        {
            if(light.LightType == Light.LightType.CIRCLE)
            {
                return _fieldOfView.ComputeFov(light.X, light.Y, light.Intencity);
            }


            return _fieldOfView.ComputeFov(light.X, light.Y, light.Intencity);
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

             * **/

            // TODO Сделать сетер вместо вот этого SetStartX
            if (player.Camera.CanMoveCameraX(player, Width))
            { 
                player.Camera.X = player.Camera.CalculateStartX(x);
            }
            if (player.Camera.CanMoveCameraY(player, Height))
            {
                player.Camera.Y = player.Camera.CalculateStartY(y);
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
            if (x >= Width || y >= Height || x < 0 || y < 0) { return false; } 

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
