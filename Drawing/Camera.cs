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
				Height = 6,
				Width = 6
			};
        }

        /// <summary>
        /// Считает x-координату правого верхнего угола области камеры на основе координаты персонажа
        /// </summary>
        /// <param name="x">Координата персонажа на которго смотрит камера</param>
        /// <returns></returns>
        internal int getEndX(int x)
        {
			return x + Width/2;
        }

        internal int getEndY(int y)
        {
			return y + Height/2;
        }
		
		/// <summary>
		/// Считает x-координату левого верхнего угола области камеры на основе координаты персонажа
		/// </summary>
		/// <param name="x">Координата персонажа на которго смотрит камера</param>
		/// <returns></returns>
        internal int getStartX(int x)
        {
			return x - Width/2;
        }

        internal int getStartY(int y)
        {
			return y - Height/2;
        }
    }
}
