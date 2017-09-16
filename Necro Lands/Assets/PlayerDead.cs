using UnityEngine;
using System.Collections;

public class PlayerDead : MonoBehaviour {

    private Status playerStatus;
    private HashIDs hash;
    private PlayerMovement playerMovement;
    private bool playerDead;
    private Animator anim;

	// Use this for initialization
	void Start () {
        playerStatus = GetComponent<Status>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        playerMovement = GetComponent<PlayerMovement>();
        playerDead = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(playerStatus.hp <= 0)
        {
            if (!playerDead)
            {
                PlayerDying();
            }
            else
                PlayerIsDead();
        }
	}

    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, playerDead);
    }

    void PlayerIsDead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.dyingState)
            anim.SetBool(hash.deadBool, false);

        anim.SetFloat(hash.speedFloat, 0f);
        playerMovement.enabled = false;
    }
}
