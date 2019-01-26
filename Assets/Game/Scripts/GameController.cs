using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;

    public Spawner playerSpawner;

    private Color[] PlayerColors = { Color.green, Color.magenta, Color.yellow, Color.blue };
    private Vector3[] StartPositions = { new Vector3(0, 1, 0), new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, -1, 0) };


    void Start()
    {
        Assert.IsNotNull(playerSpawner);
        playerSpawner.Spawn(numberOfPlayers);
    }


    void Update()
    {
       
    }


    
}
