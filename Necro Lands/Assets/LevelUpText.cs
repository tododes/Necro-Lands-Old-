using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUpText : MonoBehaviour {

    private float lifeTime;
    private bool displayed;
	// Use this for initialization
	void Start () 
    {
        lifeTime = 1f;
        displayed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GetComponent<Text>().enabled)
        {
            GetComponent<Text>().text = "LEVEL UP";
            if (transform.localScale.x < 1f && !displayed)
            {
                transform.localScale = new Vector3(transform.localScale.x + 2.5f * Time.deltaTime, transform.localScale.y + 2.5f * Time.deltaTime, transform.localScale.z);
            }
            else
            {
                displayed = true;
                lifeTime -= Time.deltaTime;
                if (lifeTime <= 0f)
                {
                    if (transform.localScale.x > 0f)
                    {
                        transform.localScale = new Vector3(transform.localScale.x - 2.5f * Time.deltaTime, transform.localScale.y - 2.5f * Time.deltaTime, transform.localScale.z);
                    }
                    else
                    {
                        GetComponent<Text>().enabled = false;
                        displayed = false;
                        lifeTime = 1f;
                    }
                }
            }
        }
	}
}
