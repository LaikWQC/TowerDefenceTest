using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetBehaviour_closest : IFindTargetBehaviour
{
    public ITarget FindTarget(ITower tower)
    {
        var colliders = Physics2D.OverlapCircleAll(tower.Position, tower.Range);

        ITarget closestEnemy = null;
        float minDistance = 0;
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<ITarget>();
            if (enemy != null)
            {
                if (closestEnemy == null)
                {
                    closestEnemy = enemy;
                    minDistance = Vector2.Distance(enemy.Position, tower.Position);
                }
                else
                {
                    var distance = Vector2.Distance(enemy.Position, tower.Position);
                    if (distance < minDistance)
                    {
                        closestEnemy = enemy;
                        minDistance = distance;
                    }
                }
            }
        }
        return closestEnemy;
    }
}
