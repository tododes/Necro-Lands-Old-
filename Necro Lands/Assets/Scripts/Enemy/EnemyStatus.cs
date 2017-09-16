using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

    public float hp = 100f;
    public float maxhp;
    public float attack = 50f;
    public float shootRate = 0.5f;
    public float armor = 5f;
    public float speed = 2f;
    public float hpRegen;
    

    private float currSpeed;
    private bool slowDownActivated = false;
    private float slowDownTimer = 0f;
    private float slowDownDuration;
    private Status playerStatus;
    private MoneyText moneyText;

	private Vector3 origin;

    void Awake()
    {
        hp = hp + EnemyScaling.scaleIndex;
		maxhp = hp;
        attack = attack + EnemyScaling.scaleIndex;
        armor = armor + EnemyScaling.scaleIndex;
        moneyText = GameObject.Find("Money").GetComponent<MoneyText>();

    }
    void Start()
    {
        CheckScene();
        maxhp = hp;
        currSpeed = speed;
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
       
           
    }

	public void SetInitialPosiion(Vector3 vec)
	{
		origin = vec;
	}

	void OnEnable()
	{
		maxhp = maxhp + EnemyScaling.scaleIndex;
		hp = maxhp;
		attack = attack + EnemyScaling.scaleIndex;
		armor = armor + EnemyScaling.scaleIndex;
		transform.position = origin;
	}

	void OnDisable()
	{
		//transform.position = origin;
	}


    void CheckScene()
    {
        if (Application.loadedLevelName == "Main Game - Boss Fight")
        {
            hp *= 3;
            attack *= 3;
            armor *= 3;
        }
        else if (Application.loadedLevelName == "Main Game - Mega Boss Fight")
        {
            hp *= 5;
            attack *= 5;
            armor *= 5;
        }
    }

   

    void GhostKillAchieve()
    {
        if (gameObject.name == "Tuyul")
        {
            PlayerPrefs.SetInt("TuyulTotalKill", PlayerPrefs.GetInt("TuyulTotalKill") + 1);
            if (PlayerPrefs.GetInt("TuyulTotalKill") >= 20 && PlayerPrefs.GetInt("Tuyulkill") == 0)
            {
                PlayerPrefs.SetInt("Tuyulkill", 1);
            }
        }
        else if (gameObject.name == "Begu Ganjang")
        {
            PlayerPrefs.SetInt("BeguTotalKill", PlayerPrefs.GetInt("BeguTotalKill") + 1);
            if (PlayerPrefs.GetInt("BeguTotalKill") >= 20 && PlayerPrefs.GetInt("Begukill") == 0)
            {
                PlayerPrefs.SetInt("Begukill", 1);
            }
        }
        else if (gameObject.name == "Leak")
        {
            PlayerPrefs.SetInt("LeakTotalKill", PlayerPrefs.GetInt("LeakTotalKill") + 1);
            if (PlayerPrefs.GetInt("LeakTotalKill") >= 20 && PlayerPrefs.GetInt("Leakkill") == 0)
            {
                PlayerPrefs.SetInt("Leakkill", 1);
            }
        }
        else if (gameObject.name == "Pocong")
        {
            PlayerPrefs.SetInt("PocongTotalKill", PlayerPrefs.GetInt("PocongTotalKill") + 1);
            if (PlayerPrefs.GetInt("PocongTotalKill") >= 20 && PlayerPrefs.GetInt("Pocongkill") == 0)
            {
                PlayerPrefs.SetInt("Pocongkill", 1);
            }
        }
        else if (gameObject.name == "Kuntil Anak")
        {
            PlayerPrefs.SetInt("KuntiTotalKill", PlayerPrefs.GetInt("KuntiTotalKill") + 1);
            if (PlayerPrefs.GetInt("KuntiTotalKill") >= 20 && PlayerPrefs.GetInt("Kuntikill") == 0)
            {
                PlayerPrefs.SetInt("Kuntikill", 1);
            }
        }
    }

    void KillAchieve()
    {
        PlayerPrefs.SetInt("Kill", PlayerPrefs.GetInt("Kill") + 1);
        if (PlayerPrefs.GetInt("Kill") >= 60)
        {
            PlayerPrefs.SetInt("60KillAchieve", 1);
        }

        else if (PlayerPrefs.GetInt("Kill") >= 40)
        {
            PlayerPrefs.SetInt("40KillAchieve", 1);
        }

        else if (PlayerPrefs.GetInt("Kill") >= 20)
        {
            PlayerPrefs.SetInt("20KillAchieve", 1);
        }

        if (PlayerPrefs.GetInt("Kuntikill") == 2)
        {
            playerStatus.hp += 100;
        }
    }

    void Earn()
    {

        float expAccumulation = maxhp + attack + armor;
        if(playerStatus.level < 100)
        playerStatus.exp += (int)expAccumulation / 15;
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 10);
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 5);
        moneyText.bigScaleActivated = true;
        if (PlayerPrefs.GetInt("Begukill") == 2)
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 15);
        }
        //SpawnEnemy.enemyKillNum++;
    }

    void Update()
    {
        
        if (hp <= 0)
        {
            GhostKillAchieve();
            KillAchieve();
            Earn();
			gameObject.SetActive(false);
        }

        if (speed < 1f)
            speed = 1f;

        if(slowDownActivated)
        {
            slowDownTimer += Time.deltaTime;

            if (slowDownTimer > slowDownDuration)
            {
                slowDownTimer = 0f;
                speed = currSpeed;
                slowDownActivated = false;
            }
        }

        if (hp < maxhp)
        {
            hp += hpRegen * Time.deltaTime;
        }

        if (hp > maxhp)
        {
            hp = maxhp;
        }
    }

    public void GotDamaged(float attack)
    {
        if (attack < 0)
            attack = 1f;
        this.hp -= attack;
    }

    public void GotDamaged(float attack, float additionalDamage)
    {
        this.hp -= (attack * additionalDamage);
    }

    public void slowDown(float decreaseSpeedPercentage, float duration)
    {
        slowDownDuration = duration;
        speed *= decreaseSpeedPercentage;
        slowDownActivated = true;
    }

    public void slowDown(float decreaseSpeedPercentage)
    {
        speed *= decreaseSpeedPercentage;
    }

   
}
