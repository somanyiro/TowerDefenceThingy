using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerBuilder : MonoBehaviour
{
    private GameObject selectedSpot;
    private Tower selectedTower;

    public GameObject shopUI;
    public GameObject modifyUI;
    public Button upgradeButton;
    public TextMeshProUGUI upgradePriceText;
    public Tower emptyTower;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

                selectedSpot = objectHit.gameObject;
                selectedTower = selectedSpot.GetComponent<TowerSpot>().tower;
                
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
        
        if (selectedTower.upgradeTarget is not null)
        {
            upgradePriceText.text = selectedTower.upgradePrice.ToString();
            upgradeButton.interactable = true;
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
    
}
