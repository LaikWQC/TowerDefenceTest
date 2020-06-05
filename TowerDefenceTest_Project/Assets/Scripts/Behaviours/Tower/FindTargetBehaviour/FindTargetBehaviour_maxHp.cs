using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTargetBehaviour_maxHp : IFindTargetBehaviour
{
    public ITarget FindTarget(Tower tower)
    {
        var colliders = Physics2D.OverlapCircleAll(tower.transform.position, tower.Range);

        ITarget maxHpEnemy = null;
        float maxHp = 0;
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<ITarget>();
            if (enemy != null)
            {
                if (maxHpEnemy == null)
                {
                    maxHpEnemy = enemy;
                    maxHp = enemy.CurrentHp;
                }
                else
                {
                    if(enemy.CurrentHp > maxHp)
                    {
                        maxHpEnemy = enemy;
                        maxHp = enemy.CurrentHp;
                    }
                }
            }
        }
        return maxHpEnemy;
    }
}
