using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
    public ParticleSystem bulletParticles;
    public Transform turret;

    private Tower tower;
    private Enemy target;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tower.enemiesInRange.Count > 0)
        {
            bulletParticles.enableEmission = true;
            
            bulletParticles.transform.LookAt(tower.enemiesInRange[0].transform.position+Vector3.up/2);
            turret.LookAt(tower.enemiesInRange[0].transform.position+Vector3.up/2);
            
            target = tower.enemiesInRange[0].GetComponent<Enemy>();
        }
        else
        {
            bulletParticles.enableEmission = false;
        }
    }
    
    public void DamageTarget(int amount)
    {
        if (target is null) return;
        
        target.Damage(amount);
    }
}
