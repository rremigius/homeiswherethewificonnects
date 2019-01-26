using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;
    public PlayerSpawner playerSpawner;
    private TaskManager MyTaskManager;

    void Start()
    {
        Assert.IsNotNull(playerSpawner);
        var Players = playerSpawner.Spawn(numberOfPlayers);
        MyTaskManager = GetComponent<TaskManager>();
    }


    void Update()
    {
       
    }


    
}
