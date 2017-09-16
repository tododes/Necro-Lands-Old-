using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseButton : MonoBehaviour {

    public GameObject QuitConfirmation;

    private Image myImage;
    private Button myButton;
    private Text myText;
	// Use this for initialization
	void Start () 
    {
        myImage = GetComponent<Image>();
        myButton = GetComponent<Button>();
        myText = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (myImage.enabled != (!QuitConfirmation.activeInHierarchy))
            myImage.enabled = myButton.enabled = myText.enabled = (!QuitConfirmation.activeInHierarchy);
	}
}
