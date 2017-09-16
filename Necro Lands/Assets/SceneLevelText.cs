using UnityEngine;
using System.Collections;

public class SceneLevelText : MonoBehaviour {

    private TextMesh myText;
    private ModeButton myMode;
    public int index;
	// Use this for initialization
	void Start () 
    {
      
        myText = GetComponent<TextMesh>();
        myMode = transform.parent.gameObject.GetComponentInChildren<ModeButton>();
        index = myMode.index;
        if (!PlayerPrefs.HasKey(myMode.getSceneName(index)+"Level"))
            PlayerPrefs.SetInt(myMode.getSceneName(index)+"Level", 1);
        myText.text = "LEVEL " + PlayerPrefs.GetInt(myMode.getSceneName(index)+"Level");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
