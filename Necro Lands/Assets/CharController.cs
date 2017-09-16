using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 180f, transform.eulerAngles.z);
	}
}
