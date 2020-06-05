using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementBehaviourFactory
{
    public static IEnemyBehaviour GetBehaviour(IMovement enemy)
    {
        IEnemyBehaviour behaviour; 
        
        behaviour = new MovementBehaviour_waypoints(enemy);
        
        behaviour.StartBehaviour();
        return behaviour;
    }
}
