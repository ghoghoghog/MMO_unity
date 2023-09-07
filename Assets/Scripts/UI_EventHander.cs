using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHander : MonoBehaviour , IBeginDragHandler, IDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDraging-----------");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDraging-----------");    
    }
}
