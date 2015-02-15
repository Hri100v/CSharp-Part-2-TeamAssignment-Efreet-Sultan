using System;

class EnemyShootingShip : GameObject, IShooter
{
    public EnemyShootingShip(int x, int y, string symbol, ConsoleColor color) :base(x, y, symbol, color)
    {
    }

    public void Shoot()
    {
        // TODO:
    }
}