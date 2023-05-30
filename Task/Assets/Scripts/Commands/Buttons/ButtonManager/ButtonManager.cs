using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    private int ind;
    private IHistory history;
   

    public int index
    { get { return ind; }
      set { ind = value; }
    }
    
    public IHistory History
    {
        get { return history; }
        set { history = value; }
    }
    
    
}
