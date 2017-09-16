using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float HP;
    public float MaxHP;
    public float Mana;
    public float MaxMana;
    public float Attack;
    public float Armor;
    public float MoveSpeed;
    public int AttackSpeed;

    public float OriMoveSpeed;

    public float HPRegen;
    public float ManaRegen;

    public int xp;
    public int level;

    public Gender G;
    public enum Gender
    { 
        BOY, GIRL
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("HP",MaxHP);
        PlayerPrefs.SetFloat("Mana", MaxMana);
        PlayerPrefs.SetFloat("Attack", Attack);
        PlayerPrefs.SetFloat("Armor", Armor);
        PlayerPrefs.SetInt("Attack Speed", AttackSpeed);
        PlayerPrefs.SetFloat("HP Regen", HPRegen);
        PlayerPrefs.SetFloat("Mana Regen", ManaRegen);
    }

    public void InitiateAttribute()
    {
        HP = MaxHP = PlayerPrefs.GetFloat("HP");
        Mana = MaxMana = PlayerPrefs.GetFloat("Mana");
        Attack = PlayerPrefs.GetFloat("Attack");
        Armor = PlayerPrefs.GetFloat("Armor");
        AttackSpeed = PlayerPrefs.GetInt("Attack Speed");
        HPRegen = PlayerPrefs.GetFloat("HP Regen");
        ManaRegen = PlayerPrefs.GetFloat("Mana Regen");
    }

    public Color signatureColor;

    void Awake()
    {
        SaveData();
        InitiateAttribute();
        if (!PlayerPrefs.HasKey("LEVEL"))
            PlayerPrefs.SetInt("LEVEL", 1);
        if (!PlayerPrefs.HasKey("EXP"))
            PlayerPrefs.SetInt("EXP", 0);
        level = PlayerPrefs.GetInt("LEVEL");
        xp = PlayerPrefs.GetInt("EXP");
        if (!PlayerPrefs.HasKey("UPGRADE POINT"))
            PlayerPrefs.SetInt("UPGRADE POINT", 0);
    }

    void Update()
    {
        if (HP < MaxHP)
            HP += HPRegen * Time.deltaTime;
        if (Mana < MaxMana)
            Mana += ManaRegen * Time.deltaTime;

        if (xp >= 100 + 3 * level * level * level)
        {
            PlayerPrefs.SetInt("UPGRADE POINT", PlayerPrefs.GetInt("UPGRADE POINT") + 1);
            xp -= 100 + 3 * level * level * level;
            //MaxHP += 10f;
            //HP += 10f;
            //MaxMana += 7f;
            //Mana += 7f;
            //Attack += 5f;
            //Armor += 5f;
            //AttackSpeed += 5;
            //HPRegen += 1f;
            //ManaRegen += 1f;
            level++;
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.name.Contains("Treasure"))
        {
            coll.GetComponent<TreasureChest>().GiveRandomStoneToPlayer();
            coll.gameObject.SetActive(false);
        }
    }

	// Use this for initialization
	/*void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
     
	}*/
}
