using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject rangeImage;

    float attackDelay;
    float nextAttackTime;
    ITarget target;
    ILookingForTargetBehaviour lookForBh;

    void Start()
    {
        rangeImage.SetActive(false);
        Setup();
    }

    public void Setup()
    {
        Range = DefaultValues.I.towerRange;
        Damage = DefaultValues.I.towerDamage;
        AttackSpeed = DefaultValues.I.towerAttackSpeed;
        UpgradeList = UpgradeFactory.GetUpgrades(this);
        lookForBh = LookingForTargetBehaviourFactory.GetBehaviour();
    }
    
    void Update()
    {
        Attack();
    }

    ITarget FindTarget()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, Range);

        ITarget closestEnemy = null;
        float minDistance = 0;
        foreach(var collider in colliders)
        {
            var enemy = collider.GetComponent<ITarget>();
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
            if(lookForBh.IsChangeTargetNeeded(this, target))
            {
                target = FindTarget();
            }            
            if (target!=null)
            {
                target.TakeDamage(Damage);
                nextAttackTime = Time.time + attackDelay;
            }
        }        
    }

    public bool Selected
    {
        set
        {
            rangeImage.SetActive(value);
        }
    }

    private float range;
    public float Range 
    {
        get => range;
        set
        {
            range = value;
            rangeImage.transform.localScale = new Vector3(2 * Range, 2 * Range);
        }
    }

    public float Damage { get; set; }

    private float attackSpeed;
    public float AttackSpeed 
    {
        get => attackSpeed;
        set
        {
            attackSpeed = value;
            attackDelay = 1 / AttackSpeed;
        }
    }

    public List<Upgrade> UpgradeList { get; set; }
}
