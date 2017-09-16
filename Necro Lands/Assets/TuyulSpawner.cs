using UnityEngine;
using System.Collections;

public class TuyulSpawner : EnemySpawner {

    private TimeManager manager;
    protected override void Update()
    {
        if(!manager)
        {
            manager = TimeManager.GetInstance();
        }
        
        if(manager.GetDurationSeconds() >= 270)
        {
            spawnInterval = 5f;
        }
        else if (manager.GetDurationSeconds() >= 180)
        {
            spawnInterval = 10f;
        }
        else if (manager.GetDurationSeconds() >= 90)
        {
            spawnInterval = 20f;
        }
    }
}
