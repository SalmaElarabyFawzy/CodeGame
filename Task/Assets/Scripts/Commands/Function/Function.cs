using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Function : MonoBehaviour,ICommand
{
    [Header("Instance")]
    private GetExecute execute;
    private FunctionCommand history;
    private ButtonManager Out_Index;
  
    private float height;
    private Vector2 newPos;
    private IHistory _history;
    private int index = 0;



    private void Awake()
    {
      
        newPos = transform.position;
        execute = GameObject.FindGameObjectWithTag("Manager").GetComponent<GetExecute>();
        history = GameObject.FindGameObjectWithTag("Manager").GetComponent<FunctionCommand>();
        height =  GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>().Height;
        Out_Index = GetComponent<ButtonManager>();
    }
  
    public void Execute()
    {
     
        execute.loop(history.History);
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
        get { return _history; }
        set
        {
            _history = value;
            Out_Index.History = _history;

        }
    }

}
