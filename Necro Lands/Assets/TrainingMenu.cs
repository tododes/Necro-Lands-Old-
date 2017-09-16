using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class TrainingMenu : MonoBehaviour {

    public int index;
    public Fading fader;

    void InitializeKey()
    {
        if (!PlayerPrefs.HasKey("attack"))
        {
            PlayerPrefs.SetInt("attack", 0);
        }
        if (!PlayerPrefs.HasKey("armor"))
        {
            PlayerPrefs.SetInt("armor", 0);
        }
        if (!PlayerPrefs.HasKey("dur"))
        {
            PlayerPrefs.SetInt("dur", 0);
        }
    }
	// Use this for initialization
	void Start () 
    {
        InitializeKey();
	}

    void OnMouseDown()
    {
        if (index < 3)
            Upgrade.index = index;
        else
        {
            fader.Finish("Game Menu Scene");
        }
        /*if(gameObject.name == "Upgrade")
        {
          

        }*/
        /**/
    }

    
}
