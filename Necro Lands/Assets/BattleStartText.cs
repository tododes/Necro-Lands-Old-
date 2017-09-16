using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleStartText : MonoBehaviour 
{
    public GameObject playerCanvas;
    //public Canvas playerCanvas;
    private RectTransform myRect;
    private Image img;

    void Start()
    {
        myRect = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }
    void Update()
    {
        if (img.enabled != (myRect.position.x < 1000f))
            img.enabled = (myRect.position.x < 1000f);

        if (myRect.localPosition.x > -50f && myRect.localPosition.x < 20f)
        {
            myRect.Translate(Vector3.right * 70f * Time.deltaTime);
        }
        else
        {
            myRect.Translate(Vector3.right * 1000f * Time.deltaTime);
        }

        if (myRect.position.x >= 1000f && !GameManager.matchBegin)
        {
            GameManager.matchBegin = true;
            playerCanvas.SetActive(true);
            img.enabled = false;
        }
    }

}
