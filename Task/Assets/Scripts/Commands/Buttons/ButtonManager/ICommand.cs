using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand 
{
    void Execute();
    void MoveUp(GameObject removed);
    int Index { get; set; }
    IHistory History { get; set; }
}
