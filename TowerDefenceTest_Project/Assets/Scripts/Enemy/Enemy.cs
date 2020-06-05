using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy, ITarget, IMovement
{
    [SerializeField] private HpBar hpBar;
        
    private float speed;
    private int maxHp;
    private float currentHp;
    private int damage;
    private int gold;
    private bool isAlive;

    private IEnemyBehaviour behaviour;
    private IShowDamageBehavior showDamageBh;

    void Start()
    {
        behaviour = MovementBehaviourFactory.GetBehaviour(this);
        showDamageBh = ShowDamageBehaviorFactory.GetBehavior();
        isAlive = true;
    }

    public void Setup(EnemyDummy dummy)
    {
        speed = dummy.Speed;
        maxHp = dummy.MaxHp;
        currentHp = maxHp;
        damage = dummy.Damage;
        gold = dummy.Gold;
    }

    void Update()
    {
        behaviour.UpdateBehaviour();        
    }

    public void EndPointReached()
    {
        ResourcesManager.I.TakeDamage(damage);
        isAlive = false;
        behaviour = ReachBehaviourFactory.GetBehaviour(this);
    }

    private void Die()
    {
        ResourcesManager.I.AddGold(gold);
        GameManager.I.AddScore();
        isAlive = false;
        behaviour = DeathBehaviourFactory.GetBehaviour(this);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        showDamageBh.ShowDamage(this, damage);
        hpBar.SetAmount(currentHp / maxHp);
        if (currentHp <= 0)
            Die();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public Vector3 Position
    {
        get => transform.position;
        set
        {
            transform.position = value;
        }
    }
    public bool IsAlive => isAlive;
    public float Speed => speed;
}
