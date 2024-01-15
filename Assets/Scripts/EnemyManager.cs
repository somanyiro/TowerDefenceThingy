using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    List<PathFollower> enemies;

    [SerializeField]
    public PathCreator path;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemies[0].gameObject, Vector3.zero, Quaternion.identity);
        enemy.GetComponent<PathFollower>().pathCreator = path;
    }

}
