using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public string towerName;
    public float range;
    public float attackInterval;
    public float damage;
    public string type;
    public Sprite icon;
    public int level;
    public Tower upgradeTarget;
    public int price;
    public int upgradePrice;
    
    [NonSerialized]
    public List<GameObject> enemiesInRange = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: replace with object caching
        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            if (enemiesInRange[i].IsDestroyed())
                enemiesInRange.RemoveAt(i);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is null) return;
        enemiesInRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() is null) return;
        if (enemiesInRange.Contains(other.gameObject)) enemiesInRange.Remove(other.gameObject);
    }
    
}
