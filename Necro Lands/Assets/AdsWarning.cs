using UnityEngine;
using System.Collections;

public class AdsWarning : MonoBehaviour {
    private float Timer;
	// Use this for initialization
	void Start () {
        Timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
        gameObject.SetActive(Timer < 4.0f);
	}
}
