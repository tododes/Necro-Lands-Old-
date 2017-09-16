using UnityEngine;
using System.Collections;

public class RenderingCondition : MonoBehaviour {

    public float distance;
    private Transform player;
    private MeshRenderer meshR;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find(PlayerPrefs.GetString("charname")).GetComponent<Transform>();
        meshR = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        distance = Vector3.Distance(transform.position,player.position);
        if (distance < 60f)
        {
			if(!meshR.enabled)
            	meshR.enabled = true;
        }
        else
        {
			if(meshR.enabled)
            	meshR.enabled = false;
        }
	}
}
