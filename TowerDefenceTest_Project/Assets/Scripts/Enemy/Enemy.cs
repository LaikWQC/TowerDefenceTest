using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private HpBar hpBar;

    private int waypointIndex;
    private float speed;
    private int maxHp;
    private float currentHp;
    private int damage;
    private int gold;
    private bool isAlive;
    private Transform destination;

    void Start()
    {
        waypointIndex = 0;
        destination = GameManager.I.GetDestination(waypointIndex);
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
        transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        if(Vector2.Distance(destination.position, transform.position) < 0.05f)
        {
            destination = GameManager.I.GetDestination(++waypointIndex);
            if (destination == null)
                EndPointReached();
        }
    }

    private void EndPointReached()
    {
        ResourcesManager.I.TakeDamage(damage);
        isAlive = false;
        Destroy(gameObject);
    }

    private void Die()
    {
        ResourcesManager.I.AddGold(gold);
        GameManager.I.AddScore();
        isAlive = false;
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        hpBar.SetAmount(currentHp / maxHp);
        if (currentHp <= 0)
            Die();
    }

    public Vector3 Position => transform.position;
    public bool IsAlive => isAlive;
}
