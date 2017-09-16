using UnityEngine;

using System.Collections;

public class Classmenu : MonoBehaviour
{
	public classbut cb;
	public enum classbut
	{
		class1, class2, class3, class4, class5
	}

	void OnMouseEnter()
	{
        transform.localScale = new Vector3(transform.localScale.x + 0.12f, transform.localScale.y + 0.12f, transform.localScale.z);
	}

	void OnMouseExit()
	{
        transform.localScale = new Vector3(transform.localScale.x - 0.12f, transform.localScale.y - 0.12f, transform.localScale.z);
    }

	void OnMouseDown()
	{
        if (cb == classbut.class1)
        {

        }

        else if (cb == classbut.class2)
        {

        }

        else if (cb == classbut.class3)
        {
            
        }

        else if (cb == classbut.class4)
        {
            
        }
        else if (cb == classbut.class5)
        {

        }

    }



}

