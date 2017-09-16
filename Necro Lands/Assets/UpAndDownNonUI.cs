using UnityEngine;
using System.Collections;

public class UpAndDownNonUI : MonoBehaviour {
    private float origin, dest;
    private bool arriveUp, arriveDown, arriveLeft, arriveRight;

    public orientation o;
    public enum orientation
    {
        LR, UD
    }
	// Use this for initialization
	void Start () 
    {

        if (o == orientation.UD)
        {
            origin = GetComponent<Transform>().position.y;
            dest = GetComponent<Transform>().position.y + 0.15f;
            arriveDown = true;
            arriveUp = false;
        }
        else
        {
            origin = GetComponent<Transform>().position.x;
            dest = GetComponent<Transform>().position.x + 0.15f;
            arriveLeft = true;
            arriveRight = false;
        }
        

	}
	
	// Update is called once per frame
	void Update () 
    {
      
            if (o == orientation.UD)
            {
                ArrivalValidationUD();
            }
            else
            {
                ArrivalValidationLR();
            }
        
     
	}

    void ArrivalValidationUD()
    {
        if (arriveDown && GetComponent<Transform>().position.y < dest)
        {
            GetComponent<Transform>().Translate(Vector3.up * 0.7f * Time.deltaTime);
        }
        else
        {
            arriveDown = false;
            arriveUp = true;
        }

        if (arriveUp && GetComponent<Transform>().position.y > origin)
        {
            GetComponent<Transform>().Translate(Vector3.down * 0.7f * Time.deltaTime);
        }
        else
        {
            arriveDown = true;
            arriveUp = false;
        }
        
     
    }


    void ArrivalValidationLR()
    {

        if (arriveLeft && GetComponent<Transform>().position.x < dest)
        {
            GetComponent<Transform>().Translate(Vector3.right * 0.7f * Time.deltaTime);
        }
        else
        {
            arriveLeft = false;
            arriveRight = true;
        }

        if (arriveRight && GetComponent<Transform>().position.x > origin)
        {
            GetComponent<Transform>().Translate(Vector3.left * 0.7f * Time.deltaTime);
        }
        else
        {
            arriveLeft = true;
            arriveRight = false;
        }
        
      
    }
}
