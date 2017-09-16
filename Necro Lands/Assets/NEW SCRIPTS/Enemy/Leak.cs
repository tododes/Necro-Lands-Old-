using UnityEngine;
using System.Collections;

public class Leak : Enemy {

    public override void Update()
    {
        if (HP <= 0 && gameObject.activeInHierarchy)
        {
            GameManager.kills++;
            GameManager.LeakKill++;
            VariousSceneKills();
            KillReward();

            gameObject.SetActive(false);
        }

        enemyAI.SetDestination(target.position);
        enemyAI.speed = MoveSpeed;


        if (anim.GetBool("InRange"))
        {
            Attacking();
        }
    }

}
