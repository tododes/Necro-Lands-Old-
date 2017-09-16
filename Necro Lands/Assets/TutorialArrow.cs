using UnityEngine;
using System.Collections;

public class TutorialArrow : MonoBehaviour 
{
    private RectTransform rect;
    private bool Navigated;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        Navigated = false;
    }

    void Update()
    {
        if (!Navigated)
        {
            StartCoroutine(UpAndDown());
            Navigated = true;
        }
    }

    void OnDisable()
    {
        Navigated = false;
    }

    void OnEnable()
    {
        //StartCoroutine(UpAndDown());
        if (Navigated)
            Navigated = false;
    }

    IEnumerator UpAndDown()
    {
        while(true)
        {
           
            if(rect.localPosition.y == -40f)
                rect.localPosition = new Vector3(rect.localPosition.x, -47f, rect.localPosition.z);
            else if (rect.localPosition.y == -47f)
                rect.localPosition = new Vector3(rect.localPosition.x, -40f, rect.localPosition.z);
           
            yield return new WaitForSeconds(0.15f);
        }
    }
	
}
