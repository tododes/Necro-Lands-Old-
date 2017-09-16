using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [Header("ATTRIBUTE")]
    public float HP;
    public float MaxHP;
    public float Mana;
    public float MaxMana;
    public float Attack;
    public float Armor;
    public float MoveSpeed;
    public int AttackSpeed;
    public float OriAttack;
    public float OriMoveSpeed;
    [Header("STATE")]
    public STATE ENEMYSTATE;
    public enum STATE
    { 
        CHASE, ATTACK, DEAD
    }

    public AudioSource HurtGrowl;

    [Header("DEAD EARNING (GUARANTEE)")]
    public int GuaranteeGold;
    public int GuaranteePlayerExp;
    public int GuaranteeExp;
    public int GuaranteeNecroGold;

    [Header("DEAD EARNING (POSSIBLE)")]
    public int chance;
    public int PossibleGold;
    public int PossibleNecroGold;
    
    protected Transform target;
    protected Animator anim;
    protected UnityEngine.AI.NavMeshAgent enemyAI;

    protected float AttackInterval;
    protected Modifier playerModifier;
    protected Player targetAttribute;
    protected GameObject mainManager;
    protected Vector3 originPos;
    protected EnemyItemDrop enemyDrop;

    protected bool isNavigable;

    protected void OnEnable()
    {
        enemyDrop = GetComponent<EnemyItemDrop>();
        /*if (Application.loadedLevelName.Contains("Boss"))
        {
            if (transform.localScale != new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f))
                transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
        }
        if (Application.loadedLevelName.Contains("Mega Boss"))
        {
            if (transform.localScale != new Vector3(transform.localScale.x * 3f, transform.localScale.y * 3f, transform.localScale.z * 3f))
                transform.localScale = new Vector3(transform.localScale.x * 3f, transform.localScale.y * 3f, transform.localScale.z * 3f);
        }
       */
        if (Application.loadedLevelName.Contains("Boss"))
        {
            transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
            MaxHP *= 2f;
            HP *= 2f;
            Mana *= 2f;
            MaxMana *= 2f;
            Attack *= 2f;
            Armor *= 2f;
        }

        if (Application.loadedLevelName.Contains("Mega Boss"))
        {
            transform.localScale = new Vector3(transform.localScale.x * 3f, transform.localScale.y * 3f, transform.localScale.z * 3f);
            MaxHP *= 3f;
            HP *= 3f;
            Mana *= 3f;
            MaxMana *= 3f;
            Attack *= 3f;
            Armor *= 3f;
        }
        MaxHP += SpawnEnemy.spawnScale;
        HP = MaxHP;
        MaxMana += SpawnEnemy.spawnScale;
        Mana = MaxMana;
        Attack += SpawnEnemy.spawnScale;
        Armor += SpawnEnemy.spawnScale;

        OriAttack = Attack;
        OriMoveSpeed = MoveSpeed;

       
    }

    protected void OnDisable()
    {
        transform.position = originPos;
        if (Application.loadedLevelName.Contains("Boss"))
        {
            transform.localScale = new Vector3(transform.localScale.x / 2f, transform.localScale.y / 2f, transform.localScale.z / 2f);
            MaxHP /= 2f;
            HP /= 2f;
            Mana /= 2f;
            MaxMana /= 2f;
            Attack /= 2f;
            Armor /= 2f;
        }

        if (Application.loadedLevelName.Contains("Mega Boss"))
        {
            transform.localScale = new Vector3(transform.localScale.x / 3f, transform.localScale.y / 3f, transform.localScale.z / 3f);
            MaxHP /= 3f;
            HP /= 3f;
            Mana /= 3f;
            MaxMana /= 3f;
            Attack /= 3f;
            Armor /= 3f;
        }
    }

    public void Awake()
    {
        originPos = transform.position;
        HurtGrowl = GetComponent<AudioSource>();
        /*if (Application.loadedLevelName.Contains("Boss"))
        {
            transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
            MaxHP *= 2f;
            HP *= 2f;
            Mana *= 2f;
            MaxMana *= 2f;
            Attack *= 2f;
            Armor *= 2f;
        }

        if (Application.loadedLevelName.Contains("Mega Boss"))
        {
            transform.localScale = new Vector3(transform.localScale.x * 3f, transform.localScale.y * 3f, transform.localScale.z * 3f);
            MaxHP *= 3f;
            HP *= 3f;
            Mana *= 3f;
            MaxMana *= 3f;
            Attack *= 3f;
            Armor *= 3f;
        }*/
        isNavigable = true;
    }

    public virtual void Start()
    {
        anim = GetComponent<Animator>();
        enemyAI = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        AttackInterval = 80f / AttackSpeed;
        targetAttribute = target.gameObject.GetComponent<Player>();
        playerModifier = target.gameObject.GetComponentInChildren<Modifier>();
        mainManager = GameObject.Find("Game Manager");
        anim.SetBool("InRange",false);
    }

    public virtual void Update()
    {
        if (HP <= 0 && gameObject.activeInHierarchy)
        {
            GameManager.kills++;
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

        //if(isNavigable != (targetAttribute.HP > 0))
        //    isNavigable = (targetAttribute.HP > 0);

        //if (isNavigable)
        //{
        //    if (enemyAI.destination != target.position)
        //    {
        //        enemyAI.SetDestination(target.position);
        //        enemyAI.acceleration = MoveSpeed * -1f;
        //    }

        //    if (anim.GetBool("InRange") != (Vector3.Distance(target.position, transform.position) <= enemyAI.stoppingDistance))
        //    {
        //        anim.SetBool("InRange", (Vector3.Distance(target.position, transform.position) <= enemyAI.stoppingDistance));
        //    }

        //    if (Vector3.Distance(target.position, transform.position) <= enemyAI.stoppingDistance && ENEMYSTATE != STATE.ATTACK)
        //    {
        //        ENEMYSTATE = STATE.ATTACK;

        //    }
        //    else if (Vector3.Distance(target.position, transform.position) > enemyAI.stoppingDistance && ENEMYSTATE != STATE.CHASE)
        //    {
        //        ENEMYSTATE = STATE.CHASE;
        //        enemyAI.speed = enemyAI.acceleration = MoveSpeed;
        //        enemyAI.Resume();
        //    }

        //}

    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.name.Contains("Enemy Brake"))
        {
            enemyAI.speed = 0f;
            //enemyAI.acceleration = MoveSpeed * -1;
            enemyAI.Stop();
            ENEMYSTATE = STATE.ATTACK;
            
        }
        else if(coll.name.Contains("Enemy Attack"))
        {
            anim.SetBool("InRange", true);
        }
    }

    public void OnTriggerExit(Collider coll)
    {
        if (coll.name.Contains("Enemy Brake"))
        {
            enemyAI.speed = MoveSpeed;
            enemyAI.Resume();
            //enemyAI.acceleration = MoveSpeed;
            ENEMYSTATE = STATE.CHASE;
            
        }
        else if (coll.name.Contains("Enemy Attack"))
        {
            anim.SetBool("InRange", false);
        }
    }

    public void Attacking()
    {
        float damage = 0f;

        AttackInterval -= Time.deltaTime;
        if (AttackInterval <= 0f)
        {
            damage += Attack - targetAttribute.Armor / 2;
            if (playerModifier.DamageReturn > 0f)
            {
                HP -= playerModifier.DamageReturn * damage;
                damage -= playerModifier.DamageReturn * damage;
            }
            damage = AttackMod(damage);
            if (damage < 0f)
                damage = 0f;
            if (damage < 1f)
                targetAttribute.HP--;
            else
                targetAttribute.HP -= damage;

            AttackInterval = 80f / AttackSpeed;
            damage = 0f;
        }
    }

    public void Growl()
    {
        HurtGrowl.Play();
    }

    public virtual float AttackMod(float d)
    {
        return d;
    }

    protected void KillReward()
    { 
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + GuaranteeGold);
        targetAttribute.xp += GuaranteeExp;
        if(!PlayerPrefs.HasKey("Player Exp"))
        {
            PlayerPrefs.SetInt("Player Exp", 0);
        }
        PlayerPrefs.SetInt("Player Exp", PlayerPrefs.GetInt("Player Exp") + GuaranteePlayerExp);
        //enemyDrop.OnItemDrop(5);
        //PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + (int)(MaxHP + Attack + Armor)/7);
        //targetAttribute.xp += (int)(MaxHP + Attack + Armor) / 9;
    }

    protected void VariousSceneKills()
    {
        if (Application.loadedLevelName.Contains("Frenzy") && !Application.loadedLevelName.Contains("Defend"))
        {
            if (gameObject.name.Contains(mainManager.GetComponent<GhostFrenzy>().keyName))
            {
                mainManager.GetComponent<GhostFrenzy>().kills++;
            }
        }
       
    }
}
