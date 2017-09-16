using UnityEngine;
using System.Collections;

public class Modifier : MonoBehaviour {

    public float LifeSteal;
    public float Critical;
    public float CriticalChance;
    public float burnDamage;
    public float ArmorReduction;
    public float DamageReturn;
    public float SlowRate;
    public float CleaveRate;

    private Vector3 euler;

    void Awake()
    {
        euler = new Vector3(270,0,0);
    }

    void Update()
    {
        transform.eulerAngles = euler;
        if (burnDamage > 0f && GetComponent<HellSphereComponent>() == null)
        {
            gameObject.AddComponent<HellSphereComponent>();
            gameObject.AddComponent<SphereCollider>();
            gameObject.AddComponent<Rigidbody>();
            GetComponent<SphereCollider>().radius = 7f;
            GetComponent<SphereCollider>().isTrigger = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            GetComponent<HellSphereComponent>().burnDamage = burnDamage;
        }
    }
}
