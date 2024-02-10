using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
