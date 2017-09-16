using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class skillImaging : MonoBehaviour {

    public Sprite[] skillimg;
    string[] charname = { "Grant","Trevor","Marcia","Lucy"};
    int index = 0;
	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < charname.Length; i++)
        {
            if (PlayerPrefs.GetString("charname") == charname[i])
            {
                index = i;
                break;
            }
        }
        GetComponent<Image>().sprite = skillimg[index];
    }
	
	// Update is called once per frame
	void Update () {
       
	}
}
