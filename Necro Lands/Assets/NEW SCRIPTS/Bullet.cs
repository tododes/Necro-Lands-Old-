using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float damage;
    public float LifeStealRate;
    public float ArmorReductionRate;
    public float CriticalRate;
    public float CriticalChance;
    public float SlowRate;
    public float StunRate;
    public float CleaveRate;
    public float speed;
    public bool fromGrantActiveSkill = false;
    public bool fromLucyActiveSkill = false;
    public Player myPlayer;
    public float LifeDuration;

    private Renderer myRender;
    public Color originalColor;

    void Awake()
    {
        if (CriticalChance > 0)
            Criticality();
        myRender = GetComponent<Renderer>();
        originalColor = myRender.material.color;
    }

    /*void OnEnable()
    {
        if (CriticalChance > 0)
            Criticality();
    }*/

    void Update()
    {
        if (fromGrantActiveSkill && myRender.material.color != myPlayer.signatureColor)
            myRender.material.color = myPlayer.signatureColor;
        else if (fromLucyActiveSkill && myRender.material.color != myPlayer.signatureColor)
            myRender.material.color = myPlayer.signatureColor;
        else if (myRender.material.color != originalColor)
            myRender.material.color = originalColor;
        

        LifeDuration -= Time.deltaTime;
        if (LifeDuration <= 0f)
            gameObject.SetActive(false);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
	// Use this for initialization
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            damage -= coll.GetComponent<Enemy>().Armor / 2;
            if(damage < 1)
                coll.GetComponent<Enemy>().HP--;
            else
                coll.GetComponent<Enemy>().HP -= damage;

            coll.GetComponent<Enemy>().Armor -= ArmorReductionRate;
            coll.GetComponent<Enemy>().MoveSpeed *= (1 - SlowRate);
            if(LifeStealRate > 0f)
                myPlayer.HP += LifeStealRate * damage;
            if (fromGrantActiveSkill)
            {
                coll.GetComponent<Enemy>().HP -= 0.25f * coll.GetComponent<Enemy>().HP;
            }
               
            if (CleaveRate > 0f)
            {
                Debug.Log("CLEAVE");
                coll.GetComponentInChildren<CleaveDetector>().ActivateDamage(CleaveRate * damage);
            }
            coll.GetComponent<Enemy>().Growl();
            gameObject.SetActive(false);
        }
            
    }

    void Criticality()
    {
        int r = Random.Range(0, 100);
        if (r < CriticalChance)
            damage = damage * CriticalRate;
    }
}
