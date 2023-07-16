using lampbearer.Map;
using lampbearer.Utils;
using System.Drawing;

namespace lampbearer;
class Program
{
    static void Main(string[] args)
    {
        Random r = new Random();

        FileMapGenerator mapGenerator = new FileMapGenerator();
        var map = mapGenerator.GenerateMap();
        map.Draw();
        Console.WriteLine("END@!!!!");
    }
}

