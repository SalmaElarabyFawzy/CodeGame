using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup group;
    [SerializeField] private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        group.blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
         group.blocksRaycasts = true;
    }
   

}
