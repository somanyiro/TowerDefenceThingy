using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles all aspects of the game's money.
/// Made it a singleton to give easy access to the money but it also uses the eventbus to update others.
/// </summary>
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
        EventBus.Trigger(EventBus.EventType.MoneyChanged, Money);
    }

    public void Earn(int amount)
    {
        Money += amount;
        if (Money > 999)
            Money = 999;
        EventBus.Trigger(EventBus.EventType.MoneyChanged, Money);
    }

    private void Start()
    {
        Money = startingMoney;
    }

    private void Awake()
    {
        Instance = this;
    }
}
