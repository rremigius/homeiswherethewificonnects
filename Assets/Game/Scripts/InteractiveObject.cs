using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public float nummertje;
    public PlayerController assignedPlayer;

    public delegate void ActionSuccess();
    public static event ActionSuccess BroadCastSuccess;
        

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
            //Activate minigame
            //If Succesfull
            BroadCastSuccess();
        }
    }

    private bool IsColliderAssignedPlayer(Collider other)
    {
        return (assignedPlayer == other);
    }

 

}
