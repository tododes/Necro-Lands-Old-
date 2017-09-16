using UnityEngine;
using System.Collections;

public class EnemyAbilities : MonoBehaviour {

    public float burningAuraDamage = 1f;
    public static bool desolationAuraActivated;

    private float burningAuraTimer = 0f;
    private bool burningAuraActivated;

    private Status playerStatus;
    private EnemyStatus enemyStatus;

	// Use this for initialization
	void Start () {
       desolationAuraActivated = false;
       playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
       enemyStatus = GetComponent<EnemyStatus>();
        ScaleForBossFight();
    }

    void ScaleForBossFight()
    {
        if (Application.loadedLevelName == "Main Game - Boss Fight")
        {
            transform.localScale = new Vector3(transform.localScale.x * 2f, transform.localScale.y * 2f, transform.localScale.z * 2f);
        }
        else if (Application.loadedLevelName == "Main Game - Mega Boss Fight")
        {
            transform.localScale = new Vector3(transform.localScale.x * 3f, transform.localScale.y * 3f, transform.localScale.z * 3f);
        }
    }
	// Update is called once per frame
	void Update () {
	    
        if(burningAuraActivated)
        {
            
            playerStatus.GotDamaged(burningAuraDamage * Time.deltaTime);
            /*burningAuraTimer += Time.deltaTime;

            if (burningAuraTimer > 1f)
            {
                burningAuraTimer = 0f;

                playerStatus.GotDamaged(burningAuraDamage);

            }*/
        }

	}

    public void KuntialAnakSkill(float addHp)
    {
        enemyStatus.hp += (addHp * 0.1f);
    }

    public float BeguGanjangSkill(float damage)
    {
        float totalDamage = 0f;
        int chance = Random.Range(0, 100);

        if (chance < 25)
            totalDamage += 0.05f * PlayerPrefs.GetInt("gold");//(damage * 0.2f);

        return totalDamage;
    }

    public void LeakSkill(bool skillActivated)
    {
        if (skillActivated)
        {
            burningAuraActivated = true;
           
        }
          
        else if (!skillActivated)
            burningAuraActivated = false;

        burningAuraTimer = 0f;
    }

    public void PocongSkill(float decreaseSpeed, float decreaseArmor)
    {
        playerStatus.decreaseArmor(decreaseArmor);
        playerStatus.slowDown(decreaseSpeed);

    }
}
