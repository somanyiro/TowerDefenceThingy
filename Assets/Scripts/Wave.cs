using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Scriptable object that holds the information for a wave.
/// </summary>
[CreateAssetMenu]
public class Wave : ScriptableObject
{
    public float preperationTime = 10f;
    public float timeBetweenSpawns = 1f;
    public UDictionary<Enemy, int> enemyOrder = new UDictionary<Enemy, int>();
}
