using UnityEngine;
using System.Collections;

public class LucyShoot : PlayerShoot 
{
    public Transform launcher2;
    public GameObject bullet2;

    public override void Update()
    {
        if (Input.GetMouseButton(0))
        {
            interval -= Time.deltaTime;
            if (interval <= 0f)
            {
                GunEndAudio.Play();
                GrantSpecial();
                LucySpecial();
                bullet.GetComponent<Bullet>().myPlayer = myPlayer;
                bullet.GetComponent<Bullet>().damage = myPlayer.Attack;
                bullet2.GetComponent<Bullet>().myPlayer = myPlayer;
                bullet2.GetComponent<Bullet>().damage = myPlayer.Attack;
                AttackMod();
                Instantiate(bullet, launcher.position, launcher.rotation);
                Instantiate(bullet2, launcher2.position, launcher2.rotation);
                interval = 80f / myPlayer.AttackSpeed;
            }
        }
    }
}
