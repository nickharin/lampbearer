using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Utils
{
    internal static class ConsoleDrawer
    {
        public static void Draw(int x, int y, char symbol, Color color, Color bgColor)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ColorMapper.toConsoleColor(color);
            Console.BackgroundColor = ColorMapper.toConsoleColor(bgColor);
            Console.Write(symbol);
            Console.ResetColor();
        }

        public static void Draw(int x, int y, char symbol, Color color)
        {
            Draw(x, y, symbol, color, Color.Black);
        }
    }
}
