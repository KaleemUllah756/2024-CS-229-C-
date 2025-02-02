using System.Collections.Generic;
using System.Threading;
using System;

class Player : GameObject
{
    public Player(int x, int y) : base('P', x, y) { }

    public void Move(ConsoleKey key)
    {
        int newX = X, newY = Y;
        switch (key)
        {
            case ConsoleKey.UpArrow: newY--; break;
            case ConsoleKey.DownArrow: newY++; break;
            case ConsoleKey.LeftArrow: newX--; break;
            case ConsoleKey.RightArrow: newX++; break;
        }
        if (Game.IsWalkable(newX, newY))
        {
            X = newX;
            Y = newY;
        }
    }
}