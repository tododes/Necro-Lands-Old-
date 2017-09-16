using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AttributeDisplay : MonoBehaviour {

  
    GameObject[] sliderFill;
    int[] HpValue = {5,1,2,4};
    int[] AtkValue = {3,5,3,4};
    int[] ArmValue = {5,1,3,5};
    int[] SpdValue = {1,5,4,1};
    int[] SRValue = {3,4,4,2};
    Color[] textCol = { Color.green, Color.red, Color.yellow, Color.magenta };

    void Start()
    {
        
        sliderFill = GameObject.FindGameObjectsWithTag("Fill");
    }

    void Update()
    {
       GameObject.Find("HPSlider").GetComponent<Slider>().value = HpValue[CharSelectManager.currIndex-1];
       GameObject.Find("AtkSlider").GetComponent<Slider>().value = AtkValue[CharSelectManager.currIndex-1];
       GameObject.Find("ArmorSlider").GetComponent<Slider>().value = ArmValue[CharSelectManager.currIndex-1];
       GameObject.Find("SRSlider").GetComponent<Slider>().value = SRValue[CharSelectManager.currIndex-1];
       GameObject.Find("SpeedSlider").GetComponent<Slider>().value = SpdValue[CharSelectManager.currIndex-1];
        for (int i = 0; i < sliderFill.Length; i++)
        {
            sliderFill[i].GetComponent<Image>().color = textCol[CharSelectManager.currIndex - 1];
        } 
    }
}
