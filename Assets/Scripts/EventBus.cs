using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }
    
    private Dictionary<string, Action<object>> eventDictionary;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        eventDictionary = new Dictionary<string, Action<object>>();
    }
    
    public void Register(string eventName, Action<object> callback)
    {
        if (!eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName] = null;

        eventDictionary[eventName] += callback;
    }
    
    public void Unregister(string eventName, Action<object> callback)
    {
        if (eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName] -= callback;
    }

    public void Trigger(string eventName, object data = null)
    {
        if (eventDictionary.ContainsKey(eventName))
            eventDictionary[eventName]?.Invoke(data);
    }
}
