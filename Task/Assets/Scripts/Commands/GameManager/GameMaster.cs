using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [Header(" Buttons Height")]
    [SerializeField] private float height = 20f;


    [Header("Buttons Prefabs")]
    [SerializeField] private GameObject loopPref;
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject right;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject function;
    [SerializeField] private GameObject destroy;

    [Header("Canvas")]
    [SerializeField] Canvas canvas;


    [Header("Player")]
    [SerializeField] private float playerStep = 1f;
    [SerializeField] private LayerMask trap;

    [Header("Loop Prefabs")]
   [SerializeField] private GameObject loopSlotPref;





    public float Height
    {
        get{ return height; }
    }
    public GameObject Loop
    { get { return loopPref; } }

    public GameObject Up
    { get { return up; } }

    public GameObject Down 
    { get { return down; } }

    public GameObject Right
    { get { return right; } }

    public GameObject Left
    { get { return left; } }

    public GameObject Function
    { get { return function; } }

    public GameObject Destroy
    {
        get { return destroy; }
    }
    public Canvas _Canvas
    { get { return canvas; } }
    public float  PlayerStep
    {
        get { return playerStep; }
    }
    public LayerMask Trap
    { get { return trap; } }
    public GameObject LoopSlotPref
    {
        get { return loopSlotPref; }
    }
}
