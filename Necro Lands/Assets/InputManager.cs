using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour {

    string yourName = "";
    private string[] nameChar = { "Grant", "Trevor", "Marcia", "Lucy" };

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void texting(string text)
    {
        yourName = text;
    }

    public void confirm()
    {
        GetComponent<AudioSource>().Play();
        PlayerPrefs.SetString("charname", nameChar[CharSelectManager.currIndex - 1]);
        PlayerPrefs.SetString("CH1", nameChar[CharSelectManager.currIndex - 1]);
        PlayerPrefs.SetInt("currSkill", 1);
      
    }
}
