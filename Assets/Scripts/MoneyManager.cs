using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance { get; private set; }

    public int startingMoney = 20;
    public int Money { get; private set; }

    public void Spend(int amount)
    {
        Money -= amount;
        if (Money < 0)
        {
            Debug.Log("Spent more than allowed money");
            Money = 0;
        }
    }

    private void Start()
    {
        Money = startingMoney;
    }

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
}