using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Right : MonoBehaviour,ICommand
{
    [Header("Instance")]
    private Commands PlayerActtion;
    private IHistory history;
    private ButtonManager Out_Index;
    private GameMaster master;

    private Vector2 newPos;
    private int index = 0;
     private float height;


    private void Awake()
    {
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        newPos = transform.position;
        PlayerActtion = GameObject.FindGameObjectWithTag("Player").GetComponent<Commands>();
        Out_Index = GetComponent<ButtonManager>();
        height = master.Height;
    }
    public void Execute()
    {
        PlayerActtion.Right();
    }

    public void MoveUp(GameObject removed)
    {
        newPos.y += removed.GetComponent<RectTransform>().rect.height + height;
        transform.position = newPos;
    }
    public int Index
    {
        get { return index; }
        set
        {
            index = value;
            Out_Index.index = index;
        }
    }
    public IHistory History
    {
        get { return history; }
        set
        {
            history = value;
            Out_Index.History = history;
        }
    }
}
