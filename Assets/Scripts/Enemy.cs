using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// All enemies have this component. It contains all the information about the enemy, such as health, speed, and money carried.
/// A PathFollower component is also needed on the enemy, which allows for movement.
/// This class also has functionality for activating and deactivating for caching.
/// </summary>
public class Enemy : MonoBehaviour
{
    public string type;
    public int maxHealth;
    private int currentHealth;
    public int Health {
        get => currentHealth;
        private set => currentHealth = value; }
    public int speed;
    public int carriedMoney;
    public Vector3 towerAimTarget;

    public Canvas healthBarCanvas;
    public Slider healthBar;
    public TextParticle textParticle;
    private Camera playerCamera;

    private float slowDuration;
    public bool isActive;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PathFollower>().speed = speed;
        currentHealth = maxHealth;
        UpdateHealthBar();
        
        playerCamera = Camera.main;
        SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (slowDuration > 0)
        {
            slowDuration -= Time.deltaTime;
            if (slowDuration <= 0)
            {
                GetComponent<PathFollower>().speed = speed;
            }
        }
        
        healthBarCanvas.transform.rotation =
            Quaternion.LookRotation(healthBarCanvas.transform.position - playerCamera.transform.position);
    }
    
    public void Damage(int amount)
    {
        if (currentHealth <= 0) return;
        
        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth > 0)
        {
            TextParticle tpDamage = Instantiate(textParticle);
            tpDamage.Setup(amount.ToString(), false, Color.red);
            tpDamage.transform.position = transform.position;
        }
        else
        {
            TextParticle tpReward = Instantiate(textParticle);
            tpReward.Setup(carriedMoney.ToString(), true, Color.white);
            tpReward.transform.position = transform.position;
            MoneyManager.Instance.Earn(carriedMoney);
        }
        
        if (currentHealth <= 0)
            Die();
    }

    public void Slow(float amount, float duration)
    {
        GetComponent<PathFollower>().speed = speed / amount;
        if (slowDuration < duration)
            slowDuration = duration;
    }

    public void Die()
    {
        SetActive(false);
        EventBus.Trigger(EventBus.EventType.EnemyDied, this);
        transform.position = new Vector3(0, -100, 0);
    }
    
    void UpdateHealthBar()
    {
        healthBar.value = Map(currentHealth, 0, maxHealth, 0, 1);
    }
    
    float Map(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }

    public void SetActive(bool active)
    {
        isActive = active;

        if (isActive)
        {
            GetComponent<PathFollower>().enabled = true;
            GetComponent<PathFollower>().distanceTravelled = 0;
            this.enabled = true;
            currentHealth = maxHealth;
            UpdateHealthBar();
        }
        else
        {
            GetComponent<PathFollower>().enabled = false;
            this.enabled = false;
        }
    }
}
