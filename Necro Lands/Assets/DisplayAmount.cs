using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayAmount : MonoBehaviour {
    public string item;
    public int index;

    public int ItemAmount;
  
	// Use this for initialization
	void Start ()
    {
        index = -1;
        for (int i = 1; i <= 50; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == item)
            {
                index = i;
                break;
            }
        }
        for (int i = 1; i <= 8; i++)
        {
            Debug.Log(i + " " + PlayerPrefs.GetInt("equipqty" + i));
        }
        GetComponent<Text>().text = "x "+ PlayerPrefs.GetInt("item" + index + "qty");
        ItemAmount = PlayerPrefs.GetInt("item" + index + "qty");
        //Debug.Log(item + " : " + PlayerPrefs.GetInt("item" + index + "qty"));
        if (PlayerPrefs.GetInt("item" + index + "qty") <= 0)
            GetComponentInParent<Button>().enabled = false;
        else
            GetComponentInParent<Button>().enabled = true;
        /*for (int i = 1; i <= 50; i++)
        {
            Debug.Log(PlayerPrefs.GetString("item" + i));
        }*/

        //for (int i = 1; i <= 8; i++)
        //{
        //    PlayerPrefs.SetInt("equipqty" + i, -1);
        //}
    }

  

    public void SetAmount()
    {
        for (int i = 1; i <= 8; i++)
        {
            Debug.Log(i+") "+PlayerPrefs.GetInt("equipqty" + i));
            if (PlayerPrefs.GetInt("equipqty" + i) <= -1)
            {
                PlayerPrefs.SetInt("equipqty" + i, ItemAmount);
                break;
            }
        }
        for (int i = 1; i <= 8; i++)
        {
            Debug.Log(i + " " + PlayerPrefs.GetInt("equipqty" + i));
        }
    }
  
}
