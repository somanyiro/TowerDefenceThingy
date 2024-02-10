using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public int speed;
    public int carriedMoney;

    public Canvas healthBarCanvas;
    public Slider healthBar;
    private Camera camera;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PathFollower>().speed = speed;
        health = maxHealth;
        UpdateHealthBar();
        
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarCanvas.transform.rotation =
            Quaternion.LookRotation(healthBarCanvas.transform.position - camera.transform.position);
    }
    
    public void Damage(int amount)
    {
        health -= amount;
        if (health <= 0)
            Destroy(gameObject);
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthBar.value = Map(health, 0, maxHealth, 0, 1);
    }
    
    float Map(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }
}
