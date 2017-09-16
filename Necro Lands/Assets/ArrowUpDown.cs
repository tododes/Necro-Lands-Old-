using UnityEngine;
using System.Collections;

public class ArrowUpDown : MonoBehaviour {

    private int state;
    private float x, oriPos;

	// Use this for initialization
	void Start () {
        state = 0;
        x = 0.2f;
        oriPos = GetComponent<RectTransform>().position.y;
	}
	
	// Update is called once per frame
	void Update () {
        x -= Time.deltaTime;
        if (x <= 0f)
        {
            if (state == 0)
            {
                state = 1;
            }
            else
            {
                state = 0;
            }
            x = 0.2f;
        }
        if (state == 0)
        {
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, oriPos, GetComponent<RectTransform>().position.z);
        }
        else
        {
            GetComponent<RectTransform>().position = new Vector3(GetComponent<RectTransform>().position.x, oriPos - 8f, GetComponent<RectTransform>().position.z);
        }
	}
}
