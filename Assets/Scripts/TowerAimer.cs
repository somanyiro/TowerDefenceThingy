using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAimer : MonoBehaviour
{

    List<GameObject> enemiesInRange = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;
        enemiesInRange.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;
        if (enemiesInRange.Contains(other.gameObject)) enemiesInRange.Remove(other.gameObject);
    }
}
