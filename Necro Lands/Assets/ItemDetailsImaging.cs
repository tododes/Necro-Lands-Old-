using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDetailsImaging : MonoBehaviour {

    public Sprite[] sprites;
    public static int itemIndex;

    void Start()
    {
        itemIndex = 0;
        GameObject.Find("ItemDetails").GetComponent<Image>().enabled = false;
    }

    void Update()
    {
       
        GameObject.Find("ItemDetails").GetComponent<Image>().sprite = sprites[itemIndex];
    }

   
}
