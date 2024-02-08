using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBuilder : MonoBehaviour
{
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

                GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(objectHit.position);
                ShowUI(true);
            }
            else
            {
                ShowUI(false);
            }
        }
    }

    void ShowUI(bool show)
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = show ? 1f : 0f;
        GetComponent<CanvasGroup>().interactable = show;
        GetComponent<CanvasGroup>().blocksRaycasts = show;
    }
    
    
}
