using UnityEngine;
using System.Collections;

public class UpAndDown : MonoBehaviour {
    private float origin, dest;
    private bool arriveUp, arriveDown, arriveLeft, arriveRight;

    public orientation o;
    public enum orientation
    {
        LR,UD
    }
	// Use this for initialization
	void Start () 
    {
     
            if (o == orientation.UD)
            {
                origin = GetComponent<RectTransform>().position.y;
                dest = GetComponent<RectTransform>().position.y + 10f;
                arriveDown = true;
                arriveUp = false;
            }
            else
            {
                origin = GetComponent<RectTransform>().position.x;
                dest = GetComponent<RectTransform>().position.x + 10f;
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
       
            if (arriveDown && GetComponent<RectTransform>().position.y < dest)
            {
                GetComponent<RectTransform>().Translate(Vector3.up * 40f * Time.deltaTime);
            }
            else
            {
                arriveDown = false;
                arriveUp = true;
            }

            if (arriveUp && GetComponent<RectTransform>().position.y > origin)
            {
                GetComponent<RectTransform>().Translate(Vector3.down * 40f * Time.deltaTime);
            }
            else
            {
                arriveDown = true;
                arriveUp = false;
            }
     
         
    }

    void ArrivalValidationLR()
    {
     
            if (arriveLeft && GetComponent<RectTransform>().position.x < dest)
            {
                GetComponent<RectTransform>().Translate(Vector3.right * 40f * Time.deltaTime);
            }
            else
            {
                arriveLeft = false;
                arriveRight = true;
            }

            if (arriveRight && GetComponent<RectTransform>().position.x > origin)
            {
                GetComponent<RectTransform>().Translate(Vector3.left * 40f * Time.deltaTime);
            }
            else
            {
                arriveLeft = true;
                arriveRight = false;
            }
     
    }

}
