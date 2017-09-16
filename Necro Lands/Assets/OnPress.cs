using UnityEngine;
using System.Collections;

public class OnPress : MonoBehaviour {

    public press p;
    bool isRight;
   
    public enum press
    {
        onetwo, twothree, threefour
    }


   public void OMD()
    {
        GetComponent<AudioSource>().Play();
        switch (p)
        {
            case press.onetwo:
                
                if (PlayerPrefs.GetInt("currSkill") == 1 && PlayerPrefs.GetInt("gold") >= 2500)
                {
                    PlayerPrefs.SetInt("currSkill", 2);
                    PlayerPrefs.SetInt("gold",PlayerPrefs.GetInt("gold") - 2500);
                }
                  
                break;
            case press.twothree:
               
                if (PlayerPrefs.GetInt("currSkill") == 2 && PlayerPrefs.GetInt("gold") >= 5000)
                {
                    PlayerPrefs.SetInt("currSkill", 3);
                    PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - 5000);
                }
                  
                break;
            case press.threefour:
               
                if (PlayerPrefs.GetInt("currSkill") == 3 && PlayerPrefs.GetInt("gold") >= 10000)
                {
                    PlayerPrefs.SetInt("currSkill", 4);
                    PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - 10000);
                }
                  
                break;
        }
    }

 
}

