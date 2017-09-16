using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    private Transform player;
    private MeshRenderer myMesh;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myMesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Vector3.Distance(transform.position, player.position) > 300f && myMesh.enabled)
        {
            myMesh.enabled = false;
        }
        else if (Vector3.Distance(transform.position, player.position) < 300f && !myMesh.enabled)
        {
            myMesh.enabled = true;
        }
	}
}
