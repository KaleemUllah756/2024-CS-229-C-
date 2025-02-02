
using System;

class GameObject
{
   public char Symbol { get;set;}
   public int X { get;set;}
    public int Y { get;set;}

    public GameObject(char symbol, int x, int y)
    {
      Symbol = symbol;
        X = x;
        Y = y;
    }

    public void Display()
    {
         Console.SetCursorPosition(X, Y);
        Console.Write(Symbol);
    }
}
