using UnityEngine;
using System.Collections;

public class VSText : MonoBehaviour {
    private AudioSource au;
    private bool played;
   
	// Use this for initialization
	void Start () {
        au = GetComponent<AudioSource>();
     
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z < -2f)
        {
            transform.Translate(Vector3.forward * 30f * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * 1f * Time.deltaTime);
            if (!played)
            {
                au.Play();
                played = true;
            }
        }
	}
}
