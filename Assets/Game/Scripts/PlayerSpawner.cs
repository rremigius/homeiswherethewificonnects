using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : Spawner<PlayerController>
{
    //public List<Color> colors = new List<Color>();
    public Color[] colors2;

    // Start is called before the first frame update
    void Start()
    {
        if (colors2.Length==0)
        {
            colors2 = new Color[] { Color.yellow, Color.red, Color.magenta, Color.cyan };
        }
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
