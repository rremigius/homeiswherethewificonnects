﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner<PlayerController>
{
    //public List<Color> colors = new List<Color>();
    public Color[] colors;

    override protected void Init() {
        if (colors.Length==0) {
            colors = new Color[] { Color.yellow, Color.red, Color.magenta, Color.cyan };
        }
	}

    // Update is called once per frame
    void Update() {
        
    }

    override protected void AfterSpawn(PlayerController player, int index) {
        if(colors.Length == 0) {
            return;
        }

        Color color = colors[index % colors.Length];
        player.SetPlayerColor(color);
        player.id = index+1;
    }
}
