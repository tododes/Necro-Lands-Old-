using UnityEngine;
using System.Collections;

public class Genderuwo : Enemy {

	// Use this for initialization
    public override void Start() 
    {
        base.Start();
	}

    public override void Update()
    {
        if (HP <= 0 && gameObject.activeInHierarchy)
        {
            GameManager.kills++;
            GameManager.GenderuwoKill++;
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

    public override float AttackMod(float d)
    {
        if (targetAttribute.G == Player.Gender.GIRL)
        {
            if (gameObject.name.Contains("4"))
            {
                d = d + 90;
            }

            else if (gameObject.name.Contains("3"))
            {
                d = d + 70;
            }

            else if (gameObject.name.Contains("2"))
            {
                d = d + 50;
            }

            else
            {
                d = d + 30;
            }
        }
        return d;
    }
}
