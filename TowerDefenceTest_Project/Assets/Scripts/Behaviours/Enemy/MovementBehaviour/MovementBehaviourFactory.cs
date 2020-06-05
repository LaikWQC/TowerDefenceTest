using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementBehaviourFactory
{
    public static IEnemyBehaviour GetBehaviour(IEnemy enemy)
    {
        IEnemyBehaviour behaviour = new MovementBehaviour_waypoints(enemy);
        behaviour.StartBehaviour();
        return behaviour;
    }
}
