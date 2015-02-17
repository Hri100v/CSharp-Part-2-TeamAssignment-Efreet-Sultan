using System;
using System.Text;

public abstract class GameObject
{
    private string[] symbol;
    public GameObject(int x, int y, string[] symbol, ConsoleColor color)
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

    public string[] Symbol
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
        Console.Write(this.ToString());
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        foreach (var symbol in this.Symbol)
        {
            result.AppendLine(symbol);
        }

        return result.ToString();
    }
}