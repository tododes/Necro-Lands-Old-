using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeNotification : MonoBehaviour {

    private Image i;
    //private string[] key = {"A","AR","D"};
    //private Image[] n;
	// Use this for initialization
	void Start () 
    {
        i = GetComponent<Image>();
       /* n = new Image[3];
        for (int x = 0; x < 3; x++)
        {
            n[x] = GameObject.Find("N" + i).GetComponent<Image>();
        }*/
	}
	
	// Update is called once per frame
	void Update () 
    {
      
            if (PlayerPrefs.GetInt(this.name) == 1)
            {
                i.enabled = true;
            }
            else
            {
                i.enabled = false;
            }
        
     
	}
}
