using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReachBehaviourFactory
{
    public static IEnemyBehaviour GetBehaviour(IEnemy enemy)
    {
        IEnemyBehaviour behaviour = new ReachBehaviour_destroy(enemy);
        behaviour.StartBehaviour();
        return behaviour;
    }
}
