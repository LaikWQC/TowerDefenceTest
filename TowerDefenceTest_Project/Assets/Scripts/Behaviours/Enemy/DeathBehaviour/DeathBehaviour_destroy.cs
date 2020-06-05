using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour_destroy : IEnemyBehaviour
{
    private IEnemy enemy;

    public DeathBehaviour_destroy(IEnemy enemy)
    {
        this.enemy = enemy;
    }

    public void StartBehaviour()
    {
        enemy.Destroy();
    }

    public void UpdateBehaviour()
    {
        
    }
}
