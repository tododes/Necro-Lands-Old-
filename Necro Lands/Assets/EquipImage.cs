using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class EquipImage : MonoBehaviour, IPointerClickHandler {

    private ItemEquipController itemEquipControl;
    private Image image;
    public int index;
    public GameObject[] itemsList;
    public bool Initiated;
    public GameObject UnEquipConfirmation;
	// Use this for initialization
	void Start () 
    {
        itemEquipControl = GameObject.FindGameObjectWithTag("MenuController").GetComponent<ItemEquipController>();
        image = GetComponent<Image>();
	}

    public void OnPointerClick(PointerEventData p)
    {
        if (PlayerPrefs.GetString("equip" + index) != "")
            UnEquipConfirmation.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () 
    {
      
        if (PlayerPrefs.GetString("equip" + index) == "" && GetComponent<Image>().color != Color.black)
        {
            GetComponent<Image>().color = Color.black;
            image.sprite = null;
        }
        if (PlayerPrefs.GetString("equip" + index) != "" && GetComponent<Image>().color != Color.white)
        {
            GetComponent<Image>().color = Color.white;

        }
                       
            if (!Initiated)
            {
                for (int i = 0; i < itemsList.Length; i++)
                {
                   
                    if (PlayerPrefs.GetString("equip" + index) == itemsList[i].name && PlayerPrefs.GetString("equip" + index) != "")
                    {
                        GetComponent<Image>().sprite = itemsList[i].GetComponent<SpriteRenderer>().sprite;
                        break;
                    }
                }
               
                Initiated = true;
            }
	}

    void LateUpdate()
    {
        if (!image.sprite)
        {
            PlayerPrefs.SetInt("equipqty" + index, -1);
        }

    }
}
