using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharSelectManager : MonoBehaviour {
    public static int currIndex;
    public Sprite[] sprite, DetailSprite;
    string[] nama = { "Grant", "Trevor", "Marcia", "Lucy" };
    string[] namaSkill = { "Gentleman Spirit", "Fatal Shot", "Cheerful Blow", "Hypnocharm" };
    Color[] textCol = { Color.green, Color.red, Color.yellow, Color.magenta};
	// Use this for initialization
	void Start () {
        currIndex = 1;
        Camera.main.aspect = 1920f / 1080f;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("CharacterName").GetComponent<TextMesh>().text = nama[currIndex - 1];
        GameObject.Find("CharacterName").GetComponent<TextMesh>().color = textCol[currIndex - 1];
        /*GameObject.Find("Image (1)").GetComponent<Image>().sprite = sprite[currIndex - 1];
        GameObject.Find("Image (2)").GetComponent<Image>().sprite = DetailSprite[currIndex - 1];
        GameObject.Find("Text (1)").GetComponent<Text>().text = namaSkill[currIndex - 1];
        GameObject.Find("Text (1)").GetComponent<Text>().color = textCol[currIndex - 1];*/
    }
}
