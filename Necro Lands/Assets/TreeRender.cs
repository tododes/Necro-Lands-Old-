using UnityEngine;
using System.Collections;

public class TreeRender : MonoBehaviour {

    private MeshRenderer myMesh;
    private Transform player;

    void Start()
    {
        myMesh = GetComponent<MeshRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	// Update is called once per frame
	void Update () 
    {
        if (Vector3.Distance(transform.position,player.position) >= 180f && myMesh.enabled)
        {
            myMesh.enabled = false;
        }
        else if (Vector3.Distance(transform.position, player.position) < 180f && !myMesh.enabled)
        {
            myMesh.enabled = true;
        }
	}
}
