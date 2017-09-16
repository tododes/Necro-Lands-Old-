using UnityEngine;
using System.Collections;

public class SkillSceneCameraScript : MonoBehaviour {

	private float destination, index = 0;

	public void IncrementIndex()
	{
		if(index < 3)
		index++;
	}
	public void DecrementIndex()
	{
		if(index > 0)
		index--;
	}
	public void SetDes()
	{
		destination = 50f * index;
	}

	void Update()
	{
		if (transform.position.x < destination)
			transform.Translate (Vector3.right * 55f * Time.deltaTime);
		if (transform.position.x > destination)
			transform.Translate (Vector3.left * 55f * Time.deltaTime);
	}
}
