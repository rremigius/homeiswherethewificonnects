using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public PlayerController assignedPlayer;

    public delegate void ActionSuccess();
    public static event ActionSuccess BroadCastSuccess;

    public bool IsAssigned { get; private set; } = false;
    public bool IsTaskInProgress { get; private set; } = false;
    public float TaskDuration = 1;
    public float Points = 10;
    

    private PlayerController PC;
    private float TargetTime;
    private bool TimerActive = false;
    private Color UnhighlightedColor = new Color(0, 0, 0, 0);

    void Start()
    {
        //TODO check if box component available of requirement/required component bovenaan class
    }
    void Update()
    {
        if (TimerActive && Time.time >= TargetTime) {
                TimerActive = false;
                TaskCompleted();
        }
        
    }

    //Arms this interactive object with a char reference and a highlight, it can now be overlapped with
    public void AssignTask(PlayerController Player)
    {
        IsAssigned = true;
        assignedPlayer = Player;
        SetColor(Player.GetPlayerColor());
    }

    //when player enters trigger, check if its the correct player and if so start task
    private void OnTriggerEnter(Collider other)
    {
        if (IsColliderAssignedPlayer(other) && IsTaskInProgress==false)
        {
            PC = other.gameObject.GetComponent<PlayerController>();
            StartTask();
        }
    }
    private bool IsColliderAssignedPlayer(Collider other)
    {
        return assignedPlayer == other.gameObject.GetComponent<PlayerController>();
    }


    void StartTask()
    {
        IsTaskInProgress = true;
        PC.LockPlayer();
        
        //Activate minigame
        TargetTime = Time.time + TaskDuration;
        TimerActive = true;
        
    }

    void TaskCompleted()
    {
        PC.UnlockPlayer();
        if (BroadCastSuccess != null) { BroadCastSuccess(); }
        Reset();
    }

    void Reset()
    {
        assignedPlayer = null;
        IsTaskInProgress = false;
        IsAssigned = false;
        SetColor(UnhighlightedColor);
    }

    void SetColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", newColor);
    }
}
