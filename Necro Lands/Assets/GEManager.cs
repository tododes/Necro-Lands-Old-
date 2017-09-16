using UnityEngine;
using System.Collections;
using Todo;

public class GEManager : MonoBehaviour {
    public static int index;
	// Use this for initialization
	void Start () {
        Camera.main.aspect = 1920f / 1080f;
        index = 1;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 1; i <= 5; i++)
        {
            if (i == index)
            {
                GameObject.Find("g" + i).GetComponent<SpriteRenderer>().enabled = true;
                Action.SetY(GameObject.Find("gg" + i).name, -2f);
            }
            else
            {
                GameObject.Find("g" + i).GetComponent<SpriteRenderer>().enabled = false;
                Action.SetY(GameObject.Find("gg" + i).name, 20f);
            }
        }
	}
}
