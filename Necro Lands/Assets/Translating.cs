using UnityEngine;
using System.Collections;

public class Translating : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Achievement Button" || gameObject.name == "Back Button")
        {
            if (GetComponent<RectTransform>().localPosition.y < -76f)
                GetComponent<RectTransform>().Translate(Vector3.up * 700f * Time.deltaTime);
          
        }
        else if(gameObject.name == "Play Button" || gameObject.name == "Shop Button" || gameObject.name == "SkillTree Button")
        {
            if (GetComponent<RectTransform>().localPosition.y > 73f)
                GetComponent<RectTransform>().Translate(Vector3.down * 560f * Time.deltaTime);
        }
       

    }
}
