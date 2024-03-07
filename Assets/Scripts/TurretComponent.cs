using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
    public ParticleSystem bulletParticles;
    public Transform turret;

    private Tower tower;
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

            Vector3 target = tower.enemiesInRange[0].transform.position +
                             tower.enemiesInRange[0].GetComponent<Enemy>().towerAimTarget;
            bulletParticles.transform.LookAt(target);
            turret.LookAt(target);
        }
        else
        {
            bulletParticles.enableEmission = false;
        }
    }
    
    public void DamageTarget(int amount)
    {
        if (tower.enemiesInRange.Count == 0) return;
        
        tower.enemiesInRange[0].GetComponent<Enemy>().Damage(amount);
    }
}
