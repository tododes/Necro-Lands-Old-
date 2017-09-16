using UnityEngine;
using System.Collections;

public class EnemyEffectScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

 
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<TextMesh>().text != "")
        {
            float timer = 2f;
            timer -= Time.deltaTime;
            if (timer <= 0f)
                GetComponent<TextMesh>().text = "";
        }
	}
}
