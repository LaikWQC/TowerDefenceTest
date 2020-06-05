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
    IFindTargetBehaviour findBh;

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
        findBh = FindTargetBehaviourFactory.GetBehaviour();
    }
    
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (nextAttackTime <= Time.time)
        {
            if(lookForBh.IsChangeTargetNeeded(this, target))
            {
                target = findBh.FindTarget(this);
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
