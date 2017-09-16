using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSkillDetail : MonoBehaviour {

    public Sprite[] sprites;
    private Image image;
	// Use this for initialization
	void Start () 
    {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (image.sprite != sprites[CharSelectManager.currIndex - 1])
        {
            image.sprite = sprites[CharSelectManager.currIndex - 1];
        }
	}
}
