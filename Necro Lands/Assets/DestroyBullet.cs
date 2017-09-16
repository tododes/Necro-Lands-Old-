using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Bullet")
            Destroy(col.gameObject);
    }
}
