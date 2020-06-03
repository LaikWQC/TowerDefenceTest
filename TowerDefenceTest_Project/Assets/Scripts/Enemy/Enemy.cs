using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] private HpBar hpBar;
    [SerializeField] private float speed;
    [SerializeField] private int maxHp;
    [SerializeField] private int damage;
    [SerializeField] private int gold;

    private int waypointIndex;
    private Transform destination;
    private float currentHp;
    private bool isAlive;

    void Start()
    {
        waypointIndex = 0;
        destination = GameManager.I.GetDestination(waypointIndex);
        currentHp = maxHp;
        isAlive = true;
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
