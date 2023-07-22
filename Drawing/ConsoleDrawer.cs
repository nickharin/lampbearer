using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lampbearer.Utils;

namespace lampbearer.Drawing
{
    internal static class ConsoleDrawer
    {

        public static void ConfigureConsole()
        {
            System.Console.CursorVisible = false;
        }

        public static void Draw(int x, int y, char symbol, Color color, Color bgColor)
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.ForegroundColor = ColorMapper.toConsoleColor(color);
            System.Console.BackgroundColor = ColorMapper.toConsoleColor(bgColor);
            System.Console.Write(symbol);
            //System.Console.ResetColor();
            //Thread.Sleep(1);
        }

        public static void Draw(int x, int y, char symbol, Color color)
        {
            Draw(x, y, symbol, color, Color.Black);
        }

        internal static void Draw(int x, int y, char symbol)
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(symbol);
        }

        internal static void Draw(int x, int y, string str)
        {
            System.Console.SetCursorPosition(x, y);
            System.Console.Write(str);
        }

    }
}
