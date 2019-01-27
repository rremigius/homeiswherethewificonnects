using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;
    private PlayerSpawner playerSpawner;
    private TaskManager MyTaskManager;
    
    List<PlayerController> players = new List<PlayerController>();

    void Start()
    {
        playerSpawner = GetComponent<PlayerSpawner>();
        Assert.IsNotNull(playerSpawner);

        EventBus.OnVanCrashed += OnVanCrashed;

        Reset();
    }

    void Update()
    {
       
    }

    void OnVanCrashed(Van van) {
        EventBus.FireGameOver();
    }

    public void Reset() {
        foreach(PlayerController player in players) {
            Destroy(player.gameObject);
        }
        playerSpawner.Reset();
        players = playerSpawner.Spawn(numberOfPlayers);
        MyTaskManager = GetComponent<TaskManager>();
        MyTaskManager.StartTaskManager(players);

        EventBus.FireNewGame();
    }
}
