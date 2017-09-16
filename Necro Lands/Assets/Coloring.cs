using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coloring : MonoBehaviour {

    public float x = 0f;
	// Use this for initialization
	void Start () {
        GetComponent<Image>().color = Color.black;

    }
	
	// Update is called once per frame
	void Update () {
        if(x < 1f)
            x += 0.25f * Time.deltaTime;
        GetComponent<Image>().color = Color.Lerp(Color.black, Color.clear, x);
	}
}
