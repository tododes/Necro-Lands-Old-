using UnityEngine;
using System.Collections;

public class BoxStaticHolder : MonoBehaviour {

	void Update () 
    {
        //transform.LookAt(Camera.main.transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
	}
}
