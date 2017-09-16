using UnityEngine;
using System.Collections;

public class LeakAura : MonoBehaviour {

    public float RadianceDamage;

    void Awake()
    {
        if (gameObject.name.Contains("4"))
        {
            RadianceDamage = 18f;
        }

        else if (gameObject.name.Contains("3"))
        {
            RadianceDamage = 13f;
        }

        else if (gameObject.name.Contains("2"))
        {
            RadianceDamage = 8f;
        }

        else
        {
            RadianceDamage = 3f;
        }
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Player")
        {
            coll.GetComponent<Player>().HP -= RadianceDamage * Time.deltaTime;
        }
    }
}
