using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class DummyFactory 
{
    public static EnemyDummy GetDummy(int waveIndex)
    {
        return NormalEnemy(waveIndex);
    }

    private static EnemyDummy NormalEnemy(int waveIndex)
    {
        return new EnemyDummy(
                DefaultValues.I.enemySpeed,
                DefaultValues.I.enemyMaxHp + waveIndex,
                DefaultValues.I.enemyDamage,
                DefaultValues.I.enemyGold);
    }
}
