using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemDetailsController : MonoBehaviour {

    public void setIndex(int x)
    {
        GetComponent<AudioSource>().Play();
        ItemDetailsImaging.itemIndex = x;
        GameObject.Find("ItemDetails").GetComponent<Image>().enabled = true;
    }
}
