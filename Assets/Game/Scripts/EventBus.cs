using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public delegate void PlayerScore(PlayerController Player, int Score);
    public static event PlayerScore OnPlayerScored;

    void Start() { }
    void Update() { }

    public static void PlayerScored(PlayerController Player, int Score)
    {
        if (OnPlayerScored != null) { OnPlayerScored(Player, Score); }
    }

}
