using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float smoothing;

    private GameObject player;
    private Vector3 offset;
    

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //player = GameObject.Find(PlayerPrefs.GetString("charname"));
        offset = transform.position - player.transform.position;
	}

    void Update()
    {

    }
	// Update is called once per frame
	void LateUpdate () {
      
        if (StartupManager.isStarted)
        {
            Vector3 newPosition = player.transform.position + offset;

            transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.deltaTime);
        }
      
	}
}
