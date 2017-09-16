using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Status : MonoBehaviour {

   public int level;
    public int exp;

    public float hp = 100f;
    public float maxhp;
    public float attack = 50f;
    public float shootRate = 0.5f;
    public float armor = 5f;
    public float speed = 2f;
    public float hpRegen;

	public float mana, maxMana, manaRegen;

    private float originSpeed;
    private float originArmor;
    private bool decreaseArmorActivated;
    private bool slowDownActivated;
    // private float doubleAttack, doubleSpeed, originAttack;
    private Text levels, LevelUpText;
    private Slider slide, manaSlide;
    private GameObject DamageImage;

    void Awake()
    {
        originSpeed = speed;
        originArmor = armor;
        maxhp = hp;
		maxMana = mana;
        /*originAttack = attack;
         originSpeed = speed;
         originArmor = armor;*/
        DamageImage = GameObject.Find("DamageImage");
        LevelUpText = GameObject.Find("LevelUpText").GetComponent<Text>();
    }

    void Start()
    {
       level = 1;
       exp = 0;
        
        KillReward();
        levels = GameObject.Find("LevelText").GetComponent<Text>();
        slide = GameObject.Find("ExpSlide").GetComponent<Slider>();
		manaSlide = GameObject.Find("Mana Bar").GetComponent<Slider>();
    }

   void LevelUp()
    {
        if (exp >= 100 + 3 * (level - 1) * (level - 1) * (level - 1))
        {
            LevelUpText.enabled = true;
            LevelUpAddAttribute(gameObject.name);
            exp -= (100 + 3 * (level - 1) * (level - 1) * (level - 1));

            level++;
        }
    }

    void LevelUpAddAttribute(string n)
    {
        switch (n)
        {
            case "Grant":
                maxhp += 10;
                hp += 10;
                hpRegen += 2;
                attack += 3;
                armor += 5;
                shootRate -= 0.002f;
                break;
            case "Lucy":
                maxhp += 8;
                hp += 8;
                hpRegen += 1.5f;
                attack += 4;
                armor += 5;
                shootRate -= 0.004f;
                break;
            case "Trevor":
                maxhp += 2;
                hp += 2;
                hpRegen += 0.1f;
                attack += 5;
                armor += 1;
                shootRate -= 0.01f;
                break;
            case "Marcia":
                maxhp += 4;
                hp += 4;
                hpRegen += 1;
                attack += 3;
                armor += 3;
                shootRate -= 0.008f;
                break;
        }
        originSpeed = speed;
        originArmor = armor;

    }

    void KillReward()
    {
        if (PlayerPrefs.GetInt("20KillAchieve") == 2)
        {
            attack += 40f;
            armor += 15f;
        }
        if (PlayerPrefs.GetInt("40KillAchieve") == 2)
        {
            attack += 90f;
            armor += 45f;
        }
        if (PlayerPrefs.GetInt("60KillAchieve") == 2)
        {
            attack += 150f;
            armor += 75f;
        }
        if (PlayerPrefs.GetInt("Tuyulkill") == 2)
        {
            speed += 2f;
        }

        if (PlayerPrefs.GetInt("Begukill") == 2)
        {
            maxhp += 500;
            hp += 500;
            attack += 100;
        }
    }

    void GameModeReward()
    {
        hp = hp + 400*PlayerPrefs.GetInt("Leak Frenzy");
        attack = attack + 70*PlayerPrefs.GetInt("Killing Frenzy") + 50 * PlayerPrefs.GetInt("Begu Frenzy") + 20*PlayerPrefs.GetInt("Tuyul Frenzy");
        armor = armor + 20*PlayerPrefs.GetInt("Defending Frenzy") + 10*PlayerPrefs.GetInt("Pocong Frenzy");
        speed = speed + 2*PlayerPrefs.GetInt("Tuyul Frenzy");
        hpRegen = hpRegen + 6 * PlayerPrefs.GetInt("Kunti Frenzy") + 3 * PlayerPrefs.GetInt("Leak Frenzy");
    }

    void SetUI()
    {
        levels.text = "LEVEL " + level;
        slide.maxValue = 100 + 3 * (level - 1) * (level - 1) * (level - 1);
        slide.value = exp;
		manaSlide.maxValue = maxMana;
		manaSlide.value = mana;

    }

    void Update()
    {
       Validation();
       SetUI();
       LevelUp();
        if (hp <= 0)
        {
            StartupManager.isFinished = true;
            StartupManager.isStarted = false;
          
           
            //Application.LoadLevel("Die");
        }
        //LevelUp();
    }

  
    void Validation()
    {
        if (hp < maxhp)
        {
            hp += hpRegen * Time.deltaTime;
        }
		else
        {
            hp = maxhp;
        }

		if (mana < maxMana)
		{
			mana += manaRegen * Time.deltaTime;
		}
		else
		{
			mana = maxMana;
		}

        if (shootRate < 0.01f)
            shootRate = 0.01f;
    }

   

    public float GotOriginSpeed()
    {
        return originSpeed;
    }

	public void GotDamaged(float attack)
    {
        if (attack < 0.1f)
            attack = 0.1f;
        
        if (attack >= 1f)
        {
            DamageImage.GetComponent<DamageImageClass>().setX(0.85f);
            DamageImage.GetComponent<Image>().enabled = true;
        }
       
        this.hp -= attack;
        
    }

    public void AddHp(float healHp)
    {

        this.hp += healHp;
    }

    public void GotDamaged(float attack, float additionalDamage)
    {
        this.hp -= (attack * additionalDamage);
    }

    public void slowDown(float decreaseSpeed)
    {
        if (decreaseSpeed == 0f)
        {
            slowDownActivated = false;
            speed = originSpeed;
        }
        else if(!slowDownActivated)
        {
            slowDownActivated = true;
            speed *= decreaseSpeed;
          
        }
    }

    public void decreaseArmor(float reduceArmor)
    {
        if (reduceArmor == 0f)
        {
            decreaseArmorActivated = false;
            armor = originArmor;
        }
        else if (!decreaseArmorActivated)
        {
            decreaseArmorActivated = true;
            armor -= reduceArmor;
        }
    }
}
