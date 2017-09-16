using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NecroGoldText : MonoBehaviour {

    private Text myText;
	// Use this for initialization
	void Start () 
    {
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myText.text != PlayerPrefs.GetInt("platinum").ToString())
        {
            myText.text = PlayerPrefs.GetInt("platinum").ToString();
        }
	}
}
