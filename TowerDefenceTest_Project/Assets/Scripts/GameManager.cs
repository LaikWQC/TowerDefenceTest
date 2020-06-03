using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform EnemyFolder;
    [SerializeField] private WayPoints wayPoints;
    [SerializeField] private int enemyInWave;
    [SerializeField] private float enemySpawnDelay;
    [SerializeField] private float waveSpawnDelay;
    [SerializeField] private GameOver GameOverMenu;
    [SerializeField] private EnemyStatPanel StatPanel;

    private static GameManager i;
    private int waveIndex;
    private int enemySpawnCount;
    private float beforeNextEnemy;
    private float beforeNextWave;
    private bool pause;
    private int score;

    void Awake()
    { 
        i = this;
    }

    private void Update()
    {
        InputHandle();
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

    public void GameOver()
    {
        Pause = true;
        GameOverMenu.Activate(score);
    }

    public void AddScore()
    {
        score++;
    }

    private void SpawnEnemy()
    {
        if(enemySpawnCount>0)
        {
            enemySpawnCount--;
            var enemy = Instantiate(GameAssets.I.EnemyPf, wayPoints.StartLocation, Quaternion.identity);
            enemy.transform.SetParent(EnemyFolder);
            beforeNextEnemy = enemySpawnDelay;
        }        
    }

    private void SpawnWave()
    {
        waveIndex++;
        enemySpawnCount += enemyInWave;
        beforeNextWave = waveSpawnDelay;

        StatPanel.SetPanel(waveIndex, enemyInWave, 0, 0, 0, 0);
    }

    private void InputHandle()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Pause = !pause;
        }
    }

    private bool Pause
    {
        get => pause;
        set
        {
            pause = value;
            if (pause) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }
}
