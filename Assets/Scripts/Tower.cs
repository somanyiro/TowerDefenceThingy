using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public string towerName;
    public float range;
    public float attackInterval;
    public int damage;
    public string type;
    public Sprite icon;
    public int level;
    public Tower upgradeTarget;
    public int price;
    public int upgradePrice;
    
    [NonSerialized]
    public List<Enemy> enemiesInRange = new List<Enemy>();

    public UnityEvent<int> attackEvent = new UnityEvent<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SphereCollider>().radius = range;
        InvokeRepeating("InvokeAttack", 1/attackInterval, 1/attackInterval);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemiesInRange.Count; i++)
        {
            if (enemiesInRange[i].isActive == false)
                enemiesInRange.RemoveAt(i);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is null) return;
        enemiesInRange.Add(other.GetComponent<Enemy>());
    }

    private void OnTriggerExit(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy is null) return;
        if (enemiesInRange.Contains(enemy)) enemiesInRange.Remove(enemy);
    }

    void InvokeAttack()
    {
        attackEvent.Invoke(damage);
    }
    
}
