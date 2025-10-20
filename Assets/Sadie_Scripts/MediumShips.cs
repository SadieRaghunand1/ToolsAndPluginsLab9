using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumShips : IEnemyBuilder
{
    private Enemy enemy = new Enemy();

    public Enemy GetEnemy()
    {
        return enemy;
    }

    public IEnemyBuilder SetShip()
    {
        enemy.Ship = "Medium Enemy";
        return this;
    }

    public IEnemyBuilder Speed()
    {
        enemy.Speed = 2;
        return this;
    }


    public IEnemyBuilder PointValue()
    {
        enemy.Points = 3;
        return this;
    }
    public IEnemyBuilder SetColor(Color color)
    {
        enemy.Color = color;
        return this;
    }

    public IEnemyBuilder SetScale(float scale)
    {
        enemy.Scale = scale;
        return this;
    }

}
