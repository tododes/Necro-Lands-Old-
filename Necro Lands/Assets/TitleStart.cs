using UnityEngine;
using System.Collections;
using Todo;

public class TitleStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > 4.1f)
            Action.MoveY(gameObject.name,-6f);
	}
}
