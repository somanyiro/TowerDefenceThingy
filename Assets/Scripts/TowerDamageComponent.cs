using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamageComponent : MonoBehaviour
{
    public int damage;
    public float timeInterval;

    public TowerAimer towerAimer;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", timeInterval, timeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        if (towerAimer.target is not null)
            towerAimer.target.GetComponent<Enemy>().Damage(damage);
    }
}
