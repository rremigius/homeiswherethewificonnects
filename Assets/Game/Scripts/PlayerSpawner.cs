﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner<PlayerController>
{
    public List<Color> colors = new List<Color>();
    public Color[] colors2 = { Color.yellow, Color.green, Color.magenta, Color.blue };

    override protected void Init() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void AfterSpawn(PlayerController player, int index) {
        if(colors2.Length == 0) {
            return;
        }

        Color color = colors2[index % colors2.Length];
        player.SetPlayerColor(color);
        player.id = index+1;
    }
}
