﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueCommand : MonoBehaviour,IHistory
{

    private List<ICommand> history = new List<ICommand>();


    [Header("Instance")]
    private ItemslotManager BasicSlot;
    public QueueCommand instance;

    private void Awake()
    {
        instance= this;
        BasicSlot = GameObject.FindGameObjectWithTag("BasicSlot").GetComponent<ItemslotManager>();
    }


    public void Execute(ICommand command)
    {
        history.Add(command);
        if(history.Count !=0 )
        {
            command.Index= history.Count - 1;
        }
        command.History = instance;
    }


    public void Remove(int index,GameObject removed)
    {
        if (history.Count == 0) return;
        for(int i= index+1; i< history.Count;i++) 
        {
            history[i].MoveUp(removed);
        }
        BasicSlot.MoveUP(removed);
        history.RemoveAt(index);
        Destroy(removed);
    }



    public List<ICommand> History
    {
        get { return history; }
    }
}
