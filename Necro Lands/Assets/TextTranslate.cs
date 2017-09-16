using UnityEngine;
using System.Collections;

public class TextTranslate : MonoBehaviour {
    public static bool isReady = false;
    private bool soundPlay;
    //private bool soundPlay;
    // Use this for initialization
    void Start () {
        isReady = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(isReady);
        if (TrailerScript.isSlow)
        {
            if (transform.position.z < 0f)
            {
                transform.Translate(Vector3.forward * 6.5f * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * 0.7f * Time.deltaTime);
                if (!soundPlay)
                {
                    GetComponent<AudioSource>().Play();
                    soundPlay = true;
                }
                isReady = true;
            }
              
        }
	}
}
