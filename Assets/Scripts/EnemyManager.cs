using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField]
    List<Wave> waves;

    [SerializeField]
    public PathCreator path;

    private bool waveOngoing = false;
    
    private Timer wavePreperationTimer;

    public int CurrentWave { get; private set; } = 0;
    public float TimeTillNextWave { get; private set; }

    private List<Enemy> activeEnemies = new List<Enemy>();
    private List<Enemy> inactiveEnemies = new List<Enemy>();
    
    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.Subscribe(EventBus.EventType.EnemyDied, OnEnemyDied);
        EventBus.Instance.Subscribe(EventBus.EventType.SkippedWavePreperation, SkipWavePreperation);
        wavePreperationTimer = new Timer(0);
        if (waves.Count > CurrentWave)
        {
            wavePreperationTimer.SetWaitTime(waves[CurrentWave].preperationTime);
            wavePreperationTimer.Reset();
        }
    }

    private void OnDestroy()
    {
        EventBus.Instance.Unsubscribe(EventBus.EventType.EnemyDied, OnEnemyDied);
        EventBus.Instance.Unsubscribe(EventBus.EventType.SkippedWavePreperation, SkipWavePreperation);
    }

    // Update is called once per frame
    void Update()
    {
        wavePreperationTimer.AdvanceTimer(Time.deltaTime);

        TimeTillNextWave = wavePreperationTimer.timeLeft;
        
        if (wavePreperationTimer.finishedThisFrame)
        {
            waveOngoing = true;
            IEnumerator coroutine = SpawnWave(waves[CurrentWave]);
            StartCoroutine(coroutine);
            CurrentWave++;
        }
        
        if (!waveOngoing && waves.Count > CurrentWave && wavePreperationTimer.timeLeft <= 0)
        {
            wavePreperationTimer.SetWaitTime(waves[CurrentWave].preperationTime);
            wavePreperationTimer.Reset();
        }
        
        if (!waveOngoing && CurrentWave == waves.Count && activeEnemies.Count == 0)
        {
            SceneManager.LoadScene(3);
        }

    }

    void SpawnEnemy(Enemy enemy)
    {
        foreach (var e in inactiveEnemies)
        {
            if (e.type == enemy.type)
            {
                inactiveEnemies.Remove(e);
                activeEnemies.Add(e);
                e.SetActive(true);
                return;
            }
        }
        
        GameObject newEnemy = Instantiate(enemy.gameObject, new Vector3(0, -100, 0), Quaternion.identity);
        newEnemy.GetComponent<PathFollower>().pathCreator = path;
        activeEnemies.Add(newEnemy.GetComponent<Enemy>());
    }

    IEnumerator SpawnWave(Wave wave)
    {
        EventBus.Instance.Trigger(EventBus.EventType.WaveStarted);
        
        foreach (var item in wave.enemyOrder)
        {
            for (int i = 0; i < item.Value; i++)
            {
                SpawnEnemy(item.Key);
                yield return new WaitForSeconds(wave.timeBetweenSpawns);
            }
        }

        waveOngoing = false;
        EventBus.Instance.Trigger(EventBus.EventType.WaveFinished, CurrentWave == waves.Count);
    }

    public void SkipWavePreperation(object data)
    {
        wavePreperationTimer.SetWaitTime(0);
    }

    void OnEnemyDied(object enemy)
    {
        inactiveEnemies.Add(enemy as Enemy);
        if (activeEnemies.Contains(enemy))
            activeEnemies.Remove(enemy as Enemy);
    }
}
