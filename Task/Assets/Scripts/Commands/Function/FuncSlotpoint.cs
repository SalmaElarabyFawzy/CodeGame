using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Timeline;

public class FuncSlotpoint : MonoBehaviour, IDropHandler
{
    [Header("Buttons Prefabs")]
     private GameObject loopPref;
     private GameObject up;
     private GameObject down;
     private GameObject right;
     private GameObject left;
     private GameObject function;
     private GameObject destroy;

    [Header("Instance")]
    private FunctionCommand history;
    private GameMaster master;
    private GameObject droppedObject;
    private ItemslotManager manager;
    private GameObject canvas;

    private void Awake()
    {
        history = GameObject.FindGameObjectWithTag("Manager").GetComponent<FunctionCommand>();
        manager = gameObject.GetComponent<ItemslotManager>();
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        SetPrefabs();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            droppedObject = Commands(eventData.pointerDrag.gameObject);
            manager.MoveDown(droppedObject);
        }

    }



    private GameObject Commands(GameObject DroppedObject)
    {
        if (DroppedObject.tag == ("UP"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(up, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            history.Execute(DroppedObject.GetComponent<UP>());
        }

        if (DroppedObject.tag == ("Down"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(down, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            history.Execute(DroppedObject.GetComponent<Down>());
        }

        if (DroppedObject.tag == ("Right"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(right, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            history.Execute(DroppedObject.GetComponent<Right>());
        }

        if (DroppedObject.tag == ("Left"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(left, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            history.Execute(DroppedObject.GetComponent<Left>());
        }

        if (DroppedObject.tag == ("Destroy"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(destroy, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            history.Execute(DroppedObject.GetComponent<DestroyBox>());
        }
        if (DroppedObject.tag == ("Func"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(function, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            history.Execute(DroppedObject.GetComponent<Function>());
        }
         

        if (DroppedObject.tag == ("loop"))
        {

            Destroy(DroppedObject);
            DroppedObject = Instantiate(loopPref, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
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

}