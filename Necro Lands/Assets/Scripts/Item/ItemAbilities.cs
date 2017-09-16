using UnityEngine;
using System.Collections;

public class ItemAbilities : MonoBehaviour {

    public float maxHp = 1000;
    public float regenInterval = 1f;

    private Status playerStatus;
    private float regenHp;
    private bool regenHpActivated;
    //private UIController uiController;
    private float regenTimer = 0f;

	// Use this for initialization
	void Awake () {
        regenHp = 0f;
        regenHpActivated = false;
        playerStatus = gameObject.GetComponent<Status>();
        //uiController = GameObject.Find("Canvas").GetComponent<UIController>();
	}

    void Update()
    {
        if (regenHpActivated == true)
        {
            regenTimer += Time.deltaTime;

            if (playerStatus.hp < maxHp && regenTimer > regenInterval)
            {
                regenTimer = 0f;

                playerStatus.AddHp(regenHp);
            }
        }
    }

    public void Kujang()
    {
        string item = "kujang";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 10f;
        }
          
    }

    public void WoodenSlippers()
    {
        string item = "wooden slippers";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.speed += 4f;
            playerStatus.shootRate -= 0.05f;
        }
         
    }

    public void ShieldOfTeumaga()
    {
        string item = "shield of teumaga";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.armor += 3f;
            playerStatus.hpRegen += 3f;
            regenHpActivated = true;
        }
        
    }
	
    public void Rencong()
    {
        string item = "rencong";
        int index = -1;
        for (int i = 1; i <= 4; i++)
        {
            if (PlayerPrefs.GetString("equip" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
            playerStatus.attack += 20;
    }

    public void OrbOfDedemit()
    {
        string item = "orb of dedemit";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.hp += 100;
        }
           
    }

    public void GhostOrb()
    {
        string item = "ghost orb";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.hp += 300f;
            playerStatus.attack += 10f;
            playerStatus.armor += 10f;
            playerStatus.speed += 2f;
            playerStatus.shootRate -= 0.1f;
        }
          
    }

    public void Celurit()
    {
        string item = "celurit";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
            playerStatus.attack += 50;
    }

    public void HellSphere()
    {
        string item = "hell sphere";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
            playerStatus.hp += 500;
    }

    public void Mandau()
    {
        string item = "mandau";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 25f;
            playerStatus.shootRate -= 0.2f;
        }
        
    }

    public void Salawaku()
    {
        string item = "salawaku";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.hp += 700f;
            regenHp += 10f;
            regenHpActivated = true;
            playerStatus.armor += 20f;
        }
        
    }

    public void Keris()
    {
        string item = "keris";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 75f;
            playerStatus.speed += 3f;
            playerStatus.shootRate -= 0.15f;
        }
       
    }

    public void KuntilAnakMask()
    {
        string item = "kuntil anak mask";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.shootRate -= 0.2f;
            regenHp += 12f;
           
        }
        regenHpActivated = true;
    }

    public void Baluse()
    {
        string item = "baluse";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.maxhp += 600f;
            playerStatus.hp += 600f;
            playerStatus.armor += 25f;
        }
        
    }

    public void PisoSurit()
    {
        string item = "piso surit";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 30;
            playerStatus.armor += 30;
            playerStatus.maxhp += 200;
            playerStatus.hp += 200;
            playerStatus.hpRegen += 5f;
        }
           
    }

    public void BambuRuncing()
    {
        string item = "sharp bamboo";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
            playerStatus.attack += 90;
    }

    public void Parang()
    {
        string item = "parang";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 65;
            playerStatus.shootRate += 0.05f;
        }
         
    }

    public void ShieldOfAwe()
    {
        string item = "shield of awe";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.maxhp += 150;
            playerStatus.hp += 150;
        }
         
    }

    public void Golok()
    {
        string item = "golok";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 75;
            playerStatus.armor += 35;
            playerStatus.shootRate += 0.07f;
            playerStatus.speed -= 1.5f;
        }
         
    }

    public void Badik()
    {
        string item = "badik";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.speed += 6f;
            playerStatus.shootRate -= 0.25f;
            playerStatus.armor -= 50f;
        }
       
    }

    public void JenawiSword()
    {
        string item = "jenawi sword";
        int index = -1;
        for (int i = 1; i <= 20; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < PlayerPrefs.GetInt("item" + index + "qty"); i++)
        {
            playerStatus.attack += 200;
            playerStatus.armor += 100;
            playerStatus.speed += 7f;
        }
           
    }
}
