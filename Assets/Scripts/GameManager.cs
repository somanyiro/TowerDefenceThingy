using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int maxPlayerHealth = 5;
    public int PlayerHealth { get; private set; }
    
    private void Awake()
    {
        if (Instance is not null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = maxPlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
