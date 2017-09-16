using UnityEngine;
using System.Collections;

public class NextScene : MonoBehaviour {

    private float goToScene = 4f;
    public string next;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName.Contains("10"))
        {
            goToScene -= Time.deltaTime;
            if (goToScene <= 0f)
            {
                Application.LoadLevel(next);
            }
        }
        else
        {
            if (TextTranslate.isReady)
            {
                goToScene -= Time.deltaTime;
            }

            if (goToScene <= 0f)
            {
                Application.LoadLevel(next);
            }
        }
       
	}
}
