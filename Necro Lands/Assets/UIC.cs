using UnityEngine;
using System.Collections;

public class UIC : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void tryagain()
    {
        Application.LoadLevel("quiz");
        PlayerPrefs.DeleteAll();
    }
}

