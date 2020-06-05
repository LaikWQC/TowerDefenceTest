using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBehaviour_destroy : IEnemyBehaviour
{
    private IMovement enemy;

    public DeathBehaviour_destroy(IMovement enemy)
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
