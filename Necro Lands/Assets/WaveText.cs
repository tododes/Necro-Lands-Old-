using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveText : MonoBehaviour {

    private Text text;
    private RectTransform rect;
    public float timerToFade;
    private bool displayed;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        rect = GetComponent<RectTransform>();
        timerToFade = 5f;
        displayed = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (text.enabled)
        {
            if (rect.localScale.x < 1f && !displayed)
            {
                rect.localScale = new Vector3(rect.localScale.x + 1.2f * Time.deltaTime, rect.localScale.y + 1.2f * Time.deltaTime, rect.localScale.z);
            }
            else
            {
                timerToFade -= Time.deltaTime;
                displayed = true;
                if (timerToFade <= 0f)
                {
                    if (rect.localScale.x > 0f)
                    {
                        rect.localScale = new Vector3(rect.localScale.x - 1.2f * Time.deltaTime, rect.localScale.y - 1.2f * Time.deltaTime, rect.localScale.z);
                    }
                    else
                    {
                        GetComponent<Text>().enabled = false;
                        displayed = false;
                        timerToFade = 5f;
                    }
                }
            }
           /* else
            {
                timerToFade -= Time.deltaTime;
                if (timerToFade <= 0f)
                {
                    timerToFade = 2f;
                    text.enabled = false;
                }
            }*/
        }
        /*else
        {
            rect.localScale = new Vector3(0, 0, rect.localScale.z);
        }*/
      
	}
}
