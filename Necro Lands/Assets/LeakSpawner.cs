using UnityEngine;
using System.Collections;

public class LeakSpawner : EnemySpawner {

    protected override void Update()
    {
        if (GameManager.kills >= 150)
        {
            spawnInterval = 8f;
        }
        else if (GameManager.kills >= 100)
        {
            spawnInterval = 12f;
        }
        else if (GameManager.kills >= 50)
        {
            spawnInterval = 20f;
        }
    }
}
