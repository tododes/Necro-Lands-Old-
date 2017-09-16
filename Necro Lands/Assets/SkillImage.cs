using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class SkillImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {

    public Sprite[] sprites;
    public Sprite[] spriteDetails;
    public GameObject[] characters;
    public Image myDetail;
    private int index;
	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if (PlayerPrefs.GetString("charname") == characters[i].name)
            {
                index = i;
                break;
            }
        }
       
        GetComponent<Image>().sprite = sprites[index];

       
        myDetail.enabled = false;
       
	}

   
    public void OnPointerDown(PointerEventData p)
    {
        if(gameObject.name.Contains("Active"))
        {
            if (PlayerPrefs.GetString("charname") == "Grant")
                GameObject.FindGameObjectWithTag("Player").GetComponent<GrantActiveSkill>().Skilling();
            else if (PlayerPrefs.GetString("charname") == "Lucy")
                GameObject.FindGameObjectWithTag("Player").GetComponent<LucyActiveSkill>().Skilling();
            else if (PlayerPrefs.GetString("charname") == "Marcia")
                GameObject.FindGameObjectWithTag("Player").GetComponent<MarciaActiveSkill>().Skilling();
            else if (PlayerPrefs.GetString("charname") == "Trevor")
                GameObject.FindGameObjectWithTag("Player").GetComponent<TrevorActiveSkill>().Skilling();
        }
    }

    public void OnPointerEnter(PointerEventData p)
    {
        myDetail.enabled = true;
        myDetail.sprite = spriteDetails[index];
    }

    public void OnPointerExit(PointerEventData p)
    {
        myDetail.enabled = false;
    }
}
