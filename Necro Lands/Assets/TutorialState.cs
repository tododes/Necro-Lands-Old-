using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialState : MonoBehaviour {

	public string[] tText;
	public static bool isBegan, isTutorial;
	public static int countKill;
	private Text tutorialText;
	private int counter = 0;
	private Image tutorImg, transparent, arrowImage;
	private GameObject[] pointers;


	// Use this for initialization
	void Start () 
	{
		countKill = 0;
		pointers = new GameObject[5];
		tutorImg = GameObject.Find ("Image (3)").GetComponent<Image>();
		transparent = GameObject.Find ("Image (4)").GetComponent<Image>();
		for (int i=0; i<5; i++) 
		{
			pointers[i] = GameObject.Find("Pointer"+(i+1));
			pointers[i].GetComponent<Image>().enabled = false;
		}
		isBegan = false;
		isTutorial = false;
		tutorialText = GameObject.Find ("TutorialText").GetComponent<Text>();


		arrowImage = GameObject.Find ("ArrowImage").GetComponent<Image>();
		tText [3] = "This is your level and exp bar. \nYou will get exp points when killing\nenemy.";
		tText [4] = "This is your attributes, consisting \nof health bar, attack,\nand armor.";
		tText [5] = "This is your items. Items are used\nto strengthen your fighting\ncapabilities.";
		tText [6] = "The minimap will show you where\nare the enemies when they are\n out of your sight.";
		tText [7] = "And lastly, this is your gold.\nYou will earn golds by killing\nenemy.";
		tText [8] = "You also have abilities. One is\na passive ability and the other\n is the active one";
		tText [9] = "Press Q to use the active ability!!";
		tText [10] = "Now go on and fight the enemies!!";
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (isBegan) 
		{
			isTutorial = true;
			Enable ();

			if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.KeypadEnter)) 
			{
				counter++;
			}
			if (counter < 11)
			{
				tutorialText.text = tText [counter];
				for(int i=3;i<=7;i++)
				{
					if(i == counter)
					{
						pointers[i-3].GetComponent<Image>().enabled = true;
					}
					else
					{
						pointers[i-3].GetComponent<Image>().enabled = false;
					}
				}
                
			 }
			else if(counter >= 11)
			{

				Disable();
				isTutorial = false;
			}
		} 
		else 
		{
			Disable();
		}
	
	}

	void Disable()
	{
		tutorImg.enabled = false;
		transparent.enabled = false;
		arrowImage.enabled = false;
		tutorialText.text = "";
	}

	void Enable()
	{
		tutorImg.enabled = true;
		transparent.enabled = true;
		arrowImage.enabled = true;

	}
}
