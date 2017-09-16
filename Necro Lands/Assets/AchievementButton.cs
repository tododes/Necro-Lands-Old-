using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class AchievementButton : MonoBehaviour, IPointerDownHandler {

	private BUTTONSTATE BSTATE;
	private enum BUTTONSTATE
	{
		LOCKED, READY, UNLOCKED
	}

	void SetColor()
	{
		if (PlayerPrefs.GetInt (gameObject.name) == 0 && BSTATE != BUTTONSTATE.LOCKED) 
		{
			BSTATE = BUTTONSTATE.LOCKED;
			GetComponent<Image>().color = Color.red;
			GetComponentInChildren<Text>().text = "LOCKED";
		}
		if (PlayerPrefs.GetInt (gameObject.name) == 1 && BSTATE != BUTTONSTATE.READY) 
		{
			BSTATE = BUTTONSTATE.READY;
			GetComponent<Image>().color = Color.blue;
			GetComponentInChildren<Text>().text = "UNLOCK";
		}
		if (PlayerPrefs.GetInt (gameObject.name) == 2 && BSTATE != BUTTONSTATE.UNLOCKED) 
		{
			BSTATE = BUTTONSTATE.UNLOCKED;
			GetComponent<Image>().enabled = false;
			GetComponentInChildren<Text>().text = "";
		}
	}

	void Update()
	{
		SetColor ();
	}

	public void OnPointerDown(PointerEventData data)
	{
		if (BSTATE == BUTTONSTATE.READY)
			PlayerPrefs.SetInt (gameObject.name,2);
	}
}
