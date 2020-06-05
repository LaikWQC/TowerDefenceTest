using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DeathBehaviourFactory
{
    public static IEnemyBehaviour GetBehaviour(IEnemy enemy)
    {
        IEnemyBehaviour behaviour = new DeathBehaviour_destroy(enemy);
        behaviour.StartBehaviour();
        return behaviour;
    }
}
