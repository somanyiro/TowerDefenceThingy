using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class TowerDataScriptableObject : ScriptableObject
{
    public string towerName;
    public float range;
    public float attackInterval;
    public float damage;
    public string type;
    public Sprite icon;
    public GameObject tower;
    public int level;
    public TowerDataScriptableObject nextLevel;
}
