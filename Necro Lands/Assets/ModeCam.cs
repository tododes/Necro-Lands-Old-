using UnityEngine;
using System.Collections;

public class ModeCam : MonoBehaviour {

	private float destination;
	private int index;

    public GameObject endlessLevel;
	// Use this for initialization
	void Start () {
		destination = 40f;
		index = 1;
	}
	
	// Update is called once per frame
	void Update () {

		if (destination > transform.position.x) {
			transform.Translate (Vector3.right * 40f * Time.deltaTime);
		} 
		if (destination < transform.position.x)
		{
			transform.Translate (Vector3.left * 40f * Time.deltaTime);
		}
	}

	public void IncrementIndex()
	{
        if (!endlessLevel.activeInHierarchy)
        {
            if (index < 9)
                index++;
        }
		

	}

	public void DecrementIndex()
	{
        if (!endlessLevel.activeInHierarchy)
        {
            if (index > 1)
                index--;
        }
		
	}

	public void SetDestination()
    {
        if (!endlessLevel.activeInHierarchy)
        {
            destination = 40 * index;
        }
	}
}
