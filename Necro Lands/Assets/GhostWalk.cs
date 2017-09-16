using UnityEngine;
using System.Collections;

public class GhostWalk : MonoBehaviour {
    private Animator anim;
    public static bool isArrived;
	// Use this for initialization
	void Start () {
        isArrived = false;
        anim = GetComponent<Animator>();
      
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("walk", true);
        /*if (transform.position.x >4.5f && transform.position.z > -1.9f)
        {
            transform.position = new Vector3(transform.position.x - 3 * Time.deltaTime, transform.position.y, transform.position.z - 3 * Time.deltaTime);
        }
        else
        {
            isArrived = true;
        }*/
	}
}
