using UnityEngine;
using System.Collections;

public class PawnBall : MonoBehaviour {

    private VirtualJoystick Controller;
	// Use this for initialization
	void Start () 
    {
        Controller = VirtualJoystick.GetInstance();
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Controller.GetInputVector() * 10f * Time.deltaTime);
	}
}
