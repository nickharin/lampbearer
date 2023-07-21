using lampbearer.Actor;
using lampbearer.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer
{
    public class Window
    {
        public Window(int x, int y, int width, int height, bool withBorder)
        {
            X = x;
            Y = y;
            Width = width + (withBorder ? 1 : 0);
            Height = height + (withBorder ? 1 : 0);
            WithBorder = withBorder;
            if (WithBorder) { 
                DrawBorder();
            }
        }

        private int _x;
		private int _y;
		private int _width;
		private int _height;
        private Color _borderColor = Color.DarkGray;
        private char _borderSymbol = '+';
        private bool _withBorder;

        public bool WithBorder
        {
            get { return _withBorder; }
            set { _withBorder = value; }
        }


        public char BorderSymbol
        {
            get { return _borderSymbol; }
            set { _borderSymbol = value; }
        }


        public Color BorderColor
        {
            get { return _borderColor; }
            set { _borderColor = value; }
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

		private int X { get { return _x; } set { _x = value; } }
		private int Y { get { return _y; } set { _y = value; } }

        public int windowXLeftBorder { get => WithBorder ? X + 1: X; }
        public int windowXRightBorder { get => WithBorder ? X + Width - 1 : X + Width; }
        public int windowYTopBorder { get => WithBorder ? Y + 1 : Y; }
        public int windowYBottomBorder { get => WithBorder ? Y  + Height - 1 : Y + Height; }

        public void DrawBorder()
        {
            for (int y = Y; y <= Y + Height; y++)
            {
                ConsoleDrawer.Draw(X, y, BorderSymbol, BorderColor);
                ConsoleDrawer.Draw(X + Width, y, BorderSymbol, BorderColor);
            }
            for (int x = X; x <= X + Width; x++)
            {
                ConsoleDrawer.Draw(x, Y, BorderSymbol, BorderColor);
                ConsoleDrawer.Draw(x, Y + Height, BorderSymbol, BorderColor);
            }
        }

        public void Draw(int x, int y, Map.Cell cell)
        {
            x = getWindowX(x);
            y = getWindowY(y);

            if (x < windowXLeftBorder || x > windowXRightBorder) return;
            if (y < windowYTopBorder || y > windowYBottomBorder) return;

            ConsoleDrawer.Draw(x, y, cell.Symbol, cell.Color);
        }

        internal void Draw(IActor actor)
        {
            int x = getWindowX(actor.X - 1);
            int y = getWindowY(actor.Y - 1);

            if (x < windowXLeftBorder || x > windowXRightBorder) return;
            if (y < windowYTopBorder || y > windowYBottomBorder) return;

            ConsoleDrawer.Draw(x, y, actor.Symbol, actor.Color); 
        }

        internal void Draw(int x, int y, IActor actor)
        {

            if (x < windowXLeftBorder || x > windowXRightBorder) return;
            if (y < windowYTopBorder || y > windowYBottomBorder) return;

            ConsoleDrawer.Draw(x, y, actor.Symbol, actor.Color);
        }


        /// <summary>
        /// Возвращает координаты учитывая особенности окна (ширину\высоту, границу)
        /// </summary>
        /// <param name="x">Координата на консоли, </param>
        /// <returns></returns>
        private int getWindowX(int x)
        {
            return WithBorder ? X + x + 1 : X + x;
        }


        /// <summary>
        /// Возвращает координаты учитывая особенности окна (ширину\высоту, границу)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int getWindowY(int y)
        {
            return WithBorder ? Y + y + 1: Y + y;
        }
    }
}
