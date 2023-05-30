using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RUN : MonoBehaviour
{
    [Header("Instance")]
    private GetExecute execute;
    private QueueCommand command;
    private Button interact;

    private void Awake()
    {
        interact = GetComponent<Button>();
        command = GameObject.FindGameObjectWithTag("Manager").GetComponent<QueueCommand>();
        execute = GameObject.FindGameObjectWithTag("Manager").GetComponent<GetExecute>();
    }
    public void OnRun()
    {
       
        execute.loop(command.History);
 
         interact.interactable = false;
    }
}
 