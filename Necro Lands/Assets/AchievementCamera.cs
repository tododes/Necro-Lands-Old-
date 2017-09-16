﻿using UnityEngine;
using System.Collections;

public class AchievementCamera : MonoBehaviour {

	public float dragSpeed = -3f;
	public Vector3 dragOrigin;

	void Update()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			dragOrigin = Input.mousePosition;
		}
		if (!Input.GetMouseButton (0)) 
		{
			return;
		}

		Vector3 pos = Camera.main.ScreenToViewportPoint (Input.mousePosition - dragOrigin);
		Vector3 move = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0);

		transform.Translate (move, Space.World);
	}
}
