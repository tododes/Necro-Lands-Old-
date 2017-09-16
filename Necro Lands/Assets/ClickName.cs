using UnityEngine;
using System.Collections;

public class ClickName : MonoBehaviour {

    void OnMouseDown()
    {
        if (gameObject.name == checkName.nm)
        {
            PlayerPrefs.SetInt("s", PlayerPrefs.GetInt("s") + 10);
        }
       else 
        {
            PlayerPrefs.SetInt("s", PlayerPrefs.GetInt("s") - 5);
        }
        Application.LoadLevel("quiz");
    }
}
