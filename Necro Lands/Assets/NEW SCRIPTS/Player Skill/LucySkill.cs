using UnityEngine;
using System.Collections;

public class LucySkill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            if (PlayerPrefs.GetInt("currSkill") == 1)
                coll.GetComponent<Enemy>().Attack -= 30;
            else if (PlayerPrefs.GetInt("currSkill") == 2)
                coll.GetComponent<Enemy>().Attack -= 60;
            else if (PlayerPrefs.GetInt("currSkill") == 3)
                coll.GetComponent<Enemy>().Attack -= 90;
            else if (PlayerPrefs.GetInt("currSkill") == 4)
                coll.GetComponent<Enemy>().Attack -= 120;
        }
            
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            if (PlayerPrefs.GetInt("currSkill") == 1)
                coll.GetComponent<Enemy>().Attack += 30;
            else if (PlayerPrefs.GetInt("currSkill") == 2)
                coll.GetComponent<Enemy>().Attack += 60;
            else if (PlayerPrefs.GetInt("currSkill") == 3)
                coll.GetComponent<Enemy>().Attack += 90;
            else if (PlayerPrefs.GetInt("currSkill") == 4)
                coll.GetComponent<Enemy>().Attack += 120;
        }
            
    }
}
