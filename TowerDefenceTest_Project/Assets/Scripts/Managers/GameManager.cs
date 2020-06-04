using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform EnemyFolder;
    [SerializeField] private WayPoints Waypoints;    
    [SerializeField] private GameOver GameoverMenu;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private EnemyStatPanel WaveStatPanel;

    private static GameManager i;
    private int waveIndex;
    private float beforeNextEnemy;
    private float beforeNextWave;
    private int score;
    private bool isGameover;
    private List<EnemyDummy> enemies;

    void Awake()
    { 
        i = this;
        enemies = new List<EnemyDummy>();
    }

    private void Update()
    {
        InputHandler();
        Spawn();
    }

    public Transform GetDestination(int waypointIndex)
    {
        return Waypoints.GetWaypoint(waypointIndex);
    }

    public void GameOver()
    {
        isGameover = true;
        TimeManager.I.Pause = true;
        GameoverMenu.Activate(score);
    }

    public void AddScore()
    {
        score++;
    }

    private void InputHandler()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameover) return;

            if(PauseMenu.activeSelf)
            {
                TimeManager.I.Pause = false;
                PauseMenu.SetActive(false);
            }
            else
            {
                TimeManager.I.Pause = true;
                PauseMenu.SetActive(true);
            }
        }
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
        var enemy = Instantiate(GameAssets.I.EnemyPf, Waypoints.StartLocation, Quaternion.identity);        
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

        WaveStatPanel.SetPanel(waveIndex, enemySpawnCount, dummy.MaxHp, dummy.Speed, dummy.Damage, dummy.Gold);
    }

    public static GameManager I => i;
}
