using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Minimalistic event bus implementation.
/// An enum element needs to be created for all events.
/// </summary>
public static class EventBus
{
    public enum EventType
    {
        EnemyDied,
        MoneyChanged,
        WaveFinished,
        WaveStarted,
        SkippedWavePreparation,
        HealthChanged,
        MouseHoverChanged
    }
    
    private static Dictionary<EventType, Action<object>> eventDictionary = new Dictionary<EventType, Action<object>>();
    
    public static void Subscribe(EventType type, Action<object> callback)
    {
        if (!eventDictionary.ContainsKey(type))
            eventDictionary[type] = null;

        eventDictionary[type] += callback;
    }
    
    public static void Unsubscribe(EventType type, Action<object> callback)
    {
        if (eventDictionary.ContainsKey(type))
            eventDictionary[type] -= callback;
    }

    public static void Trigger(EventType type, object data = null)
    {
        if (eventDictionary.ContainsKey(type))
            eventDictionary[type]?.Invoke(data);
    }
}
