using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Works together with a tower to slow down enemies.
/// SlowEnemies() needs to be hooked up to the tower's attack event.
/// </summary>
public class JammerComponent : MonoBehaviour
{
    private Tower tower;
    public Transform generator;
    public float rotationSpeed = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        generator.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void SlowEnemies(int damage)
    {
        foreach (var enemy in tower.enemiesInRange)
        {
            enemy.Slow(1.5f, 1);
        }
    }
}
