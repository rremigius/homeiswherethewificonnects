using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform InteractiveObjectGrouper;

    private InteractiveObject[] IOArray;


    void Start()
    {
        GatherInteractiveObjects();

    }


    void Update()
    {
        //TODO Set interactive object target for a player
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
