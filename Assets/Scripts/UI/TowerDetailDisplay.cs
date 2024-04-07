using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the details of a tower when the mouse hovers over it.
/// </summary>
public class TowerDetailDisplay : MonoBehaviour
{
    public TextMeshProUGUI towerNameText;
    public Image towerIcon;
    public TextMeshProUGUI towerDetailsText;
    
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe(EventBus.EventType.MouseHoverChanged, OnHoverChanged);
    }

    private void OnDestroy()
    {
        EventBus.Unsubscribe(EventBus.EventType.MouseHoverChanged, OnHoverChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHoverChanged(object tower)
    {
        if (tower is null) return;
        Tower hoverTarget = (Tower)tower;

        towerNameText.text = hoverTarget.towerName;
        towerIcon.sprite = hoverTarget.icon;
        towerDetailsText.text = 
            $"Level: {hoverTarget.level}\nRange: {hoverTarget.range}m\nAttack: {hoverTarget.attackInterval}/s\nDamage: {hoverTarget.damage}\nType: {hoverTarget.type}";
    }
}
