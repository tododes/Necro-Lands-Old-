using UnityEngine;
using System.Collections;

public class EffectDisplay : MonoBehaviour {
    float lifeSpan = 0.5f;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * 15f * Time.deltaTime);
        lifeSpan -= Time.deltaTime;
        if (lifeSpan <= 0f)
        {
            GetComponent<TextMesh>().text = "";
            Destroy(this.gameObject);
        }
	}
}
