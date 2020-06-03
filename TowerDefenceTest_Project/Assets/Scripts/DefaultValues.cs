using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultValues : MonoBehaviour
{
    private static DefaultValues i;

    void Awake()
    {
        i = this;
    }

    public static DefaultValues I => i;

    public int extraEnemyInWave;
    public float enemySpawnDelay;
    public float waveSpawnDelay;

    public int startingGold;
    public int startingLifes;

    public float enemySpeed;
    public int enemyMaxHp;
    public int enemyDamage;
    public int enemyGold;

    public float towerRange;
    public float towerDamage;
    public float towerAttackSpeed;
}
