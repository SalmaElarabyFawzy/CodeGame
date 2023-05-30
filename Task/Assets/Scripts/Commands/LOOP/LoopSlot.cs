using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;

public class LoopSlot : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] private GameObject parent;


    private bool drop = true;
    private bool destroy = false;
    private bool newdrop = false;
    private GameObject slotobject;
    private GameObject slotpref;

    [Header("Instance")]
    private ItemslotManager manager;
    private ItemslotManager BasicSlot;
    private GameObject canvas;
    private LoopBlockCommand history;
    private GameMaster master;


    private void Awake()
    {
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        BasicSlot = GameObject.FindGameObjectWithTag("BasicSlot").GetComponent<ItemslotManager>();
        manager = GetComponent<ItemslotManager>();
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        history = parent.GetComponent<LoopBlockCommand>();
        slotpref = master.LoopSlotPref;

    }




    public void OnPointerEnter(PointerEventData eventData)
    {
    
        if (drop)
        {
            slotobject = Instantiate(slotpref, transform.position, Quaternion.identity);
            slotobject.GetComponent<LoopItemSlot>().History = history;
            manager.MoveDown(slotobject);
            BasicSlot.MoveDown(slotobject);
            slotobject.transform.SetParent(transform, true);
            drop = false;
            newdrop = false;
        }
         
    }


    private void Update()
    {
        if(destroy)
        {
            manager.MoveUP(slotobject);
            BasicSlot.MoveUP(slotobject);
            Destroy(slotobject,.02f);
            drop = true;
            destroyed = false;
        }
       else if(newdrop) 
        {
            slotobject.transform.SetParent(transform, false);
            slotobject.transform.SetParent(canvas.transform, true);
            newdrop = false;
            drop = true;
        
        }
    }


    public bool destroyed
    {
        set { destroy = value; }
    }

    public bool Drop
    {
        set { newdrop = value; }
    }

}


