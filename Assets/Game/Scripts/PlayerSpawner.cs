using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner<PlayerController>
{
    public List<Color> colors;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void AfterSpawn(PlayerController player, int index) {
        if(colors.Count == 0) {
            return;
        }

        Color color = colors[index % colors.Count];
        player.id = index+1;
    }
}
