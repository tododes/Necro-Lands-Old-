using UnityEngine;
using System.Collections;

public class CleaveDetector : MonoBehaviour {
    private float LifeSpan;
    private float damage;
    private SphereCollider myCollider;
   
    void Start()
    {
        LifeSpan = 0f;
        myCollider = GetComponent<SphereCollider>();
    }

    public void ActivateDamage(float d)
    {
        LifeSpan = 0.05f;
        damage = d;
    }

    void Update()
    {
        LifeSpan -= Time.deltaTime;
        myCollider.enabled = (LifeSpan > 0f);
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            Debug.Log(damage);
            coll.gameObject.GetComponent<Enemy>().HP -= damage;
            Debug.Log(coll.gameObject.GetComponent<Enemy>().HP);
        }
    }
}
