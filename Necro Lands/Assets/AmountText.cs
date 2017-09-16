using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmountText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "x" + PlayerPrefs.GetInt(gameObject.name);
	}
}
