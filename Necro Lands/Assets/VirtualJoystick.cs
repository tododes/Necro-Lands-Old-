using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image BgImg;
    private Image JoystickImg;
    private Vector2 OriginJoystickPos;
    private Vector3 InputVector;

    private static VirtualJoystick instance;

    public Vector3 GetInputVector()
    {
        return InputVector;
    }

    public Vector2 GetOriginPos()
    {
        return OriginJoystickPos;
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        InputVector = Vector3.zero;
        
        JoystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = pos.x / BgImg.rectTransform.sizeDelta.x;
            pos.y = pos.y/ BgImg.rectTransform.sizeDelta.y;
            InputVector = new Vector3(pos.x * 2, 0, pos.y * 2);
            InputVector = (InputVector.magnitude > 1f) ? InputVector.normalized : InputVector;

            JoystickImg.rectTransform.anchoredPosition = new Vector3((BgImg.rectTransform.sizeDelta.x/3) * InputVector.x, (BgImg.rectTransform.sizeDelta.y/3) * InputVector.z);
        }
    }
	// Use this for initialization
	void Awake () 
    {
        instance = this;
        BgImg = GetComponent<Image>();
        JoystickImg = transform.GetChild(0).GetComponent<Image>();
        OriginJoystickPos = Vector2.zero;
	}

    public static VirtualJoystick GetInstance()
    {
        return instance;
    }
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
