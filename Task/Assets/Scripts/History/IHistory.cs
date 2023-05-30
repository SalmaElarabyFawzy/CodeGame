using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHistory 
{
    void Execute(ICommand command);
    void Remove(int index , GameObject removed);
}
