using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarningText : MonoBehaviour 
{
    private Text myText;
   

    private float x;

    void Start()
    {
        x = 0f;
        myText = GetComponent<Text>();
    }

    void Update()
    {
        if (myText.color != Color.Lerp(Color.clear, Color.red, x))
            myText.color = Color.Lerp(Color.clear, Color.red, x);
        if (x > 0f)
        {
            x -= 0.5f * Time.deltaTime;
        }
    }

    public void DisplayWarning(string t)
    {
        myText.text = t;
        x = 1f;
    }
}
