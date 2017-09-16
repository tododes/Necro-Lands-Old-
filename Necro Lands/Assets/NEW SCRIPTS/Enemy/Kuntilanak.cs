using UnityEngine;
using System.Collections;

public class Kuntilanak : Enemy {

    private EnemyBodyRender myRender;
    private Player playerTarget;
	// Use this for initialization
    public override void Start()
    {
        base.Start();
        myRender = GetComponent<EnemyBodyRender>();
    }

    public override void Update()
    {
        if (HP <= 0 && gameObject.activeInHierarchy)
        {
            GameManager.kills++;
            if(gameObject.name.Contains("Red"))
                GameManager.RedKuntilanakKill++;
            else
                GameManager.KuntilanakKill++;
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

    void LateUpdate()
    {
        if(!target)
        {
            playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        if (!anim.GetBool("InRange") && myRender.enabled)
        {
            myRender.enabled = false;
        }
        else if (anim.GetBool("InRange") && !myRender.enabled)
        {
            myRender.enabled = true;
        }

        if(playerTarget.HP < 0.2f * playerTarget.MaxHP)
        {
            MoveSpeed = OriMoveSpeed + 2f;
            Attack = OriAttack + 20f;
        }
        else if (playerTarget.HP < 0.4f * playerTarget.MaxHP)
        {
            MoveSpeed = OriMoveSpeed + 4f;
            Attack = OriAttack + 40f;
        }
        else if (playerTarget.HP < 0.6f * playerTarget.MaxHP)
        {
            MoveSpeed = OriMoveSpeed + 6f;
            Attack = OriAttack + 60f;
        }
        else if (playerTarget.HP < 0.8f * playerTarget.MaxHP)
        {
            MoveSpeed = OriMoveSpeed + 8f;
            Attack = OriAttack + 80f;
        }
    }

    public override float AttackMod(float d)
    {
        if (gameObject.name.Contains("4"))
        {
            HP += 0.8f * d;
        }

        else if (gameObject.name.Contains("3"))
        {
            HP += 0.6f * d;
        }

        else if (gameObject.name.Contains("2"))
        {
            HP += 0.4f * d;
        }

        else
        {
            HP += 0.2f * d;
        }
        return d;
    }
}
