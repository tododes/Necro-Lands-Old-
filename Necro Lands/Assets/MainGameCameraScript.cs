using UnityEngine;
using System.Collections;

public class MainGameCameraScript : MonoBehaviour {

    private Vector3 offset;
    private Transform target;
	// Use this for initialization
	void Start () 
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, 5f * Time.deltaTime);
	}
}
