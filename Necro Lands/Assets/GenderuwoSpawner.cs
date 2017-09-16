using UnityEngine;
using System.Collections;

public class GenderuwoSpawner : EnemySpawner
{
    protected override void Update()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        spawnInterval = player.G == Player.Gender.GIRL ? 15f : 40f;
    }
}
