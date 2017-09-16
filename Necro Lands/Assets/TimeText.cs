using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class TimeText : MonoBehaviour {

    private Text text;
    private DateTime dt;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        dt = TimeManager.GetInstance().GetNow();
        text.text = dt.Hour + " : " + dt.Minute;
	}
}
