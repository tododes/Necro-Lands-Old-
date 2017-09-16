using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkName : MonoBehaviour {

    string[] name = {"Cube","Cylinder","Sphere","Capsule","Tree"};
    public static string nm;
    int r;
	// Use this for initialization
	void Start ()
    {
        if (!PlayerPrefs.HasKey("s") || PlayerPrefs.GetInt("s") == 0)
            PlayerPrefs.SetInt("s", 5);
        r = Random.Range(0, name.Length);
        GameObject.Find("ShapeText").GetComponent<Text>().text = name[r];
        nm = name[r];
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (PlayerPrefs.GetInt("s") <= 0)
            Application.LoadLevel("GO");

        GameObject.Find("ScoreText").GetComponent<Text>().text = "SCORE : " + PlayerPrefs.GetInt("s");
	}
}
