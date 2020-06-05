using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReachBehaviourFactory
{
    public static IEnemyBehaviour GetBehaviour(IMovement enemy)
    {
        IEnemyBehaviour behaviour = new ReachBehaviour_destroy(enemy);
        behaviour.StartBehaviour();
        return behaviour;
    }
}
