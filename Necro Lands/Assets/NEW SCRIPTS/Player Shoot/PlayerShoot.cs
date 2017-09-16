using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    public Transform launcher;
    protected Player myPlayer;
    protected float interval;
    protected GrantActiveSkill GrantActiveSkill;
    protected LucyActiveSkill LucyActiveSkill;
    protected Modifier mod;
    protected AudioSource GunEndAudio;
    protected ShootButton shootButton;
    //[Header()]

    public void Awake()
    {
        myPlayer = GetComponent<Player>();
        interval = 80f / myPlayer.AttackSpeed;
        if (gameObject.name == "Grant")
            GrantActiveSkill = GetComponent<GrantActiveSkill>();
        if (gameObject.name == "Lucy")
            LucyActiveSkill = GetComponent<LucyActiveSkill>();
        mod = gameObject.GetComponentInChildren<Modifier>();
        GunEndAudio = transform.Find("Gun End").gameObject.GetComponent<AudioSource>();
    }

    public void Start()
    {
        shootButton = ShootButton.GetInstance();
    }

	// Update is called once per frame
    public virtual void Update()
    {
        if ((shootButton && shootButton.Pressed /*|| Input.GetMouseButton(0)*/) /*|| Input.GetMouseButton(0)*/)
        {
            interval -= Time.deltaTime;
            if (interval <= 0f)
            {
                GunEndAudio.Play();
                GrantSpecial();
                LucySpecial();
                shoot();
                interval = 80f / myPlayer.AttackSpeed;
            }
        }
    }

    public void shoot()
    {
        bullet.GetComponent<Bullet>().myPlayer = myPlayer;
        bullet.GetComponent<Bullet>().damage = myPlayer.Attack;
        AttackMod();
        Instantiate(bullet, launcher.position, launcher.rotation);
    }

    protected void GrantSpecial()
    {
        if (PlayerPrefs.GetString("charname") == "Grant")
        {
            bullet.GetComponent<Bullet>().fromGrantActiveSkill = GetComponent<GrantActiveSkill>().GrantSkillActivated;
        }
    }

    protected void LucySpecial()
    {
        if (PlayerPrefs.GetString("charname") == "Lucy")
        {
            bullet.GetComponent<Bullet>().fromLucyActiveSkill = GetComponent<LucyActiveSkill>().LucySkillActivated;
        }
    }


    public virtual void AttackMod()
    {
        bullet.GetComponent<Bullet>().LifeStealRate = mod.LifeSteal;
        bullet.GetComponent<Bullet>().ArmorReductionRate = mod.ArmorReduction;
        bullet.GetComponent<Bullet>().CriticalRate = mod.Critical;
        bullet.GetComponent<Bullet>().CriticalChance = mod.CriticalChance;
        bullet.GetComponent<Bullet>().CleaveRate = mod.CleaveRate;
    }
}
