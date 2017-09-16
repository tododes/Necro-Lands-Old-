using UnityEngine;
using System.Collections;

public class translateToMenu : MonoBehaviour {

    float origin, destination;
    public static bool sceneFinished, sceneStarted;
	// Use this for initialization
	void Start () 
    {
        sceneStarted = true;
        sceneFinished = false;
        destination = GetComponent<RectTransform>().position.y;
        if (gameObject.tag.Contains("Low"))
        {
            origin = GetComponent<RectTransform>().position.y - 600f;
        }
        else if (gameObject.tag.Contains("High"))
        {
            origin = GetComponent<RectTransform>().position.y + 600f;
        }
        GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, origin, GetComponent<RectTransform>().position.z);
	}
	
	// Update is called once per frame
	void Update()
    {
        if (sceneStarted)
        {
            if (gameObject.tag.Contains("Low") && GetComponent<RectTransform>().position.y < destination)
            {
                GetComponent<RectTransform>().Translate(Vector3.up * 500f * Time.deltaTime);
            }
            else if (gameObject.tag.Contains("High") && GetComponent<RectTransform>().position.y > destination)
            {
                GetComponent<RectTransform>().Translate(Vector3.down * 500f * Time.deltaTime);
            }
           
        }
        else if (sceneFinished)
        {
            if (gameObject.tag.Contains("High") && GetComponent<RectTransform>().position.y < origin)
            {
                GetComponent<RectTransform>().Translate(Vector3.up * 500f * Time.deltaTime);
            }
            else if (gameObject.tag.Contains("Low") && GetComponent<RectTransform>().position.y > origin)
            {
                GetComponent<RectTransform>().Translate(Vector3.down * 500f * Time.deltaTime);
            }
        }
	}

    public void setSceneStarted()
    {
        sceneStarted = true;
        sceneFinished = false;
    }

    public void setSceneFinished()
    {
        sceneStarted = false;
        sceneFinished = true;
    }
}
