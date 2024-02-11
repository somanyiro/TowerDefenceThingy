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
    
    private void Awake()
    {
        if (Instance is not null && Instance != this)
        {
            Destroy(Instance.gameObject);
        }
        Instance = this;
     
        GameManager.Instance.SetupGame += OnSetupGame;
    }

    void OnSetupGame(object sender, EventArgs e)
    {
        PlayerHealth = maxPlayerHealth;
    }
    
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
        if (other.GetComponent<Enemy>() is null) return;
        PlayerHealth -= 1;

        if (PlayerHealth == 0)
            SceneManager.LoadScene(0);
    }
    
    
}
