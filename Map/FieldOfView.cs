using RogueSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Map
{
    internal class FieldOfView
    {
        private enum Quadrant
        {
            NE = 1,
            SE,
            SW,
            NW
        }

        private readonly IMap _map;

        private readonly HashSet<int> _inFov;

        public FieldOfView(IMap map)
        {
            _map = map;
            _inFov = new HashSet<int>();
        }

        internal FieldOfView(IMap map, HashSet<int> inFov)
        {
            _map = map;
            _inFov = inFov;
        }

        public FieldOfView Clone()
        {
            HashSet<int> hashSet = new HashSet<int>();
            foreach (int item in _inFov)
            {
                hashSet.Add(item);
            }

            return new FieldOfView(_map, hashSet);
        }

        public bool IsInFov(int x, int y)
        {
            return _inFov.Contains(_map.IndexFor(x, y));
        }

        public ReadOnlyCollection<ICell> ComputeFov(int xOrigin, int yOrigin, int radius)
        {
            //ClearFov();
            return AppendFov(xOrigin, yOrigin, radius);
        }

        public ReadOnlyCollection<ICell> AppendFov(int xOrigin, int yOrigin, int radius)
        {
            foreach (ICell item in _map.GetBorderCellsInCircle(xOrigin, yOrigin, radius))
            {
                foreach (ICell item2 in _map.GetCellsAlongLine(xOrigin, yOrigin, item.X, item.Y))
                {
                    //if (Math.Abs(item2.X - xOrigin) + Math.Abs(item2.Y - yOrigin) > radius)
                    //{
                    //    break;
                    //}

                    _inFov.Add(_map.IndexFor(item2));
                    if (item2.IsTransparent)
                    {
                        continue;
                    }

                    break;
                }
            }

            return CellsInFov();
        }

        private ReadOnlyCollection<ICell> CellsInFov()
        {
            List<ICell> list = new List<ICell>();
            foreach (int item in _inFov)
            {
                list.Add(_map.CellFor(item));
            }

            return new ReadOnlyCollection<ICell>(list);
        }

        private void ClearFov()
        {
            _inFov.Clear();
        }

    }
}
