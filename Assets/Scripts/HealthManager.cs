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
        Instance = this;
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
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is null) return;
        PlayerHealth -= 1;

        other.GetComponent<Enemy>().Die();
        
        if (PlayerHealth == 0)
            SceneManager.LoadScene(2);
    }
    
    
}
