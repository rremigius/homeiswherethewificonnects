using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public PlayerController assignedPlayer;

    public delegate void ActionSuccess();
    public static event ActionSuccess BroadCastSuccess;

    public bool IsOccupied { get; private set; }
    public float TaskDuration;

    InteractiveObject() // set defaults
    {
        IsOccupied = false;
    }
    void Start()
    {
        //TODO check if box component available of requirement/required component bovenaan class
    }
    void Update() { }

    //when player enters trigger, check if its the correct player
    private void OnTriggerEnter(Collider other)
    {
        if (IsColliderAssignedPlayer(other))
        {
            IsOccupied = true;
            //Activate minigame
            //If Succesfull
            IsOccupied = false;
            BroadCastSuccess();
        }
    }

    private bool IsColliderAssignedPlayer(Collider other)
    {
        return assignedPlayer == other.gameObject.GetComponent<PlayerController>();
    }

    

}
