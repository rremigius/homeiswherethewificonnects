using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : Spawner<Obstacle>
{

    public float period = 5;
    public float nextActionTime = 5;
    
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            Spawn();
        }
    }
}
