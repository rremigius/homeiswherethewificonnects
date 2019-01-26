using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public PlayerController assignedPlayer;
    private TextMesh SecondsRemainingText;


    public bool IsAssigned { get; private set; } = false;
    public bool IsTaskInProgress { get; private set; } = false;
    public float TaskDuration = 1;
    public float CooldownDuration = 5;
    public int Points = 10;
    

    private PlayerController PC;
    private float TaskTargetTime;
    private float CooldownTargetTime;
    private bool TaskTimerActive = false;
    private bool CooldownTimerActive = false;
    private Color UnhighlightedColor = new Color(0, 0, 0, 0);

    void Start()
    {
        //TODO check if box component available of requirement/required component bovenaan class
    }
    void Update()
    {
        if (TaskTimerActive)
        {
            SetTaskTimeRemainingText(TaskTargetTime-Time.time);
            if (Time.time >= TaskTargetTime)
            {
                TaskTimerActive = false;
                SetTaskTimeRemainingText(0);
                TaskCompleted();
            }
        }
            
        if (CooldownTimerActive && Time.time >= CooldownTargetTime)
        {
            CooldownTimerActive = false;
            CooldownCompleted();
        }

    }

    //Arms this interactive object with a char reference and a highlight, it can now be overlapped with
    public void AssignTask(PlayerController Player)
    {
        IsAssigned = true;
        assignedPlayer = Player;
        SetColor(Player.GetPlayerColor());
        SetTaskTimeRemainingText(TaskDuration);
    }

    //when player enters trigger, check if its the correct player and if so start task
    private void OnTriggerEnter(Collider other)
    {
        if (IsColliderAssignedPlayer(other) && IsTaskInProgress==false)
        {
            PC = other.gameObject.GetComponent<PlayerController>();
            if (PC != null) { StartTask(); }
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
        TaskTargetTime = Time.time + TaskDuration;
        TaskTimerActive = true;
        
    }

    void TaskCompleted()
    {
        PC.UnlockPlayer();
        EventBus.PlayerScored(PC, Points);
        Reset();
    }

    void Reset()
    {
        assignedPlayer.HasTaskAssigned = false;
        assignedPlayer = null;
        IsTaskInProgress = false;

        CooldownTargetTime = Time.time + CooldownDuration;
        CooldownTimerActive = true;

        SetColor(UnhighlightedColor);
    }

    void CooldownCompleted()
    {
        IsAssigned = false;
    }

    void SetColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", newColor);
    }

    void SetTaskTimeRemainingText(float Time)
    {
        //find text mesh if no reference exists yet
        if (SecondsRemainingText == null)
        {
            SecondsRemainingText = GetComponentInChildren<TextMesh>();
        }
        if (SecondsRemainingText == null) { Debug.LogWarning("Couldn't find a TextMesh component in child"); return; }

        //return time + "sec" or nothing if time is 0
        if (Time == 0) { SecondsRemainingText.text = ""; return; } 
        SecondsRemainingText.text = Time.ToString("F1")+ " sec";
    }

}
