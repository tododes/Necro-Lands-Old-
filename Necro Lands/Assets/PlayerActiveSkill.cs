using UnityEngine;
using System.Collections;

public class PlayerActiveSkill : MonoBehaviour {
    /*public GameObject bullet;
    public float bulletLifeDuration = 3f;

	public float ManaCost;
    private float timer;
    private float RotationTimer;
    private float ShootInterval;
    private Status playerStatus;


	public static bool isRotating;
	public static bool isDoubleShoot;
	public static bool charmingRage;
	public static bool grantActive;
    public Transform gunEnd;

	private AudioSource gun;

    
    // Use this for initialization
    void Start () {
		isRotating = false;
        ShootInterval = 0.03f;
        playerStatus = GetComponent<Status>();
		isDoubleShoot = false;
		gun = GetComponent<AudioSource> ();
		charmingRage = false;
        RotationTimer = 5f;
	}

	bool hasEnoughMana()
	{
		if (playerStatus.mana >= ManaCost)
			return true;
		return false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Q)) 
		{
			switch (gameObject.name) 
			{
				case "Marcia":
				if(hasEnoughMana())
					MarciaActiveSkill();
					break;
				case "Lucy":
				if(hasEnoughMana())
					LucyActiveSkill();
					break;
				case "Grant":
				if(hasEnoughMana())
					GrantActiveSkill();
					break;

                case "Trevor":
				if(hasEnoughMana())
                    TrevorActiveSkill();
                    break;
			}

		}
        if (isRotating)
        {
            RotationTimer -= Time.deltaTime;
            transform.Rotate(new Vector3(0f, 1440f, 0f) * Time.deltaTime);
            ShootInterval -= Time.deltaTime;
            if (ShootInterval <= 0f)
            {
                Instantiate(bullet, gunEnd.position, bullet.transform.rotation);

                gun.Play();
                bullet.GetComponent<BulletMove>().setBulletDamage(playerStatus.attack);
                ShootInterval = 0.005f;
            }
            if (RotationTimer <= 0f)
            {
                isRotating = false;
                RotationTimer = 5f;
            }
        }

		if (grantActive && !hasEnoughMana())
			grantActive = false;
		if (isDoubleShoot && !hasEnoughMana())
			isDoubleShoot = false;
		if (charmingRage && !hasEnoughMana())
			charmingRage = false;
	}

	void GrantActiveSkill()
	{
		if(!grantActive)
			grantActive = true;
		else
			grantActive = false;
	}

    void TrevorActiveSkill()
    {
		isRotating = true;
    }

	void MarciaActiveSkill()
	{
		if (!isDoubleShoot)
			isDoubleShoot = true;
		else
			isDoubleShoot = false;
	}

	void LucyActiveSkill()
	{
		if (!charmingRage) 
		{
			playerStatus.attack += 100;
			charmingRage = true;
		} 
		else 
		{
			playerStatus.attack -= 100;
			charmingRage = false;
		}
			
	}*/
}
