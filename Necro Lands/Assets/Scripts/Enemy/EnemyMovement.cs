using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;
    private EnemyStatus enemyStatus;
    private Animator anim;
    private HashIDs hash;
    private bool attackPlayer;
    private Status playerStatus;

    // Use this for initialization
    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyStatus = GetComponent<EnemyStatus>();
        playerStatus = player.GetComponent<Status>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartupManager.isStarted && playerStatus.hp > 0)
        {
            if (gameObject.name.Contains("Kunti"))
            {
                KuntilanakRunMech();
            }
            else
                agent.speed = enemyStatus.speed;
            agent.SetDestination(player.transform.position);
          
        }
     
    }

    void KuntilanakRunMech()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 20f && Vector3.Distance(transform.position, player.transform.position) > 5f)
        {
           
            if (agent.speed <= 13f)
            {
                agent.speed += 9 * Time.deltaTime;
            }
        }
        else
        {
            if (agent.speed >= 4f)
            {
                agent.speed = 4f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            //anim.SetBool(hash.attackBool, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            //anim.SetBool(hash.attackBool, false);
        }
    }
}
