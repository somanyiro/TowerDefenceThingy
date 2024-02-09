using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public int value;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PathFollower>().speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);

    }
}
