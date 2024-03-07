using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverManager : MonoBehaviour
{
    public static MouseHoverManager Instance { get; private set; }
    
    [NonSerialized]
    public Tower hoverTarget;
    
    private void Awake()
    {
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask(new[] { "Selectable" })))
        {
            Transform objectHit = hit.transform;

            hoverTarget = objectHit.GetComponent<TowerSpot>().tower;
        }
    }

    public void SetHoverTarget(Tower newTarget)
    {
        hoverTarget = newTarget;
    }
}
