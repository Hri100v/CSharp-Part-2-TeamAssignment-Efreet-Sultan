using System;

public class PlayerShip : GameObject, IShooter

{
    public PlayerShip(int x, int y, string[] symbol, ConsoleColor color) : base(x, y, symbol, color)
    {

    }

    public int Lives
    {
        get;
        set;
    }

    public void Shoot()
    {
        // TODO:
    }
}