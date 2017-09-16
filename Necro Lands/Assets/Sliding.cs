using UnityEngine;
using System.Collections;

public class Sliding : MonoBehaviour {
    public GameObject[] ob;
    public float[] des;
	// Use this for initialization
	void Start () {
        ob = GameObject.FindGameObjectsWithTag("StartSlide");
        des = new float[ob.Length];
        /*if (Application.loadedLevelName == "trailer2" || Application.loadedLevelName == "trailer4")
        {
            for (int i = 0; i < ob.Length; i++)
            {
                ob[i].GetComponent<RectTransform>().position = new Vector3(ob[i].GetComponent<RectTransform>().position.x * -1, ob[i].GetComponent<RectTransform>().position.y, ob[i].GetComponent<RectTransform>().position.z);
            }
        }*/
        for (int i = 0; i < ob.Length; i++)
        {
            if (Application.loadedLevelName == "trailer2" || Application.loadedLevelName == "trailer4")
            {
                des[i] = ob[i].GetComponent<RectTransform>().position.x + 420f;
            }
            else
                des[i] = ob[i].GetComponent<RectTransform>().position.x - 420f;
        }

       
    }
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName == "trailer2" || Application.loadedLevelName == "trailer4")
        {
            for (int i = 0; i < ob.Length; i++)
            {
                if (ob[i].GetComponent<RectTransform>().position.x < des[i])
                {
                    ob[i].GetComponent<RectTransform>().Translate(Vector3.right * 420f * Time.deltaTime);
                }
                else
                {
                    TrailerAttribute.finishedSliding = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < ob.Length; i++)
            {
                if (ob[i].GetComponent<RectTransform>().position.x > des[i])
                {
                    ob[i].GetComponent<RectTransform>().Translate(Vector3.left * 420f * Time.deltaTime);
                }
                else
                {
                    TrailerAttribute.finishedSliding = true;
                }
            }
        }
       
	}
}
