using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	private Color originColor;

	void Awake()
	{
        if (GetComponent<Image>() != null)
            originColor = GetComponent<Image>().color;
        else if (GetComponent<SpriteRenderer>() != null)
            originColor = GetComponent<SpriteRenderer>().color;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<AudioSource>().Play();
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        if (GetComponent<Image>() != null)
		    GetComponent<Image> ().color = Color.red;
        else if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = Color.red;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
        if (GetComponent<Image>() != null)
            GetComponent<Image>().color = originColor;
        else if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().color = originColor;
	}

   
}
