using UnityEngine;
using System.Collections;

public class WEManager : MonoBehaviour {
    public static int indexDisplay ;
	// Use this for initialization
	void Start ()
    {
        Camera.main.aspect = 1920f / 1080f;
        indexDisplay = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 1; i <= 12; i++)
        {
            if (i == indexDisplay)
            {
               GameObject.Find("w" + i).GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().enabled = true;
            }
              
           else
            {
                GameObject.Find("w" + i).GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().enabled = false;
            }
               
        }
	}

   /* void OnMouseOver()
    {
        if (GameObject.Find("w" + indexDisplay).GetComponent<SpriteRenderer>().enabled)
        {
            for (int i = 1; i <= 12; i++)
            {
                if (i == indexDisplay)
                    GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().enabled = true;
                else
                    GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().enabled = false;
            }
        }
      
    }*/
}
