using UnityEngine;
using System.Collections;

public class SkillDetail : MonoBehaviour {

	public Sprite[] details;
	public TextMesh text;
	private string[] skills = {"GENTLEMAN SPIRIT","FATAL SHOT","CHEERFUL BLOW","HYPNOCHARM"};
	private string[] names = {"Grant","Trevor","Marcia","Lucy"};
	private int idx;
	// Use this for initialization
	void Start () {
		for (int i=0; i<names.Length; i++) 
		{
			if(names[i] == PlayerPrefs.GetString("charname"))
			{
				idx = i;
				break;
			}
		}
		gameObject.GetComponent<SpriteRenderer> ().sprite = details [idx];
		text.text = skills [idx];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
