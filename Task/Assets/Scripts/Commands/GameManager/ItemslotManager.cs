using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemslotManager : MonoBehaviour
{

    private float height;
    private Vector2 newPos;
    private void Awake()
    {
        height = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>().Height;
        newPos = transform.position;
    }
    public void MoveUP(GameObject droppedObject)
    {
        newPos.y += droppedObject.GetComponent<RectTransform>().rect.height + height;
       
        transform.position = newPos;
    }


    public void MoveDown(GameObject droppedObject)
    {
       
        newPos.y -= droppedObject.GetComponent<RectTransform>().rect.height + height;
        transform.position = newPos;

    }
}
