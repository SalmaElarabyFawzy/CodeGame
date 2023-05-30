using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
public class GetExecute : MonoBehaviour
{

 

    public void loop(List<ICommand> history)
    {
      
        foreach (ICommand command in history)
        {
              if (command != null) command.Execute();
        }
    }
}
