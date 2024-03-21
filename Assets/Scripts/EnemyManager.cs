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
    
    public delegate void WaveFinishedEventHandler(object sender, bool isFinalWave);
    public event WaveFinishedEventHandler WaveFinished;
    public delegate void WaveStartedEventHandler(object sender, EventArgs e);
    public event WaveStartedEventHandler WaveStarted;

    private List<Enemy> activeEnemies = new List<Enemy>();
    private List<Enemy> inactiveEnemies = new List<Enemy>();
    
    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        wavePreperationTimer = new Timer(0);
        if (waves.Count > CurrentWave)
        {
            wavePreperationTimer.SetWaitTime(waves[CurrentWave].preperationTime);
            wavePreperationTimer.Reset();
        }
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
        newEnemy.GetComponent<Enemy>().Died += OnEnemyDied;
        activeEnemies.Add(newEnemy.GetComponent<Enemy>());
    }

    IEnumerator SpawnWave(Wave wave)
    {
        OnWaveStarted(EventArgs.Empty);
        
        foreach (var item in wave.enemyOrder)
        {
            for (int i = 0; i < item.Value; i++)
            {
                SpawnEnemy(item.Key);
                yield return new WaitForSeconds(wave.timeBetweenSpawns);
            }
        }

        waveOngoing = false;
        OnWaveFinished(EventArgs.Empty, CurrentWave == waves.Count);
    }

    public void SkipWavePreperation()
    {
        wavePreperationTimer.SetWaitTime(0);
    }
    
    protected virtual void OnWaveFinished(EventArgs e, bool isFinalWave)
    {
        WaveFinishedEventHandler handler = WaveFinished;
        handler?.Invoke(this, isFinalWave);
    }
    
    protected virtual void OnWaveStarted(EventArgs e)
    {
        WaveStartedEventHandler handler = WaveStarted;
        handler?.Invoke(this, e);
    }

    public void OnEnemyDied(object sender, EventArgs e)
    {
        inactiveEnemies.Add(sender as Enemy);
        if (activeEnemies.Contains(sender))
            activeEnemies.Remove(sender as Enemy);
    }
}
