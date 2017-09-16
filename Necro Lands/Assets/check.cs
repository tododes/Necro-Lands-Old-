using UnityEngine;
using System.Collections;

public class check : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        Debug.Log(PlayerPrefs.GetString("currSkill"));
	}
}
