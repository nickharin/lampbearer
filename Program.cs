using lampbearer.Utils;
using System.Drawing;

namespace lampbearer;
class Program
{
    static void Main(string[] args)
    {
        ConsoleManager consoleManager = new ConsoleManager();
        Random r = new Random();
       
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (r.NextSingle() > 0.2f)
                {
                    consoleManager.Draw(i, j, '#', Color.Gray);
                }
                else
                {
                    consoleManager.Draw(i, j, '.', Color.Red );
                }
            }
        }

    }
}

