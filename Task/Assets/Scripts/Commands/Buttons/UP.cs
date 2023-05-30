using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP : MonoBehaviour, ICommand
{
    [Header("Instance")]
    private Commands PlayerAction;
    private ButtonManager Out_Index;
    private IHistory history;
    private GameMaster master;


    private Vector2 newPos;
    private int index = 0;
    private float height;
    private void Awake()
    {
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        PlayerAction = GameObject.FindGameObjectWithTag("Player").GetComponent<Commands>();
        newPos = transform.position;
        Out_Index = GetComponent<ButtonManager>();
        height = master.Height;
    }
    public void Execute()
    {
        PlayerAction.UP();
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
        set {
            history = value;
            Out_Index.History = history;
        }
    }
}
