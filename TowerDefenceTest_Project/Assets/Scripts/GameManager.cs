using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform EnemyFolder;
    [SerializeField] private WayPoints wayPoints;    
    [SerializeField] private GameOver GameOverMenu;
    [SerializeField] private EnemyStatPanel StatPanel;

    private static GameManager i;
    private int waveIndex;
    private float beforeNextEnemy;
    private float beforeNextWave;
    private bool pause;
    private int score;
    private List<EnemyDummy> enemies;

    void Awake()
    { 
        i = this;
        enemies = new List<EnemyDummy>();
    }

    private void Update()
    {
        InputHandle();
        Spawn();
    }

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

    private void Spawn()
    {
        if (beforeNextWave <= 0)
            SpawnWave();
        if (beforeNextEnemy <= 0)
            SpawnEnemy();

        if (enemies.Count > 0)
            beforeNextEnemy -= Time.deltaTime;
        else
            beforeNextWave -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {        
        var enemy = Instantiate(GameAssets.I.EnemyPf, wayPoints.StartLocation, Quaternion.identity);        
        enemy.transform.SetParent(EnemyFolder);
        enemy.GetComponent<IEnemy>()?.Setup(enemies[0]);

        beforeNextEnemy = DefaultValues.I.enemySpawnDelay;
        enemies.RemoveAt(0);
    }

    private void SpawnWave()
    {
        waveIndex++;
        var dummy = new EnemyDummy(
                DefaultValues.I.enemySpeed,
                DefaultValues.I.enemyMaxHp + waveIndex,
                DefaultValues.I.enemyDamage,
                DefaultValues.I.enemyGold);

        int enemySpawnCount = Random.Range(waveIndex, waveIndex + DefaultValues.I.extraEnemyInWave);
        for (int k = 0; k < enemySpawnCount; k++)
        {
            enemies.Add(dummy);
        }
        beforeNextWave = DefaultValues.I.waveSpawnDelay;

        StatPanel.SetPanel(waveIndex, enemySpawnCount, dummy.MaxHp, dummy.Speed, dummy.Damage, dummy.Gold);
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

    public static GameManager I => i;
}
