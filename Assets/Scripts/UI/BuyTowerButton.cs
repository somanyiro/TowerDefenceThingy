using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A button that can be clicked to buy a tower.
/// A tower prefab needs to be dragged into it in the editor and the click event needs to be hooked up to TowerBuilder.
/// </summary>
public class BuyTowerButton : MonoBehaviour
{
    public Tower tower;
    public TextMeshProUGUI priceText;
    public Image towerIcon;

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        priceText.text = tower.price.ToString();
        towerIcon.sprite = tower.icon;
    }

    // Update is called once per frame
    void Update()
    {
        if (MoneyManager.Instance.Money >= tower.price)
            button.interactable = true;
        else
            button.interactable = false;
    }
}
