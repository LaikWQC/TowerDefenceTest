using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachBehaviour_destroy : IEnemyBehaviour
{
    private IEnemy enemy;

    public ReachBehaviour_destroy(IEnemy enemy)
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
