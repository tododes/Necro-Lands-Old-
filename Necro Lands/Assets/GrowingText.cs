using UnityEngine;
using System.Collections;

public class GrowingText : MonoBehaviour {

    public float target;
    public float growingSpeed;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(StartGame());
	}

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel("MainScene");
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.localScale.x < target)
        {
            transform.localScale = new Vector3(transform.localScale.x + growingSpeed * Time.deltaTime, transform.localScale.y + growingSpeed * Time.deltaTime, transform.localScale.z);
        }
	}
}
