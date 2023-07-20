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
        private static readonly String[] delims = new[] { "\r\n", "\r", "\n" };

        public Map GenerateMap()
        {
            var symbolToConfig = JsonReader.ParseJson();
            var mapConfig = FileMapGenerator.ReadMapFile();

            Map map = new Map();
            map.Initialize(GetWidth(mapConfig), GetHeight(mapConfig));
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

        private static int GetHeight(List<string> mapConfig)
        {
            return mapConfig.Count;
        }

        private static int GetWidth(List<string> mapConfig)
        {
            return mapConfig[0].Length;
        }

        private static Color getColor(string color)
        {
            return Color.FromName(color);
        }

        public static CellConfigProperty GetCellConfigProperty(
            Dictionary<string, CellConfigProperty> symbolToConfig, char mapConfigSymbol)
        {
            if (!symbolToConfig.ContainsKey(mapConfigSymbol.ToString()))
            {
                CellConfigProperty cellConfigProperty = new();
                cellConfigProperty.Symbol = '!';
                cellConfigProperty.Color = Color.Red.ToString();
                return cellConfigProperty;
            }

            return symbolToConfig[mapConfigSymbol.ToString()];
        }

        private static List<string> ReadMapFile()
        {
            List<string> result = new List<string>();

            //TODO: сделать чтение без специальных симоволов, чтобы не зависить от ОС
            StreamReader sr = new StreamReader(_path);
            string str = sr.ReadToEnd();
            foreach (var row in str.Split(delims, StringSplitOptions.RemoveEmptyEntries))
            {
                result.Add(row);

            }
            return result;
        }
    }
}
