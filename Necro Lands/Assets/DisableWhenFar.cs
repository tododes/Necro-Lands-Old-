using UnityEngine;
using System.Collections;

public class DisableWhenFar : MonoBehaviour {
    private Transform player;
   // private MeshFilter mf;
    private MeshRenderer mr;
	// Use this for initialization
	void Start () 
    {
        mr = GetComponent<MeshRenderer>();
      //  mf = GetComponent<MeshFilter>();
        player = GameObject.Find(PlayerPrefs.GetString("charname")).GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Vector3.Distance(transform.position, player.position) <= 60f)
        {
            mr.enabled = true;
        }
        else
        {
            mr.enabled = false;
        }
	}
}
