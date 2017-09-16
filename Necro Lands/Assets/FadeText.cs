using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeText : MonoBehaviour {

	private int State;
	public float ColIndex;
	//private Color TextCol;
	// Use this for initialization
	void Start () {
		ColIndex = 1f;
		State = 1;
		//TextCol = GetComponent<Text> ().color;
		//TextCol = Color.white;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (State == 1) 
		{
			if(ColIndex > 0f)
				ColIndex -= 3f * Time.deltaTime;
			else
				State = 0;
		} 
		else if (State == 0) 
		{
			if(ColIndex < 1f)
				ColIndex += 3f * Time.deltaTime;
			else
				State = 1;
		}
		GetComponent<Text> ().color = Color.Lerp(Color.clear, Color.white, ColIndex);
	}
}
