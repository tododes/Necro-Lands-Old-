using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Atrribute : MonoBehaviour 
{
    public string AttrKey;
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(AttrKey).ToString();
	}
}
