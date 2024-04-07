using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = HealthManager.Instance.maxPlayerHealth;
        GetComponent<RectTransform>().sizeDelta = new Vector2(19 * HealthManager.Instance.maxPlayerHealth / 2, 26);
        //this is based on the size of the texture that's filling the slider
        slider.value = HealthManager.Instance.maxPlayerHealth;
        EventBus.Subscribe(EventBus.EventType.HealthChanged, OnHealthChanged);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(EventBus.EventType.HealthChanged, OnHealthChanged);
    }

    void OnHealthChanged(object health)
    {
        slider.value = (int)health;
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
