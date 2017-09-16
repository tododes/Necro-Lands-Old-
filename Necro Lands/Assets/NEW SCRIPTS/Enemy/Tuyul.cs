using UnityEngine;
using System.Collections;

public class Tuyul : Enemy {

    private int stealChance;
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
            GameManager.TuyulKill++;
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
        stealChance = Random.Range(0,100);
        if(stealChance < 40)
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - 2);
        return d;
    }
	
}
