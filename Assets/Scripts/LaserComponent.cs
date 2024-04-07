using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Works together with a tower to damage enemies.
/// DamageTarget() needs to be hooked up to the tower's attack event.
/// </summary>
public class LaserComponent : MonoBehaviour
{
    public Vector3 laserSource;
    private Tower tower;
    private LineRenderer lineRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tower.enemiesInRange.Count > 0)
        {
            lineRenderer.enabled = true;
            
            lineRenderer.SetPositions(new []
            {
                transform.position + laserSource,
                tower.enemiesInRange[0].transform.position + tower.enemiesInRange[0].towerAimTarget
            });

        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public void DamageTarget(int amount)
    {
        if (tower.enemiesInRange.Count == 0) return;
        
        tower.enemiesInRange[0].Damage(amount);
    }
}
