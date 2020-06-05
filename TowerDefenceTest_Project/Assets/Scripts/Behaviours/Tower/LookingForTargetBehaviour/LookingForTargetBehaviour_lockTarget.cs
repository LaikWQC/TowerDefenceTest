using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForTargetBehaviour_lockTarget : ILookingForTargetBehaviour
{
    public bool IsChangeTargetNeeded(ITower tower, ITarget enemy)
    {
        if (enemy == null || !enemy.IsAlive) return true;
        //TODO это расстояние до центра цели, а нас интересует расстояние до ее коллайдера
        var distance = Vector2.Distance(enemy.Position, tower.Position);
        return (distance > tower.Range);
    }
}
