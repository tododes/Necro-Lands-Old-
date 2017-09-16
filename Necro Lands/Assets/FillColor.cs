using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillColor : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerPrefs.GetString("charname") == "Grant")
        {
            GetComponent<Image>().color = Color.green;
        }
        else if (PlayerPrefs.GetString("charname") == "Trevor")
        {
            GetComponent<Image>().color = Color.red;
        }
        else if (PlayerPrefs.GetString("charname") == "Marcia")
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else if (PlayerPrefs.GetString("charname") == "Lucy")
        {
            GetComponent<Image>().color = Color.magenta;
        }
    }
}
