using UnityEngine;
using System.Collections;

public class TrevorShoot : PlayerShoot 
{
    void Awake()
    {
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void AttackMod()
    {
        base.AttackMod();
        int rand = Random.Range(0, 100);
        if (rand < 25)
        {
            if (PlayerPrefs.GetInt("currSkill") == 1)
            {
                bullet.GetComponent<Bullet>().SlowRate = 0.2f;
                bullet.GetComponent<Bullet>().ArmorReductionRate = 2f;
            }
            else if (PlayerPrefs.GetInt("currSkill") == 2)
            {
                bullet.GetComponent<Bullet>().SlowRate = 0.4f;
                bullet.GetComponent<Bullet>().ArmorReductionRate = 7f;
            }
            else if (PlayerPrefs.GetInt("currSkill") == 3)
            {
                bullet.GetComponent<Bullet>().SlowRate = 0.6f;
                bullet.GetComponent<Bullet>().ArmorReductionRate = 12f;
            }
            else if (PlayerPrefs.GetInt("currSkill") == 4)
            {
                bullet.GetComponent<Bullet>().SlowRate = 0.8f;
                bullet.GetComponent<Bullet>().ArmorReductionRate = 17f;
            }
        }
      
    }

	
}
