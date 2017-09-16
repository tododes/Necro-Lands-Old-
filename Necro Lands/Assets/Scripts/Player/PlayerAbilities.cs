using UnityEngine;
using System.Collections;

public class PlayerAbilities : MonoBehaviour {
    public GameObject effectObj;

    //private GameObject enemyDetector;

    private Status playerStatus;
    private string currPlayerName;
    

	// Use this for initialization
	void Start () {
        //enemyDetector = GameObject.Find("Enemy Detector");
        playerStatus = gameObject.GetComponent<Status>();
        currPlayerName = gameObject.name;
	}

    public string getCurrPlayerName()
    {
        return currPlayerName;
        
    }

    public void DisplayEffect(GameObject g, string a, Color col)
    {
        effectObj.GetComponent<TextMesh>().text = a;
        effectObj.GetComponent<TextMesh>().color = col;
        Instantiate(effectObj, g.transform.position, Quaternion.identity);
       
    }

    public void GrantAbility(GameObject enemy)
    {
        if (PlayerPrefs.GetInt("currSkill") == 1)
        {
            enemy.GetComponent<EnemyStatus>().armor -= 10f;
            playerStatus.armor += 2f;
            DisplayEffect(enemy, "- ARMOR", Color.green);
        }
        else if (PlayerPrefs.GetInt("currSkill") == 2)
        {
            enemy.GetComponent<EnemyStatus>().armor -= 20f;
            playerStatus.armor += 4f;
            DisplayEffect(enemy, "- ARMOR", Color.green);
        }
        else if (PlayerPrefs.GetInt("currSkill") == 3)
        {
            enemy.GetComponent<EnemyStatus>().armor -= 40f;
            playerStatus.armor += 4f;
            playerStatus.hpRegen += 5f;
            DisplayEffect(enemy, "- ARMOR", Color.green);
        }
        else if (PlayerPrefs.GetInt("currSkill") == 4)
        {
            enemy.GetComponent<EnemyStatus>().armor -= 70f;
            playerStatus.armor += 9f;
            playerStatus.hpRegen += 8f;
            DisplayEffect(enemy, "- ARMOR", Color.green);
        }
        
        //Debug.Log(enemy.GetComponent<EnemyStatus>().armor);
    }

    public void trevorAbility(GameObject enemy)
    {
        if (PlayerPrefs.GetInt("currSkill") == 1)
        {
            int chance = Random.Range(0, 100);

            if (chance < 20)
            {
                enemy.GetComponent<EnemyStatus>().slowDown(0.7f, 5f);
            
            }
        }
        else if (PlayerPrefs.GetInt("currSkill") == 2)
        {
            int chance = Random.Range(0, 100);

            if (chance < 20)
                enemy.GetComponent<EnemyStatus>().slowDown(0.5f, 5f);


        }
        else if (PlayerPrefs.GetInt("currSkill") == 3)
        {
            int chance = Random.Range(0, 100);

            if (chance < 30)
                enemy.GetComponent<EnemyStatus>().slowDown(0.5f, 5f);


        }
        else if (PlayerPrefs.GetInt("currSkill") == 4)
        {
            int chance = Random.Range(0, 100);

            if (chance < 30)
                enemy.GetComponent<EnemyStatus>().slowDown(1f, 5f);


        }




    }

    public float marciaAbility(GameObject enemy, float damage)
    {
        if (PlayerPrefs.GetInt("currSkill") == 1)
        {
            int chance = Random.Range(0, 100);

            if (chance < 25)
            {
                damage += (damage * 0.25f);
                //DisplayEffect(enemy, "CRITICAL SHOT!!", Color.red);
            }
                


        }
        else if (PlayerPrefs.GetInt("currSkill") == 2)
        {
            int chance = Random.Range(0, 100);

            if (chance < 25)
            {
                damage += (damage * 0.5f);
                //DisplayEffect(enemy, "CRITICAL SHOT!!", Color.red);
            }

        }
        else if (PlayerPrefs.GetInt("currSkill") == 3)
        {
            int chance = Random.Range(0, 100);

            if (chance < 25)
            {
                damage += (damage * 0.75f);
                //DisplayEffect(enemy, "CRITICAL SHOT!!", Color.red);
            }
           

        }
        else if (PlayerPrefs.GetInt("currSkill") == 4)
        {
            int chance = Random.Range(0, 100);

            if (chance < 25)
            {
                damage += (damage * 0.75f);
                //DisplayEffect(enemy, "CRITICAL SHOT!!", Color.red);
            }

            if (chance >= 95)
            {
                damage += (damage * 3f);
                //DisplayEffect(enemy, "MEGA CRITICAL SHOT!!", Color.red);
            }
        }

        return damage;
    }

    public void lucyAbility(GameObject enemy)
    {


        if (PlayerPrefs.GetInt("currSkill") == 1)
        {
            enemy.GetComponent<EnemyStatus>().speed -= 2f;
            DisplayEffect(enemy, "- MOVE SPEED\n- ATTACK", Color.magenta);
        }
           
        else if (PlayerPrefs.GetInt("currSkill") == 2)
        {
            enemy.GetComponent<EnemyStatus>().speed -= 3f;
            enemy.GetComponent<EnemyStatus>().attack -= 20;
            DisplayEffect(enemy, "- MOVE SPEED\n- ATTACK", Color.magenta);
        }
        else if (PlayerPrefs.GetInt("currSkill") == 3)
        {
            enemy.GetComponent<EnemyStatus>().speed -= 5f;
            enemy.GetComponent<EnemyStatus>().attack -= 50;
            DisplayEffect(enemy, "- MOVE SPEED\n- ATTACK", Color.magenta);
        }
        else if (PlayerPrefs.GetInt("currSkill") == 4)
        {
            enemy.GetComponent<EnemyStatus>().speed -= 7f;
            enemy.GetComponent<EnemyStatus>().attack -= 100;
            DisplayEffect(enemy, "- MOVE SPEED\n- ATTACK", Color.magenta);

        }
      
    }
}
