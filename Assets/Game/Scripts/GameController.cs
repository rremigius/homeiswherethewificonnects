using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;
    private PlayerSpawner playerSpawner;
    private TaskManager MyTaskManager;
    

    void Start()
    {
        playerSpawner = GetComponent<PlayerSpawner>();
        //Assert.IsNotNull(playerSpawner);
        List<PlayerController> Players = playerSpawner.Spawn(numberOfPlayers);
        MyTaskManager = GetComponent<TaskManager>();
        MyTaskManager.StartTaskManager(Players);
        EventBus.OnPlayerScored += Test;
    }

    void Test(PlayerController PC, float Score)
    {
        Debug.Log("gescoord");
    }

    void Update()
    {
       
    }

    

    
}
