using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class SFXVolumeScript : MonoBehaviour{

    private AudioSource myAudio;
	// Use this for initialization
	void Start () 
    {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myAudio.volume != PlayerPrefs.GetFloat("SFX"))
        {
            myAudio.volume = PlayerPrefs.GetFloat("SFX");
        }
	}
}
