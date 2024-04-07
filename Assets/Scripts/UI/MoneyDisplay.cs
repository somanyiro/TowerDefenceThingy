using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Litsens to the money changed event and updates the money display.
/// </summary>
public class MoneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe(EventBus.EventType.MoneyChanged, OnMoneyChanged);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(EventBus.EventType.MoneyChanged, OnMoneyChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMoneyChanged(object money)
    {
        GetComponent<TextMeshProUGUI>().text = ((int)money).ToString();
    }
}
