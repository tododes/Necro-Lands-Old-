using UnityEngine;
using System.Collections;

public class MoneyText : MonoBehaviour {

    private float originScaleX, originBigX;
    public bool bigScaleActivated;
	// Use this for initialization
	void Start () 
    {
        originScaleX = GetComponent<RectTransform>().localScale.x;
       // originScaleY = GetComponent<RectTransform>().localScale.y;
        originBigX = GetComponent<RectTransform>().localScale.x + 0.25f;
        //originBigY = GetComponent<RectTransform>().localScale.y + 0.15f;

        bigScaleActivated = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (bigScaleActivated)
        {
            if (GetComponent<RectTransform>().localScale.x < originBigX)
            {
                GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x + 0.8f * Time.deltaTime, GetComponent<RectTransform>().localScale.y + 0.8f * Time.deltaTime, GetComponent<RectTransform>().localScale.z);
            }
            else
            {
                bigScaleActivated = false;
            }
        }
        else
        {
            if (GetComponent<RectTransform>().localScale.x > originScaleX)
            {
                GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x - 0.8f * Time.deltaTime, GetComponent<RectTransform>().localScale.y - 0.8f * Time.deltaTime, GetComponent<RectTransform>().localScale.z);
            }
        }
      
	}
}
