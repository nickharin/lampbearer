using lampbearer.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lampbearer.Systems
{
    public static class CommandSystem
    {
        public static bool MovePlayer(Player player, Direction direction)
        {
            int x = player.X;
            int y = player.Y;

            switch (direction)
            {
                case Direction.UP:
                    {
                        y = Game.Player.Y - 1;
                        break;
                    }
                case Direction.DOWN:
                    {
                        y = Game.Player.Y + 1;
                        break;
                    }
                case Direction.LEFT:
                    {
                        x = Game.Player.X - 1;
                        break;
                    }
                case Direction.RIGHT:
                    {
                        x = Game.Player.X + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            Game.Map.MoveCamera(Game.Player, x, y);

            if (Game.Map.SetActorPosition(Game.Player, x, y))
            {
                return true;
            }

            return true;
        }

    }
}
