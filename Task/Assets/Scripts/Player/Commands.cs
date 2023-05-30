using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commands : MonoBehaviour
{
    [Header("Instance")]
    private GameMaster master;


    private float step;
    private Vector2 pos;
    private LayerMask trap;
 
    void Awake()
    {
        master = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMaster>();
        step = master.PlayerStep;
        trap = master.Trap;
        pos= transform.position;
    }


    public void DestroyTrap()
    {
        RaycastHit2D hit;
       hit =  Physics2D.Raycast(transform.position, Vector2.right,1, trap);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Destroy(hit.collider.gameObject);
        }
    }
    public void UP()
    {
        pos.y += step;
        transform.position = pos;
    }


    public void Down()
    {
        pos.y -= step;
        transform.position = pos;
    }


    public void Right()
    {
        pos.x += step;
        transform.position = pos;
    }

    public void Left()
    {

        pos.x -= step;
        transform.position = pos;
    }
}
