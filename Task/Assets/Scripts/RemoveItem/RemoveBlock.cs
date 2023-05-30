using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveBlock : MonoBehaviour,IDropHandler
{
    [Header("Instance")]
    private IHistory History;


    private int index;
    private GameObject removed;


    private void Awake()
    {
       
    }
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {

            removed = eventData.pointerDrag.gameObject;

            if (removed.GetComponent<ButtonManager>() == null) return;

            index = removed.GetComponent<ButtonManager>().index;

            History = removed.GetComponent<ButtonManager>().History;

             History.Remove(index,removed);


             Debug.Log("Removed");
             Debug.Log(index);
       
         
            

           
        }
    }

  
}
