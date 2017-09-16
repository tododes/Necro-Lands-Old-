using UnityEngine;
using System.Collections;

public class GrantSkill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            if (PlayerPrefs.GetInt("currSkill") == 1)
                coll.GetComponent<Enemy>().Armor -= 5;
            else if (PlayerPrefs.GetInt("currSkill") == 2)
                coll.GetComponent<Enemy>().Armor -= 15;
            else if (PlayerPrefs.GetInt("currSkill") == 3)
                coll.GetComponent<Enemy>().Armor -= 25;
            else if (PlayerPrefs.GetInt("currSkill") == 4)
                coll.GetComponent<Enemy>().Armor -= 35;
        }
        
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            if (PlayerPrefs.GetInt("currSkill") == 1)
                coll.GetComponent<Enemy>().Armor += 5;
            else if (PlayerPrefs.GetInt("currSkill") == 2)
                coll.GetComponent<Enemy>().Armor += 15;
            else if (PlayerPrefs.GetInt("currSkill") == 3)
                coll.GetComponent<Enemy>().Armor += 25;
            else if (PlayerPrefs.GetInt("currSkill") == 4)
                coll.GetComponent<Enemy>().Armor += 35;
        }
    }
}
