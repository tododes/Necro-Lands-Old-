using UnityEngine;
using System.Collections;

public class CameraMainMenuScript : MonoBehaviour {

    private float Destination;
	// Use this for initialization
	void Start () {
        Destination = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < Destination)
            transform.Translate(Vector3.up * 25f * Time.deltaTime);
        if (transform.position.y > Destination)
            transform.Translate(Vector3.down * 25f * Time.deltaTime);
    }

    public void SetDestination(float d)
    {
        Destination = d;
        GetComponent<AudioSource>().Play();
    }
}
