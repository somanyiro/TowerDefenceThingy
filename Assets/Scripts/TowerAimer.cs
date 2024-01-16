using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAimer : MonoBehaviour
{

    List<GameObject> enemiesInRange = new List<GameObject>();

    [NonSerialized]
    public GameObject target;
    public GameObject damageBeam;
    private LineRenderer beamLine;
    
    // Start is called before the first frame update
    void Start()
    {
        beamLine = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesInRange.Count > 0)
        {
            beamLine.SetPositions(new Vector3[] {
                damageBeam.transform.position,
                enemiesInRange[0].transform.position
            });
            beamLine.enabled = true;
        }
        else
        {
            beamLine.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<HealthComponent>() is null) return;
        enemiesInRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HealthComponent>() is null) return;
        if (enemiesInRange.Contains(other.gameObject)) enemiesInRange.Remove(other.gameObject);
    }
}
