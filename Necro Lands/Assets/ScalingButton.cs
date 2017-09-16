using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScalingButton : MonoBehaviour {

    private Color originColor;
    public Fading fade;
    public EndlessLevelButton e;

    void Start()
    {
        originColor = Color.blue;
    }

    void OnMouseEnter()
    {
        if (GetComponent<Image>() != null)
            GetComponent<Image>().color = Color.red;
        else if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseExit()
    {
        if (GetComponent<Image>() != null)
            GetComponent<Image>().color = originColor;
        else if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = originColor;
    }

    void OnMouseDown()
    {
        GetComponent<AudioSource>().Play();
        if(gameObject.name.Contains("Continue"))
            PlayerPrefs.SetInt(e.RecordKey, e.StartingLevel);
        else if (gameObject.name.Contains("Start"))
            PlayerPrefs.SetInt(e.RecordKey, 0);
        fade.Finish(e.name);
    }
}
