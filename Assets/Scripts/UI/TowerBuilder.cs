using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{
    private TowerSpot selectedSpot;
    private Tower selectedTower;

    public GameObject shopUI;
    public GameObject modifyUI;
    public Button upgradeButton;
    public TextMeshProUGUI upgradePriceText;
    public Tower emptyTower;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowModifyUI(false);
        ShowShopUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask(new []{"Selectable"})))
            {
                Transform objectHit = hit.transform;

                selectedSpot = objectHit.GetComponent<TowerSpot>();
                selectedTower = selectedSpot.tower;
                
                GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(objectHit.position);
                
                if (selectedTower == emptyTower)
                {
                    ShowShopUI(true);
                    ShowModifyUI(false);
                }
                else
                {
                    ShowModifyUI(true);
                    ShowShopUI(false);
                }
            }
            else
            {
                ShowShopUI(false);
                ShowModifyUI(false);
            }
        }
        
        //TODO: checking for if the upgrade target is null doesn't work for some reason
        if (selectedTower is not null && selectedTower.upgradeTarget is not null)
        {
            upgradePriceText.text = selectedTower.upgradePrice.ToString();
            upgradeButton.interactable = MoneyManager.Instance.Money >= selectedTower.upgradePrice;
        }
        else
        {
            upgradePriceText.text = "-";
            upgradeButton.interactable = false;
        }
    }

    void ShowShopUI(bool show)
    {
        CanvasGroup canvasGroup = shopUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = show ? 1f : 0f;
        canvasGroup.interactable = show;
        canvasGroup.blocksRaycasts = show;
    }
    
    void ShowModifyUI(bool show)
    {
        CanvasGroup canvasGroup = modifyUI.GetComponent<CanvasGroup>();
        canvasGroup.alpha = show ? 1f : 0f;
        canvasGroup.interactable = show;
        canvasGroup.blocksRaycasts = show;
    }

    public void UpgradeTower()
    {
        if (selectedSpot is null) return;
        if (selectedTower is null) return;
        if (selectedTower.upgradeTarget is null) return;
        
        MoneyManager.Instance.Spend(selectedTower.upgradePrice);
        selectedSpot.tower = selectedTower.upgradeTarget;
        selectedSpot.UpdateTower();
        
        ShowModifyUI(false);
    }

    public void DestroyTower()
    {
        if (selectedSpot is null) return;
        if (selectedTower is null) return;

        selectedSpot.tower = emptyTower;
        selectedSpot.UpdateTower();
        
        ShowModifyUI(false);
    }

    public void PreviewUpgrade()
    {
        if (selectedSpot is null) return;
        if (selectedTower is null) return;
        if (selectedTower.upgradeTarget is null) return;
        
        MouseHoverManager.Instance.SetHoverTarget(selectedTower.upgradeTarget);
    }

    public void PreviewTower(Tower tower)
    {
        if (selectedSpot is null) return;
        
        MouseHoverManager.Instance.SetHoverTarget(tower);
    }

    public void BuyTower(Tower tower)
    {
        if (selectedSpot is null) return;
        
        MoneyManager.Instance.Spend(tower.price);
        selectedSpot.tower = tower;
        selectedSpot.UpdateTower();
        ShowShopUI(false);
    }
    
}
