using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    public delegate void PlayerScore(PlayerController Player, int Score);
    public static event PlayerScore OnPlayerScored;

    public delegate void VanDamage(Van van, Obstacle cause, float damage);
    public static event VanDamage OnVanDamaged;

    public delegate void VanCrash(Van van);
    public static event VanCrash OnVanCrashed;

    public delegate void GameOver();
    public static event GameOver OnGameOver;

    public delegate void NewGame();
    public static event NewGame OnNewGame;

    public delegate void Victory();
    public static event Victory OnVictory;

    public static void FireVictory() {
        if (OnVictory != null) OnVictory();
    }

    public static void FirePlayerScored(PlayerController Player, int Score) {
        if (OnPlayerScored != null) OnPlayerScored(Player, Score);
    }

    public static void FireVanDamaged(Van van, Obstacle cause, float damage) {
        if(OnVanDamaged != null) OnVanDamaged(van, cause, damage);
    }

    public static void FireVanCrashed(Van van) {
        if(OnVanCrashed != null) OnVanCrashed(van);
    }

    public static void FireGameOver() {
        if(OnGameOver != null) OnGameOver();
    }

    public static void FireNewGame() {
        if(OnNewGame != null) OnNewGame();
    }
}
