using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillLevel : MonoBehaviour {

    private Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (text.text != "LEVEL " + PlayerPrefs.GetInt("currSkill"))
            text.text = "LEVEL " + PlayerPrefs.GetInt("currSkill");
	}
}
