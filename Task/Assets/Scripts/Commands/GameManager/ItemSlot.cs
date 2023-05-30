using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class ItemSlot : MonoBehaviour,IDropHandler
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
     private  Canvas canvas;
     private GameMaster master;
     private QueueCommand command;
     private ItemslotManager manager;



     private GameObject droppedObject;
   

    private void Awake()
    {
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        command = GameObject.FindGameObjectWithTag("Manager").GetComponent<QueueCommand>();
        manager = gameObject.GetComponent<ItemslotManager>();
        canvas = master._Canvas;
        SetPrefabs();
    }


    public void OnDrop(PointerEventData eventData)
    {
       if( eventData.pointerDrag != null)
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
            command.Execute(DroppedObject.GetComponent<UP>());
        }

        if (DroppedObject.tag == ("Down"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(down, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            command.Execute(DroppedObject.GetComponent<Down>());
        }

        if (DroppedObject.tag == ("Right"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(right, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            command.Execute(DroppedObject.GetComponent<Right>());
        }

        if (DroppedObject.tag == ("Left"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(left, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            command.Execute(DroppedObject.GetComponent<Left>());
        }

        if (DroppedObject.tag == ("Destroy"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(destroy, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            command.Execute(DroppedObject.GetComponent<DestroyBox>());
        }
        if (DroppedObject.tag == ("Func"))
        {
            Destroy(DroppedObject);
            DroppedObject = Instantiate(function, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            command.Execute(DroppedObject.GetComponent<Function>());
        }


        if(DroppedObject.tag == ("loop"))
        {

            Destroy(DroppedObject);
            DroppedObject = Instantiate(loopPref, transform.position, Quaternion.identity);
            DroppedObject.transform.SetParent(canvas.transform, true);
            command.Execute(DroppedObject.GetComponent<LoopBlock>());
        }

        return DroppedObject;
        
    }



    private void SetPrefabs()
    {
        loopPref = master.Loop;
        up = master.Up;
        down= master.Down;
        right= master.Right;
        left= master.Left;
        destroy = master.Destroy;
        function = master.Function;
    }
} 
