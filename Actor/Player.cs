using lampbearer.Drawing;
using RogueSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Actor
{
    public class Player : IActor, IDrawable
    {
        private int _x = 15;
        private int _y = 15;
        private Color _color = Color.Yellow;
        private char _symbol = '@';
        private string _name;
        private Camera _camera = Camera.Default();

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Camera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }


        public string Name { get { return _name; } set { _name = value; } }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public Color Color { get => _color; set => _color = value; }
        public char Symbol{ get => _symbol; set => _symbol = value; }

        public void Draw(IMap map)
        {
            throw new NotImplementedException();
        }
    }
}
