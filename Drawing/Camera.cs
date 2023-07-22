using lampbearer.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Drawing
{
    public class Camera
    {
		private int _width;
		private int _height;
		private int _x;
		private int _y;

        /// <summary>
        /// Координата левого верхнего угла камеры
        /// </summary>
        public int Y
		{
			get { return _y; }
			set { _y = value; }
		}

		/// <summary>
		/// Координата левого верхнего угла камеры
		/// </summary>
		public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		public int Height
		{
			get { return _height; }
		}

		public int Width
        {
			get { return _width; }
		}


		public static Camera Default()
		{
			return new Camera
			{
				_height = 25,
				_width = 30,
				X = 0,
				Y = 0
			};
        }

        /// <summary>
        /// Считает x-координату правого верхнего угола области камеры на основе координаты камеры
        /// </summary>
        /// <returns></returns>
        internal int GetCameraEndX()
        {
			return X + Width;
        }

        internal int GetCameraEndY()
        {
			return Y + Height;
        }



        /// <summary>
        /// Считает x-координату левого верхнего угла области камеры на основе координаты персонажа
        /// </summary>
        /// <param name="x">Координата персонажа на которго смотрит камера</param>
        /// <returns></returns>
        internal int CalculateStartX(int x)
        {
            return x - Width / 2;
        }

        internal int CalculateStartY(int y)
        {
            return y - Height / 2;
        }

        internal int CalculateEndX(int x)
        {
            return x + Width / 2;
        }

        internal int CalculateEndY(int y)
        {
            return y + Height / 2;
        }

        internal int GetInCameraX(int x)
        {
            return x - X + 1;
        }

        internal int GetInCameraY(int y)
        {
            return y - Y + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        internal bool CanMoveCameraX(Player player, int width)
        {
            return CalculateStartX(player.X) >= 0 && CalculateEndX(player.X) < width;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        internal bool CanMoveCameraY(Player player, int height)
        {
            return CalculateStartY(player.Y) >= 0 && CalculateEndY(player.Y) < height;
        }
    }
}
