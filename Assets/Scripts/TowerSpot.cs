using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This object is a spot where a tower can be placed.
/// Responsible for instantiating and destroying the tower object.
/// </summary>
public class TowerSpot : MonoBehaviour
{
    public Tower tower;

    public Transform towerOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateTower();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTower()
    {
        foreach (Transform t in towerOrigin)
        {
            Destroy(t.gameObject);
        }

        if (tower is null) return;
        
        Tower newTower = Instantiate(tower);
        newTower.transform.parent = towerOrigin;
        newTower.transform.localPosition = Vector3.zero;
    }
}
