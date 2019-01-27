using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;
    public GameObject menu;
    
    PlayerSpawner playerSpawner;
    TaskManager MyTaskManager;
    
    List<PlayerController> players = new List<PlayerController>();

    void Start()
    {
        playerSpawner = GetComponent<PlayerSpawner>();

        Assert.IsNotNull(playerSpawner);
        Assert.IsNotNull(menu);

        EventBus.OnVanCrashed += OnVanCrashed;

        menu.SetActive(true);
    }

    void Update()
    {
       
    }

    void OnVanCrashed(Van van) {
        EventBus.FireGameOver();
    }

    public void NewGame() {
        foreach(PlayerController player in players) {
            Destroy(player.gameObject);
        }
        playerSpawner.Reset();
        players = playerSpawner.Spawn(numberOfPlayers);
        MyTaskManager = GetComponent<TaskManager>();
        MyTaskManager.StartTaskManager(players);

        menu.SetActive(false);

        EventBus.FireNewGame();
    }
}
