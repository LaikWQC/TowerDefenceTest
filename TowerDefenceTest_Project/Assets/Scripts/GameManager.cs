using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WayPoints wayPoints;
    [SerializeField] int enemyInWave;
    [SerializeField] float enemySpawnDelay;
    [SerializeField] float waveSpawnDelay;

    private static GameManager i;
    private int waveIndex;
    private int enemySpawnCount;
    private float beforeNextEnemy;
    private float beforeNextWave;

    void Awake()
    { 
        i = this;
    }

    private void Update()
    {
        if (beforeNextWave <= 0)
            SpawnWave();
        if (beforeNextEnemy <= 0)
            SpawnEnemy();
        beforeNextWave -= Time.deltaTime;
        beforeNextEnemy -= Time.deltaTime;
    }

    public static GameManager I => i;

    public Transform GetDestination(int waypointIndex)
    {
        return wayPoints.GetWaypoint(waypointIndex);
    }

    private void SpawnEnemy()
    {
        if(enemySpawnCount>0)
        {
            enemySpawnCount--;
            Instantiate(GameAssets.I.EnemyPf, wayPoints.StartLocation, Quaternion.identity);
            beforeNextEnemy = enemySpawnDelay;
        }        
    }

    private void SpawnWave()
    {
        waveIndex++;
        enemySpawnCount += enemyInWave;
        beforeNextWave = waveSpawnDelay;
    }
}
