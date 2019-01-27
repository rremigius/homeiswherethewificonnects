using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameController : MonoBehaviour
{
    public int numberOfPlayers = 4;
    public GameObject menu;
    private float SongLength = 20;
    private float victoryTime;
    private bool PlayingGame;
    
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
        if((PlayingGame) && (Time.time >= victoryTime))
        {
            EventBus.FireVictory();
            PlayingGame = false;
        }
    }

    

    void OnVanCrashed(Van van) {
        EventBus.FireGameOver();
        PlayingGame = false;
    }

    public void NewGame() {
        foreach(PlayerController player in players) {
            Destroy(player.gameObject);
        }
        playerSpawner.Reset();
        players = playerSpawner.Spawn(numberOfPlayers);
        MyTaskManager = GetComponent<TaskManager>();
        MyTaskManager.StartTaskManager(players);
        victoryTime = Time.time + SongLength;
        PlayingGame = true;

        menu.SetActive(false);

        EventBus.FireNewGame();
    }
}
