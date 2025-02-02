using System.Collections.Generic;
using System.Threading;
using System;

class Game
{
    static char[][] maze =
    {
                "############################".ToCharArray(),
                "#         #       #        #".ToCharArray(),
                "# ### ### # ##### # ## ### #".ToCharArray(),
                "#       # #     # #      # #".ToCharArray(),
                "##### # ##### # # ### ## # #".ToCharArray(),
                "#     #       # #        # #".ToCharArray(),
                "# # ######### # ########## #".ToCharArray(),
                "#            #            #".ToCharArray(), // Fixed row length
                "############################".ToCharArray()
    };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        

        Player player = new Player(1, 1);
        List<Enemy> enemies = new List<Enemy>
        {
            new Enemy(5, 5),
            new Enemy(15, 5),
            new Enemy(5, 7),
            new Enemy(20, 6)
        };
        DrawMaze();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                player.Move(keyInfo.Key);
            }

            foreach (var enemy in enemies)
            {
                enemy.MoveRandomly();
            }

            Console.Clear();
            DrawMaze();
            player.Display();
            foreach (var enemy in enemies)
            {
                enemy.Display();
            }

            Thread.Sleep(60);
        }
    }
    static void DrawMaze()
    {
        for (int y = 0; y < maze.Length && y < Console.WindowHeight; y++)
        {
            for (int x = 0; x < maze[y].Length && x < Console.WindowWidth; x++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(maze[y][x]);
            }
        }
    }

    public static bool IsWalkable(int x, int y)
    {
        if (y < 0 || y >= maze.Length || x < 0 || x >= maze[y].Length)
            return false;
        return maze[y][x] == ' ';
    }
}