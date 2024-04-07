using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }
    
    public enum EventType
    {
        EnemyDied,
        MoneyChanged,
        WaveFinished,
        WaveStarted,
        SkippedWavePreperation
    }
    
    private Dictionary<EventType, Action<object>> eventDictionary;
    
    private void Awake()
    {
        Instance = this;
        eventDictionary = new Dictionary<EventType, Action<object>>();
    }

    private void Start()
    {
    }
    
    public void Subscribe(EventType type, Action<object> callback)
    {
        if (!eventDictionary.ContainsKey(type))
            eventDictionary[type] = null;

        eventDictionary[type] += callback;
    }
    
    public void Unsubscribe(EventType type, Action<object> callback)
    {
        if (eventDictionary.ContainsKey(type))
            eventDictionary[type] -= callback;
    }

    public void Trigger(EventType type, object data = null)
    {
        if (eventDictionary.ContainsKey(type))
            eventDictionary[type]?.Invoke(data);
    }
}
