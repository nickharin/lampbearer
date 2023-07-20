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

		public int Y
		{
			get { return _y; }
			set { _y = value; }
		}

		public int X
		{
			get { return _x; }
			set { _x = value; }
		}

		public int Height
		{
			get { return _height; }
			set { _height = value; }
		}

		public int Width
        {
			get { return _width; }
			set { _width = value; }
		}


		public static Camera Default()
		{
			return new Camera
			{
				Height = 10,
				Width = 10
			};
        }

        /// <summary>
        /// Считает x-координату правого верхнего угола области камеры на основе координаты камеры
        /// </summary>
        /// <returns></returns>
        internal int GetEndX()
        {
			return X + Width;
        }

        internal int GetEndY()
        {
			return Y + Height;
        }




		
		/// <summary>
		/// Считает x-координату левого верхнего угола области камеры на основе координаты персонажа
		/// </summary>
		/// <param name="x">Координата персонажа на которго смотрит камера</param>
		/// <returns></returns>
        internal int GetStartX(int x)
        {
			return x - Width/2;
        }

        internal int GetStartY(int y)
        {
			return y - Height/2;
        }

        internal int GetInCameraX(Player player)
        {
            return player.X - GetStartX(player.X);
        }

        internal int GetInCameraY(Player player)
        {
            return player.Y - GetStartY(player.Y);
        }



    }
}
