using UnityEngine;
using System.Collections;

public class TheButton : MonoBehaviour {
    public direction d;
    public enum direction {left, right}

   
	public bool onclick = false, goingLeft = false, goingRight = false;
	float x,ax,bx;

	void Start()
	{
		for (int i = 1; i <= 4; i++)
		{
            GameObject.Find("C" + i).transform.position = new Vector3(GameObject.Find("C" + i).transform.position.x, 8f, GameObject.Find("C" + i).transform.position.z);
		}
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
        for (int i = 1; i <= 4; i++)
        {
            //GameObject.Find("C" + i).transform.eulerAngles = new Vector3(GameObject.Find("C" + i).transform.eulerAngles.x, 180f, GameObject.Find("C" + i).transform.eulerAngles.z);
            if (i != CharSelectManager.currIndex)
            {
                GameObject.Find("C" + i).transform.position = new Vector3(GameObject.Find("C" + i).transform.position.x, 8f, GameObject.Find("C" + i).transform.position.z);
            }
        }
        if (onclick) 
		{
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
				transform.Translate (Vector3.left * 2.5f * Time.deltaTime);
			} else if (goingRight) {
				transform.Translate (Vector3.right * 2.5f * Time.deltaTime);
			}
		} 
		else 
		{
			transform.position = new Vector3(bx, transform.position.y, transform.position.z);
		}
		GameObject.Find("C" + CharSelectManager.currIndex).transform.position = new Vector3(GameObject.Find("C" + CharSelectManager.currIndex).transform.position.x, -0.2f, GameObject.Find("C" + CharSelectManager.currIndex).transform.position.z);
       
	}

    
   /* void OnMouseEnter()
    {
        if (!GameObject.Find("transparent").GetComponent<SpriteRenderer>().enabled)
        {
            if (this.gameObject.name == "goleft")
            {
                transform.localScale = new Vector3(transform.localScale.x - 0.07f, transform.localScale.y + 0.07f, transform.localScale.z);
            }
            else
                transform.localScale = new Vector3(transform.localScale.x + 0.07f, transform.localScale.y + 0.07f, transform.localScale.z);
        }
      
    }

    void OnMouseExit()
    {
        if (!GameObject.Find("transparent").GetComponent<SpriteRenderer>().enabled)
        {
            if (this.gameObject.name == "goleft")
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.07f, transform.localScale.y - 0.07f, transform.localScale.z);
            }
            else
                transform.localScale = new Vector3(transform.localScale.x - 0.07f, transform.localScale.y - 0.07f, transform.localScale.z);
        }
       
    }*/


	void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if (d == direction.left)
        {
         
            CharSelectManager.currIndex--;
            if (CharSelectManager.currIndex < 1)
                CharSelectManager.currIndex = 4;
       
        }

            else if (d == direction.right)
            {
         
            CharSelectManager.currIndex++;
             if (CharSelectManager.currIndex > 4)
                 CharSelectManager.currIndex = 1;
          

        }
        
       
    }

   
}
