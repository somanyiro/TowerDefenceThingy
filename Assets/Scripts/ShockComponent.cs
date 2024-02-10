using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockComponent : MonoBehaviour
{
    private Tower tower;
    private LineRenderer lineRenderer;
    public Vector3[] shockSources;
    
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        List<Vector3> shockPoints = new List<Vector3>();

        foreach (Vector3 source in shockSources)
        {
            shockPoints.Add(transform.position + source);
        }

        foreach (var enemy in tower.enemiesInRange)
        {
            shockPoints.Add(enemy.transform.position);
        }

        lineRenderer.positionCount = shockPoints.Count;
        lineRenderer.SetPositions(shockPoints.ToArray());
    }

    public void DamageEnemies(int amount)
    {
        foreach (var enemy in tower.enemiesInRange)
        {
            enemy.GetComponent<Enemy>().Damage(amount);
        }
    }
}
