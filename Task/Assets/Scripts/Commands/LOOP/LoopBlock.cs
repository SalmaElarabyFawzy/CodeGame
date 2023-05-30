using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public class LoopBlock : MonoBehaviour, ICommand
{
    [Header("Loop Count")]
    private InputField count;


    [Header("Instance")]
    private LoopBlockCommand Loophistory;
    private ButtonManager Out_Index;
    private GameMaster master;
    private IHistory history;
   
    private float height;
    private Vector2 newPos;
    private int index = 0;

    private void Awake()
    {
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        Loophistory = GetComponent<LoopBlockCommand>();
        count = transform.GetChild(2).GetComponent<InputField>();
        Out_Index = GetComponent<ButtonManager>();
        newPos = transform.position;
        height = master.Height;
   
    }


    public void Execute()
    {
        Debug.Log("Executed !");
        
        loop();
    }

    private void loop()
    {
       
            if (count.text != null)
            {
                int counter = int.Parse(count.text);
                for (int i = 0; i < counter; i++)
                {
                    foreach (ICommand command in Loophistory.History)
                    {
                      
                        Debug.Log("Done !");
                        command.Execute();

                       
                    }
                }
            }

       
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
