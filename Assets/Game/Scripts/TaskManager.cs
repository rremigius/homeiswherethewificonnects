using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private bool Active = false;
    private PlayerController[] Players;

    public Transform InteractiveObjectGrouper;
    private InteractiveObject[] IOArray;


    void StartTaskManager(PlayerController[] activePlayers)
    {
        Active = true;
        Players = activePlayers;
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
}
