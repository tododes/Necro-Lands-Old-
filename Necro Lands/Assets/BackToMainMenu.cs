using UnityEngine;
using System.Collections;

public class BackToMainMenu : MonoBehaviour {

    void Start()
    {
        Camera.main.aspect = 1920f / 1080f;
    }
    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (Application.loadedLevelName == "WeaponExtra" || Application.loadedLevelName == "GhostExtra" || Application.loadedLevelName == "HowToPlay")
			Application.LoadLevel ("Extra");
		else if (Application.loadedLevelName == "Achievement") 
		{
            Application.LoadLevel("Game Menu Scene");
		}
		else
        	Application.LoadLevel("MainScene");
    }

    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, 0.17f);
    }

    public void Back()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("MainScene");
    }

    void OnMouseExit()
    {
        
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
