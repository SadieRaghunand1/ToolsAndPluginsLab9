using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyBuilder 
{
    Enemy GetEnemy();
    IEnemyBuilder SetShip();

    IEnemyBuilder Speed();
    IEnemyBuilder PointValue();
    IEnemyBuilder SetColor(Color color);
    IEnemyBuilder SetScale(float scale);

}
