using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Raycasts from the mouse to the world and updates the hover target.
/// </summary>
public class MouseHoverManager : MonoBehaviour
{
    [NonSerialized]
    public Tower hoverTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe(EventBus.EventType.MouseHoverChanged, OnHoverChanged);
    }

    void OnDestroy()
    {
        EventBus.Unsubscribe(EventBus.EventType.MouseHoverChanged, OnHoverChanged);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10000, LayerMask.GetMask(new[] { "Selectable" })))
        {
            var towerHit = hit.transform.GetComponent<TowerSpot>().tower;

            if (towerHit != hoverTarget)
            {
                hoverTarget = towerHit;
                EventBus.Trigger(EventBus.EventType.MouseHoverChanged, hoverTarget);
            }
        }
    }

    void OnHoverChanged(object target)
    {
        hoverTarget = (Tower)target;
    }
}
