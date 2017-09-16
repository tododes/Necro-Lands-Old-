using UnityEngine;
using System.Collections;

public class EnemyDemoCamera : MonoBehaviour {

    public int index;
    public float Destination;
    public float DestinationY;

    public CAMERASTATE CSTATE;
    public enum CAMERASTATE
    { 
        ENEMYINFO, ITEMINFO, GAMEPLAYINFO
    }
	// Use this for initialization
	void Start () 
    {
        index = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.x < Destination)
            transform.Translate(Vector3.right * 40f * Time.deltaTime);
        if (transform.position.x > Destination)
            transform.Translate(Vector3.left * 40f * Time.deltaTime);

        if (transform.position.y < DestinationY)
            transform.Translate(Vector3.up * 40f * Time.deltaTime);
        if (transform.position.y > DestinationY)
            transform.Translate(Vector3.down * 40f * Time.deltaTime);
	}

    public void SetDes()
    {
        Destination = 30f * index;
    }

    public void DecIndex()
    {
        if (index > 0)
            index--;
    }

    public void incIndex()
    {
        if (CSTATE == CAMERASTATE.ENEMYINFO)
        {
            if (index < 5)
                index++;
        }
        else if (CSTATE == CAMERASTATE.ITEMINFO)
        {
            if (index < 14)
                index++;
        }
        else
        {
            if (index < 2)
                index++;
        }
    }
}
