using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private bool Active = false;
    private List<PlayerController> Players;

    public Transform InteractiveObjectGrouper;
    private InteractiveObject[] IOArray;


    public void StartTaskManager(List<PlayerController> activePlayers)
    {
        Active = true;
        Players = activePlayers;
        List<PlayerController> IdlePlayers = GetPlayersWithoutTask();
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        GatherInteractiveObjects();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
        {


        }
    }

    //get all interactive objects that are parented to the IOGrouper
    void GatherInteractiveObjects()
    {
        if (InteractiveObjectGrouper != null)
        {
            IOArray = InteractiveObjectGrouper.GetComponentsInChildren<InteractiveObject>();
            if (IOArray.Length == 0) { Debug.LogWarning("No interactive objects found under interactive object grouper"); }
        }
        else
        {
            Debug.LogWarning("No Interactive Objects grouper reference set on game controller");
        }
        return;
    }

    List<PlayerController> GetPlayersWithoutTask()
    {
        List<PlayerController> IdlePlayers = new List<PlayerController>();
        foreach (PlayerController Player in Players )
        {
            if (!Player.HasTaskAssigned) { IdlePlayers.Add(Player); }
        }
        return IdlePlayers;
    }
}
