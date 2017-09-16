using UnityEngine;
using System.Collections;

public class AreYouSurePanel : MonoBehaviour {

    private static AreYouSurePanel instance;
    [SerializeField]
    private Vector3 originalScale;

    void Awake()
    {
        instance = this;
    }
	// Use this for initialization
	void Start () 
    {
        originalScale = new Vector3(GetComponent<RectTransform>().localScale.x, GetComponent<RectTransform>().localScale.y, 0);
        transform.localScale = Vector3.zero;
	}

    public void Display()
    {
        transform.localScale = originalScale;
    }

    public void UnDisplay()
    {
        transform.localScale = Vector3.zero;
    }

    public void No()
    {
        UnDisplay();
    }

    public static AreYouSurePanel GetInstance()
    {
        return instance;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
