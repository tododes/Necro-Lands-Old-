using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelText : MonoBehaviour {

    public Text levelUpText;
    private Text myText;
    private Player myPlayer;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myText.text != "LEVEL " + myPlayer.level)
        {
            if (myText.text != "")
                levelUpText.enabled = true;
            else
                levelUpText.enabled = false;
            myText.text = "LEVEL " + myPlayer.level; 
        }
        myText.text = "LEVEL " + myPlayer.level;
    }
}
