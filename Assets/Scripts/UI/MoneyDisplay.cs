using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.Subscribe(EventBus.EventType.MoneyChanged, OnMoneyChanged);
    }

    private void OnDestroy()
    {
        EventBus.Instance.Unsubscribe(EventBus.EventType.MoneyChanged, OnMoneyChanged);
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
