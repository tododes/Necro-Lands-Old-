using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public float attackInterval;

    private Status playerStatus;
    private EnemyStatus enemyStatus;
    private EnemyAbilities enemyAbilities;
    private float attackTimer;
    private bool playerInRange;
    private Animator anim;
    private HashIDs hash;
    

    // Use this for initialization
    void Start () {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
        enemyAbilities = GetComponent<EnemyAbilities>();
        enemyStatus = GetComponent<EnemyStatus>();
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (playerInRange && !StartupManager.isFinished)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > attackInterval)
            {
                
                attackTimer = 0f;

                float totalDamage = enemyStatus.attack - playerStatus.armor / 2;
                if (totalDamage < 2f)
                    totalDamage = 2f;
                if (gameObject.name.Contains("Kuntil Anak"))
                    enemyAbilities.KuntialAnakSkill(totalDamage);
                else if (gameObject.name.Contains("Begu Ganjang"))
                    totalDamage += enemyAbilities.BeguGanjangSkill(totalDamage);

               
                playerStatus.GotDamaged(totalDamage);
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (!playerInRange && other.gameObject.tag == "Player")
        {
            playerInRange = true;
            anim.SetBool(hash.attackBool, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (playerInRange && other.gameObject.tag == "Player")
        {
            playerInRange = false;
            anim.SetBool(hash.attackBool, false);
        }
    }
}
