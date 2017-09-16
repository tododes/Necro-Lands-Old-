using UnityEngine;
using UnityEngine.UI;
using Todo;
using System.Collections;

public class Mainmenu : MonoBehaviour
{
	public menubut mb;
    /* GameObject arrow;
     GameObject[] s;
     GameObject t;
     */

    private HelpManager help;
  
    public Fading fade;
    public CameraMainMenuScript cm;

    private bool AdsViewed;

    void Start()
    {
        AdsViewed = false;
        /* arrow = GameObject.Find("arrow");
         t = GameObject.Find("transparent");
         s = GameObject.FindGameObjectsWithTag("strategy");*/
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("gold"))
        {
            PlayerPrefs.SetInt("gold", 1000);
        }

        if (!PlayerPrefs.HasKey("Music"))
        {
            PlayerPrefs.SetFloat("Music", 1f);
        }

        if (!PlayerPrefs.HasKey("SFX"))
        {
            PlayerPrefs.SetFloat("SFX", 1f);
        }
    }
	public enum menubut
	{
		newgame,
		loadgame,
		highscore,
        extras,
		quitgame
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	void OnMouseOver()
	{
        GetComponent<TextMesh>().color = Color.green;
     
    }

    void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.white;

    }

	void OnMouseDown()
	{
       
        if (mb == menubut.newgame)
        {
            //if (PlayerPrefs.GetString("charname") == "" || PlayerPrefs.GetString("charname") == " ")
            //    fade.Finish("CharSelection");
            //else
            //    fade.Finish("Game Menu Scene");
            if (!AdsViewed)
            {
                AdsManager.singleton.ShowAd();
                AdsViewed = true;
            }
            else
                PlayGamePanel.GetPlayGamePanel().Summon();
        }

        else if (mb == menubut.loadgame)
        {
            cm.SetDestination(-20f);
        }

        else if (mb == menubut.extras)
        {
            if (!AdsViewed)
            {
                AdsManager.singleton.ShowAd();
                AdsViewed = true;
            }
            else
                fade.Finish("Game Info");
            GetComponent<AudioSource>().Play();
        }

        else if (mb == menubut.quitgame)
        {
            Application.Quit();
        }
        
        //}
        GetComponent<AudioSource>().Play();
    }



}

