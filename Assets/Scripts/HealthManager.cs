using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This object is responsible for detecting when an enemy reached the base.
/// It also handles health. i made it a singleton so that all objects have access to health and maxheralth but it also communicates with the eventbus to update the health display.
/// </summary>
public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    
    public int maxPlayerHealth = 5;
    public int PlayerHealth { get; private set; }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = maxPlayerHealth;
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is null) return;
        PlayerHealth -= 1;

        EventBus.Trigger(EventBus.EventType.HealthChanged, PlayerHealth);
        
        other.GetComponent<Enemy>().Die();
        
        if (PlayerHealth == 0)
            SceneManager.LoadScene(2);
    }
    
    
}
