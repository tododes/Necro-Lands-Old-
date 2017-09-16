using UnityEngine;
using System.Collections;

public class SkillSprite : MonoBehaviour {

	public GameObject[] sprites;
	//public GameObject[] details;
	private int index;
	// Use this for initialization
	void Start () 
	{
		//Debug.Log (PlayerPrefs.GetString("charname"));
		for (int i=0; i<sprites.Length; i++) 
		{
			if(sprites[i].name.Contains(PlayerPrefs.GetString("charname")))
			{
				sprites[i].SetActive(true);
			}
			else
				sprites[i].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
