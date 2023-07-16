using RogueSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lampbearer.Utils;
using System.Drawing;

namespace lampbearer.Map
{
    internal class FileMapGenerator : IMapGenerator
    {
        private static readonly String _path = "./Resources/map.txt";

        public Map GenerateMap()
        {
            var symbolToConfig = JsonReader.ParseJson();
            var mapConfig = FileMapGenerator.ReadMapFile();

            Map map = new Map();
            map.Initialize(mapConfig[0].Length, mapConfig.Count);
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    CellConfigProperty cellConfigProperty =
                        GetCellConfigProperty(symbolToConfig, mapConfig[y][x]);
                    map.SetCellProperties(x, y, cellConfigProperty.Transparent,
                        cellConfigProperty.Walkable, getColor(cellConfigProperty.Color),
                        cellConfigProperty.Symbol);
                }

            }

            return map;
        }

        private Color getColor(string color)
        {
            return Color.FromName(color);
        }

        public CellConfigProperty GetCellConfigProperty(
            Dictionary<string, CellConfigProperty> symbolToConfig, char mapConfigSymbol)
        {
            return symbolToConfig[mapConfigSymbol.ToString()];
        }

        private static List<string> ReadMapFile()
        {
            List<string> result = new List<string>();

            StreamReader sr = new StreamReader(_path);
            string str = sr.ReadToEnd();

            foreach(var row in str.Split('\n'))
            {
                result.Add(row);

            }
            return result;
        }
    }
}
