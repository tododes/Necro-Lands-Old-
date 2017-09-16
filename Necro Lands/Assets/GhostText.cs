using UnityEngine;
using System.Collections;

public class GhostText : MonoBehaviour {
    private AudioSource au;
    private bool played;

    public string next;

    private float IntoNextScene = 3f;
	// Use this for initialization
	void Start () {
        au = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GhostWalk.isArrived)
        {
            if (transform.position.z < 2f)
                transform.Translate(Vector3.forward * 5f * Time.deltaTime);
            else
            {
                transform.Translate(Vector3.forward * 0.8f * Time.deltaTime);
                if (!played)
                {
                    au.Play();
                    played = true;
                }
                IntoNextScene -= Time.deltaTime;
                if (IntoNextScene <= 0f)
                {
                    Application.LoadLevel(next);
                }
            }
                
        }
	}
}
