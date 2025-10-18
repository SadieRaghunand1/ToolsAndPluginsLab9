using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallShips : IEnemyBuilder
{
    private Enemy enemy = new Enemy();

    public Enemy GetEnemy()
    {
        return enemy;
    } 

    public IEnemyBuilder SetShip()
    {
        enemy.Ship = "Small Enemy";
        return this;
    }

    public IEnemyBuilder Speed()
    {
        enemy.Speed = 3;
        return this;
    }


    public IEnemyBuilder PointValue()
    {
        enemy.Points = 4;
        return this;
    }

    public IEnemyBuilder Setall()
    {
       
        Speed();
        PointValue();
        return this;

    }

}
