using UnityEngine;
using System.Collections;

public class GELeftRight : MonoBehaviour {

    public dir d;
    public enum dir {left,right};
	bool onclick = false, goingLeft = false, goingRight = false;
	float x,ax,bx;

	void Start()
	{
		x = transform.position.x + 0.3f;
		bx = transform.position.x;
		ax = transform.position.x - 0.3f;

	}

	void OnMouseOver()
	{
		onclick = true;
	}

	void OnMouseExit()
	{
		onclick = false;
	}


	
	void Update()
	{
		if (onclick) {
			if (transform.position.x >= x) {
				goingLeft = true;
				goingRight = false;
			} else if (transform.position.x <= x && !goingLeft) {
				goingRight = true;
			}
			
			if (transform.position.x <= ax) {
				goingRight = true;
				goingLeft = false;
			} else if (transform.position.x >= ax && !goingRight) {
				goingLeft = true;
			}
			
			if (goingLeft) {
				transform.Translate (Vector3.left * 4f * Time.deltaTime);
			} else if (goingRight) {
				transform.Translate (Vector3.right * 4f * Time.deltaTime);
			}
		} else {
			transform.position = new Vector3 (bx, transform.position.y, transform.position.z);
		}
	}

    void OnMouseDown()
    {
        if (d == dir.left)
        {
            GEManager.index--;
            if (GEManager.index < 1)
                GEManager.index = 5;
        }
        else if (d == dir.right)
        {
           GEManager.index++;
            if (GEManager.index > 5)
                GEManager.index = 1;
        }
    }
}
