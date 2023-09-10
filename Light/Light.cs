using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Light
{
    public class Light
    {
		private int _x;
		private int _y;
		private Color _color;
		private LightType _lightType;
		private int _intencity;
		private int _duration;

		public int Duration
		{
			get { return _duration; }
			set { _duration = value; }
		}


		public int Intencity
		{
			get { return _intencity; }
			set { _intencity = value; }
		}


		public LightType LightType
		{
			get { return _lightType; }
			set { _lightType = value; }
		}


		public Color Color
		{
			get { return _color; }
			set { _color = value; }
		}


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


        public static Light DefaultCircle(int x, int y)
        {
			return DefaultCircle(x, y, Color.LightSlateGray);
        }


        public static Light DefaultCircle(int x, int y, Color color)
        {
            return DefaultCircle(x, y, 5, Color.LightSlateGray);
        }


        public static Light DefaultCircle(int x, int y, int intencity, Color color)
        {
            return new Light
            {
                Color = color,
                Duration = -1,
                Intencity = intencity,
                X = x,
                Y = y,
                LightType = LightType.CIRCLE
            };
        }
    }
}
