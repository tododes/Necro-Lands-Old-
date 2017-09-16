using UnityEngine;
using System.Collections;

public class TrailerScript : MonoBehaviour {
    public float firstVelocity, secondVelocity;
    public static bool isSlow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -2.2f)
        {
            transform.Translate(Vector3.up * firstVelocity * Time.deltaTime);
        }
        else if (transform.position.y < -1f)
        {
            transform.Translate(Vector3.up * secondVelocity * Time.deltaTime);
            isSlow = true;
        }
    }
}
