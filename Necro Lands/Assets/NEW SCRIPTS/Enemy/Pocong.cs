using UnityEngine;
using System.Collections;

public class Pocong : Enemy {

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        if (HP <= 0 && gameObject.activeInHierarchy)
        {
            GameManager.kills++;
            GameManager.PocongKill++;
            VariousSceneKills();
            KillReward();
            gameObject.SetActive(false);
        }
        if (enemyAI.destination != target.position)
        {
            enemyAI.SetDestination(target.position);
        }

        
        if(isNavigable != (targetAttribute.HP > 0))
            isNavigable = (targetAttribute.HP > 0);

        if (isNavigable)
        {
            if (enemyAI.destination != target.position)
            {
                enemyAI.SetDestination(target.position);
                enemyAI.speed = MoveSpeed;
            }
        }
    }
}
