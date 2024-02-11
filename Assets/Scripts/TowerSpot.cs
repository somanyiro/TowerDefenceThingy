using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public Tower tower;

    public Transform towerOrigin;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        GameManager.Instance.SetupGame += OnSetupGame;
    }

    void OnSetupGame(object sender, EventArgs e)
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
