using UnityEngine;
using System.Collections;

public class TrevorFire : MonoBehaviour {

    public float damage;
    private float LifeSpan = 14f;
    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            coll.GetComponent<Enemy>().HP -= damage * Time.deltaTime;
        }
    }

    void OnEnable()
    {
        LifeSpan = 14f;
    }

    void Update()
    {
        LifeSpan -= Time.deltaTime;
        if (LifeSpan <= 0f && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
