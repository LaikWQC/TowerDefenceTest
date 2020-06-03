using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject rangeImage;

    float range;
    float damage;
    float attackSpeed;

    float attackDelay;
    float nextAttackTime;
    IEnemy target;

    void Start()
    {
        range = DefaultValues.I.towerRange;
        damage = DefaultValues.I.towerDamage;
        attackSpeed = DefaultValues.I.towerAttackSpeed;

        rangeImage.SetActive(false);
        rangeImage.transform.localScale = new Vector3(2 * range, 2 * range);

        attackDelay = 1 / attackSpeed;
    }

    
    void Update()
    {
        Attack();
    }

    IEnemy FindTarget()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, range);

        IEnemy closestEnemy = null;
        float minDistance = 0;
        foreach(var collider in colliders)
        {
            var enemy = collider.GetComponent<IEnemy>();
            if (enemy != null)
            {
                if(closestEnemy == null)
                {
                    closestEnemy = enemy;
                    minDistance = Vector2.Distance(enemy.Position, transform.position);
                }
                else
                {
                    var distance = Vector2.Distance(enemy.Position, transform.position);
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

    void Attack()
    {
        if (nextAttackTime <= Time.time)
        {
            target = FindTarget();
            if (target!=null)
            {
                target.TakeDamage(damage);
                nextAttackTime = Time.time + attackDelay;
            }
        }        
    }
}
