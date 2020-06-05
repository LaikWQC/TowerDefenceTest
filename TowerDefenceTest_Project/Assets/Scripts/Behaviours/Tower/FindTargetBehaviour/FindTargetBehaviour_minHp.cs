using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetBehaviour_minHp : IFindTargetBehaviour
{
    public ITarget FindTarget(Tower tower)
    {
        var colliders = Physics2D.OverlapCircleAll(tower.transform.position, tower.Range);

        ITarget minHpEnemy = null;
        float minHp = 0;
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<ITarget>();
            if (enemy != null)
            {
                if (minHpEnemy == null)
                {
                    minHpEnemy = enemy;
                    minHp = enemy.CurrentHp;
                }
                else
                {
                    if (enemy.CurrentHp < minHp)
                    {
                        minHpEnemy = enemy;
                        minHp = enemy.CurrentHp;
                    }
                }
            }
        }
        return minHpEnemy;
    }
}
