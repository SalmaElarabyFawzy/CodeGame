using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class LoopItemSlot : MonoBehaviour,IDropHandler,IPointerExitHandler,IPointerEnterHandler
{

    [Header("Prefabs")]
    private GameObject loopPref;
    private GameObject up;
    private GameObject down;
    private GameObject right;
    private GameObject left;
    private GameObject function;
    private GameObject destroy;

    [Header("Instance")]
    private GameMaster master;
    private LoopBlockCommand history;
    private LoopSlot dropped;


    private bool drop = false;
   


    public void OnPointerEnter(PointerEventData eventData)
    {
        dropped = transform.parent.GetComponent<LoopSlot>();
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        SetPrefabs();
    }



    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {

            drop = true;
           Commands(eventData.pointerDrag.gameObject);
        }

    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if(dropped != null)
        {
            if (!drop)
            {
                dropped.destroyed = true;
            }
            else
            {
                dropped.Drop = true;
            }
        }
        
      
       

    }


    private GameObject Commands(GameObject DroppedObject)
    {
        if (DroppedObject.tag == ("UP"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(up, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<UP>());
        }

        if (DroppedObject.tag == ("Down"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(down, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<Down>());
        }

        if (DroppedObject.tag == ("Right"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(right, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<Right>());
        }

        if (DroppedObject.tag == ("Left"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(left, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<Left>());
        }

        if (DroppedObject.tag == ("Destroy"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(destroy, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<DestroyBox>());
        }
        if (DroppedObject.tag == ("Func"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(function, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<Function>());
        }


        if (DroppedObject.tag == ("loop"))
        {

            Destroy(DroppedObject);
            DroppedObject = Instantiate(loopPref, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(transform, true);
            history.Execute(DroppedObject.GetComponent<LoopBlock>());
        }

        return DroppedObject;

    }

    private void SetPrefabs()
    {
        loopPref = master.Loop;
        up = master.Up;
        down = master.Down;
        right = master.Right;
        left = master.Left;
        destroy = master.Destroy;
        function = master.Function;
    }

    public LoopBlockCommand History
    {
        get { return history; }
        set { history = value; }
    }

}
