using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDummy 
{
    public EnemyDummy(float speed, int maxHp, int damage, int gold)
    {
        Speed = speed;
        MaxHp = maxHp;
        Damage = damage;
        Gold = gold;
    }

    public float Speed { get; set; }
    public int MaxHp { get; set; }
    public int Damage { get; set; }
    public int Gold { get; set; }
}
