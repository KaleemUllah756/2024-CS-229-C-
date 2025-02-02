using System.Collections.Generic;
using System.Threading;
using System;

class Enemy : GameObject
{
    private static Random rand = new Random();

    public Enemy(int x, int y) : base('E', x, y) { }

    public void MoveRandomly()
    {
        {
            int newX = X + rand.Next(-1, 2);
            int newY = Y + rand.Next(-1, 2);
            if (Game.IsWalkable(newX, newY))
            {
                X = newX;
                Y = newY;
            }
        }

    }
}