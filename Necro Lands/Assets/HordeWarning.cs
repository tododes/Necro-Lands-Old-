using UnityEngine;
using System.Collections;

public class HordeWarning : MonoBehaviour {

    private static HordeWarning instance;
    private RectTransform rect;
    private Vector3 incrementRate;
	// Use this for initialization
	void Awake () 
    {
        incrementRate = new Vector3(Time.deltaTime * 2f, Time.deltaTime * 2f, 0);
        rect = GetComponent<RectTransform>();
        instance = this;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public static HordeWarning GetHordeWarning()
    {
        return instance;
    }

    public void StartDisplayText()
    {
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText()
    {
        while(rect.localScale.x < 1f)
        {
            rect.localScale += incrementRate;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return new WaitForSeconds(3);
        while (rect.localScale.x > 0f)
        {
            rect.localScale -= incrementRate;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return null;
    }
}
