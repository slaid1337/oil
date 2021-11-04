using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlocksDrag : MonoBehaviour, IDragHandler
{
    private RectTransform rT;
    public bool draggable;

    private void Awake()
    {
        draggable = true;
        rT = gameObject.GetComponent<RectTransform>();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (draggable)
        {
            rT.position = eventData.position;
        }
        
    }

    
}
