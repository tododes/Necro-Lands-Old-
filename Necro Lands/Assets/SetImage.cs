using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetImage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Image>().sprite != null)
            GetComponent<Image>().enabled = false;
	}
}
