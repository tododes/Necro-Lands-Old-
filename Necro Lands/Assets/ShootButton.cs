using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private static ShootButton instance;

    [SerializeField]
    private Image image;
    private float ColorBlacknessIndex;

    [SerializeField]
    public bool Pressed;
	
	void Awake () 
    {
        instance = this;
        image = GetComponentInChildren<Image>();
	}

    void Update()
    {
        ColorBlacknessIndex = (Pressed) ? 0.6f : 0f;
        image.color = Color.Lerp(Color.red, Color.black, ColorBlacknessIndex);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        Pressed = true;
    }

    public void OnPointerUp(PointerEventData ped)
    {
        Pressed = false;
    }

    public static ShootButton GetInstance()
    {
        return instance;
    }
}
