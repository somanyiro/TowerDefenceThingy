using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Wave : ScriptableObject
{
    public float timeBetweenSpawns = 1f;
    public UDictionary<Enemy, int> enemies = new UDictionary<Enemy, int>();

}
