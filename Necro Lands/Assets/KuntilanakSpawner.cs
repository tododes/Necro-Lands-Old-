using UnityEngine;
using System.Collections;

public class KuntilanakSpawner : EnemySpawner
{
    protected override void Update()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        spawnInterval = player.G == Player.Gender.BOY ? 15f : 40f;
    }

}
