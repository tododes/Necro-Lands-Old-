using UnityEngine;
using System.Collections;

public class RedKuntilanakSpawner : EnemySpawner
{
    protected override void Update()
    {
        if (GameManager.KuntilanakKill >= 100)
        {
            spawnInterval = 7f;
        }
        else if (GameManager.KuntilanakKill >= 60)
        {
            spawnInterval = 15f;
        }
        else if (GameManager.KuntilanakKill >= 30)
        {
            spawnInterval = 20f;
        }
    }
}
