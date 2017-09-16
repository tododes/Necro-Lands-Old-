using UnityEngine;
using System.Collections;

public class HellSphereComponent : MonoBehaviour {

    public float burnDamage;
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            coll.GetComponent<Enemy>().HP -= burnDamage * Time.deltaTime;
        }
    }
}
