using UnityEngine;
using System.Collections;


public class ButtonScript : MonoBehaviour {

	public int butIndex;
	public int posState;
	private float XPos, XPos2;
	void Start()
	{
		if (butIndex == 0) 
		{
			XPos = GetComponent<RectTransform> ().position.x;
			XPos2 = GetComponent<RectTransform> ().position.x - 30f;
		}
		else if (butIndex == 1) 
		{
			XPos = GetComponent<RectTransform> ().position.x;
			XPos2 = GetComponent<RectTransform> ().position.x + 30f;
		}

	}

	void Update()
	{
		/*if (posState == 0) 
		{
			if(GetComponent<RectTransform> ().position.x > XPos2)
			{
				GetComponent<RectTransform> ().Translate(Vector3.left * 70f * Time.deltaTime);
			}
			else
				posState = 1;
		} 
		else if (posState == 1) 
		{
			if(GetComponent<RectTransform> ().position.x < XPos)
			{
				GetComponent<RectTransform> ().Translate(Vector3.right * 70f * Time.deltaTime);
			}
			else
				posState = 0;
		}*/
		if (butIndex == 1) 
		{
			if (posState == 0) 
			{
				if(GetComponent<RectTransform> ().position.x < XPos2)
				{
					GetComponent<RectTransform> ().Translate(Vector3.right * 70f * Time.deltaTime);
				}
				else
					posState = 1;
			} 
			else if (posState == 1) 
			{
				if(GetComponent<RectTransform> ().position.x > XPos)
				{
					GetComponent<RectTransform> ().Translate(Vector3.left * 70f * Time.deltaTime);
				}
				else
					posState = 0;
			}
		}
		else if (butIndex == 0) 
		{
			if (posState == 0) 
			{
				if(GetComponent<RectTransform> ().position.x > XPos2)
				{
					GetComponent<RectTransform> ().Translate(Vector3.left * 70f * Time.deltaTime);
				}
				else
					posState = 1;
			} 
			else if (posState == 1) 
			{
				if(GetComponent<RectTransform> ().position.x < XPos)
				{
					GetComponent<RectTransform> ().Translate(Vector3.right * 70f * Time.deltaTime);
				}
				else
					posState = 0;
			}
		}
	}
}
