using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class goldText : MonoBehaviour {
    private Text myText;
    private bool ValueInitiated;
    private RectTransform rect;
	// Use this for initialization
	void Start () 
    {
        myText = GetComponent<Text>();
        ValueInitiated = false;
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myText.text != "" + PlayerPrefs.GetInt("gold"))
        {
            myText.text = "" + PlayerPrefs.GetInt("gold");
            ValueInitiated = true;
        }

        if (ValueInitiated)
        {
            if (rect.localScale.x < 0.5f)
            {
                rect.localScale = new Vector3(rect.localScale.x + 0.8f * Time.deltaTime, rect.localScale.y + 0.8f * Time.deltaTime, rect.localScale.z);
            }
            else
                ValueInitiated = false;
        }
        else if (!ValueInitiated && rect.localScale.x > 0.3f)
        {
            rect.localScale = new Vector3(rect.localScale.x - 0.8f * Time.deltaTime, rect.localScale.y - 0.8f * Time.deltaTime, rect.localScale.z);
        }
           
	}
}
