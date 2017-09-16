using UnityEngine;
using System.Collections;

public class PocongAura : MonoBehaviour {

    public float SlowRate;
    public float ArmorReduction;
    private Pocong pocong;

    void Awake()
    {
        if (gameObject.name.Contains("4"))
        {
             SlowRate = 0.8f;
             ArmorReduction = 20f;
                
        }

        else if (gameObject.name.Contains("3"))
        {
            SlowRate = 0.6f;
             ArmorReduction = 15f;
        }

        else if (gameObject.name.Contains("2"))
        {
             SlowRate = 0.4f;
             ArmorReduction = 10f;
        }

        else
        {
            SlowRate = 0.2f;
            ArmorReduction = 5f;
        }
        pocong = GetComponentInParent<Pocong>();
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().MoveSpeed *= (1f - SlowRate);
            coll.GetComponent<Player>().Armor -= ArmorReduction;
        }


    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            if(pocong.HP <= 0)
            {
                coll.GetComponent<Player>().MoveSpeed = coll.GetComponent<Player>().OriMoveSpeed;
                coll.GetComponent<Player>().Armor += ArmorReduction;
            }
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().MoveSpeed = coll.GetComponent<Player>().OriMoveSpeed;
            coll.GetComponent<Player>().Armor += ArmorReduction;
        }
    }
}
