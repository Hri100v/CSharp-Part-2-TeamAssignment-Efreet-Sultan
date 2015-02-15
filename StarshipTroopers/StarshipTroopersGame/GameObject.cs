using System;

public abstract class GameObject
{
    public GameObject(int x, int y, string symbol, ConsoleColor color)
    {
        this.X = x;
        this.Y = y;
        this.Symbol = symbol;
        this.Color = color;
    }

    public int X
    {
        get;
        set;
    }

    public int Y
    {
        get;
        set;
    }

    public string Symbol
    {
        get;
        set;
    }

    public ConsoleColor Color
    {
        get;
        set;
    }

    public virtual void Draw()
    {
        Console.SetCursorPosition(this.X, this.Y);
        Console.ForegroundColor = this.Color;
        Console.Write(this.Symbol);
    }
}