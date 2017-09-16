using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderText : MonoBehaviour {

    private Slider mySlider;
    private Text myText;
    private float maxValue;
    private float value;
	// Use this for initialization
	void Start () 
    {
        mySlider = GetComponentInParent<Slider>();
        myText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (maxValue != mySlider.maxValue)
            maxValue = mySlider.maxValue;
        if (value != mySlider.value)
            value = mySlider.value;
        if (myText.text != (int)value + " / " + (int)maxValue)
            myText.text = (int)value + " / " + (int)maxValue;
	}
}
