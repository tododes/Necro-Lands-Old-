using UnityEngine;
using System.Collections;

public class MusicVolumeScript : MonoBehaviour {

    private AudioSource myAudio;
	// Use this for initialization
	void Start () 
    {
        myAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myAudio.volume != PlayerPrefs.GetFloat("Music"))
        {
            myAudio.volume = PlayerPrefs.GetFloat("Music");
        }
	}
}
