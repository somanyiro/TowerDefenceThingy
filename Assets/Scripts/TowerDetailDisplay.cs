using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerDetailDisplay : MonoBehaviour
{
    public MouseHoverManager mouseHoverManager;
    
    public TextMeshProUGUI towerNameText;
    public Image towerIcon;
    public TextMeshProUGUI towerDetailsText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseHoverManager.hoverTarget is null) return;

        towerNameText.text = mouseHoverManager.hoverTarget.towerName;
        towerIcon.sprite = mouseHoverManager.hoverTarget.icon;
        towerDetailsText.text = 
            $"Level: {mouseHoverManager.hoverTarget.level}\nRange: {mouseHoverManager.hoverTarget.range}m\nAttack: {mouseHoverManager.hoverTarget.attackInterval}/s\nDamage: {mouseHoverManager.hoverTarget.damage}\nType: {mouseHoverManager.hoverTarget.type}";
    }
}
