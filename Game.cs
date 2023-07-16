using lampbearer.Actor;
using lampbearer.Console;
using lampbearer.Drawing;
using lampbearer.Map;
using lampbearer.Systems;
using lampbearer.Utils;
using System.Drawing;

namespace lampbearer;
class Game
{
    public static Map.Map Map { get; private set; }
    public static Player Player { get; private set; }

    static void Main(string[] args)
    {

        Window mapWindow = new(0, 0, 40, 20, true);
        Player = new Player();

        FileMapGenerator mapGenerator = new();
        Map = mapGenerator.GenerateMap();

        Map.Draw(Player, mapWindow);
        ConsoleKey key;
        do
        {
            key = ConsoleManager.getKey();
            handleMovement(Player, key);
            Map.Draw(Player, mapWindow);
            ConsoleDrawer.Draw(41, 1, $"Player x:{Player.X}, y:{Player.Y}");

        } while (key != ConsoleKey.Escape);


    }

    private static void handleMovement(Player player, ConsoleKey key)
    {
        if (key == ConsoleKey.W)
        {
            CommandSystem.MovePlayer(player, Direction.UP);
        }
        else if (key == ConsoleKey.S)
        {
            CommandSystem.MovePlayer(player, Direction.DOWN);
        }
        else if (key == ConsoleKey.A)
        {
            CommandSystem.MovePlayer(player, Direction.LEFT);
        }
        else if (key == ConsoleKey.D)
        {
            CommandSystem.MovePlayer(player, Direction.RIGHT);
        }
    }
}

