using UnityEngine;
using System.Collections;

public class MarciaShoot : PlayerShoot {

	// Use this for initialization
	void Awake () 
    {
        base.Awake();
	}
	
	// Update is called once per frame
	void Update () 
    {
        base.Update();
	}

    public override void AttackMod()
    {
        base.AttackMod();
        int rand = Random.Range(0, 100);
        if (rand < 25)
        {
           if(PlayerPrefs.GetInt("currSkill") == 1)
                bullet.GetComponent<Bullet>().damage *= 1.25f;
           else if (PlayerPrefs.GetInt("currSkill") == 2)
               bullet.GetComponent<Bullet>().damage *= 1.5f;
           else if (PlayerPrefs.GetInt("currSkill") == 3)
               bullet.GetComponent<Bullet>().damage *= 1.75f;
           else if (PlayerPrefs.GetInt("currSkill") == 4)
               bullet.GetComponent<Bullet>().damage *= 2f;
        }
        else
        {
           
        }
    }
}
