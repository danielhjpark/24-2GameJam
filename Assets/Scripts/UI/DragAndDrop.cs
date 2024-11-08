using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject beingDraggedIcon;

    Vector3 startPosition; //원본위치 백업용

    [SerializeField]
    Transform onDragParent;
    [HideInInspector]
    public Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        beingDraggedIcon = gameObject;

        startPosition = transform.position;
        startParent = transform.parent;

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        transform.SetParent(onDragParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        beingDraggedIcon = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if(transform.parent == onDragParent)
        {
            transform.SetParent(startParent);
            transform.position = startPosition;
        }
    }
}
