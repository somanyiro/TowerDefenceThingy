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
    public Texture2D icon;
    public GameObject tower;

}
