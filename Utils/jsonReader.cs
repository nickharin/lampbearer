using System;
using System.IO;
using System.Resources;
using lampbearer.Utils;
using Newtonsoft.Json;
namespace lampbearer.Utils
{
	public static class JsonReader
    {
		private readonly static string _path = "./Resources/cellConfig.json";

        public static Dictionary<string, CellConfigProperty> ParseJson()
		{
			StreamReader sr = new StreamReader(_path);
			string str = sr.ReadToEnd();
			var config = JsonConvert.DeserializeObject<Dictionary<string, CellConfigProperty>>(str);
            if (config == null)
			{
				throw new Exception($"Cannot parse property, path {_path}");
			}

			return config;
        }
	}
}

