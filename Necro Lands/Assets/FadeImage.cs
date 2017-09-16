using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeImage : MonoBehaviour {

    private float x;
    public string NextScene;
    private Color cl;
	// Use this for initialization
	void Awake ()
    {
        GetComponent<Image>().color = Color.clear;
        x = 0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (StoryState.sceneFinished)
        {
            x += 0.9f * Time.deltaTime;
            Debug.Log(x);
            GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, x);
          
        }
       
        isBlack();
    }

    public void isBlack()
    {
        if (x >= 1f)
        {
            Application.LoadLevel(NextScene);
        }
        
    }
}
