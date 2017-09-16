using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YourName : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "   " + PlayerPrefs.GetString("n");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
