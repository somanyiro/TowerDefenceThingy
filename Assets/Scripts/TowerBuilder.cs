using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuilder : MonoBehaviour
{
    private GameObject selectedSpot;

    public GameObject shopUI;
    public GameObject modifyUI;
    
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
                
                GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(objectHit.position);
                
                ShowShopUI(true);
                ShowModifyUI(true);
            }
            else
            {
                ShowShopUI(false);
                ShowModifyUI(false);
            }
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
