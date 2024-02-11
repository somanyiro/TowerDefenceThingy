using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    List<Wave> waves;

    [SerializeField]
    public PathCreator path;

    public int currentWave = 0;
    private bool waveOngoing = false;
    
    private Timer wavePreperationTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        wavePreperationTimer = new Timer(0, false);
    }

    // Update is called once per frame
    void Update()
    {
        wavePreperationTimer.AdvanceTimer(Time.deltaTime);

        if (wavePreperationTimer.finishedThisFrame)
        {
            waveOngoing = true;
            IEnumerator coroutine = SpawnWave(waves[currentWave]);
            StartCoroutine(coroutine);
            currentWave++;
        }
        
        if (!waveOngoing && waves.Count > currentWave && wavePreperationTimer.timeLeft <= 0)
        {
            wavePreperationTimer.SetWaitTime(waves[currentWave].preperationTime);
            wavePreperationTimer.Reset();
        }

    }

    void SpawnEnemy(Enemy enemy)
    {
        GameObject newEnemy = Instantiate(enemy.gameObject, new Vector3(0, -100, 0), Quaternion.identity);
        newEnemy.GetComponent<PathFollower>().pathCreator = path;
    }

    IEnumerator SpawnWave(Wave wave)
    {
        foreach (var item in wave.enemyOrder)
        {
            for (int i = 0; i < item.Value; i++)
            {
                SpawnEnemy(item.Key);
                yield return new WaitForSeconds(wave.timeBetweenSpawns);
            }
        }

        waveOngoing = false;
    }

    
}
