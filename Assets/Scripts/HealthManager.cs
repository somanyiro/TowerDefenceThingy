using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
