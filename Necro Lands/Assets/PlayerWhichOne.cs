using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerWhichOne : MonoBehaviour {
    public GameObject[] playerList, Fill;
    private Color[] playerColor = {Color.green,Color.red,Color.yellow,Color.magenta};

    // Use this for initialization
    void Awake()
    {
        Fill = GameObject.FindGameObjectsWithTag("Fill");
        //int idx = -1;
        for (int i = 0; i < playerList.Length; i++)
        {
            if (playerList[i].name == PlayerPrefs.GetString("charname"))
            {
                playerList[i].tag = "Player";
                for (int j = 0; j < Fill.Length; j++)
                {
                    Fill[j].GetComponent<Image>().color = playerColor[i];
                }
            }
            else if (playerList[i].name != PlayerPrefs.GetString("charname"))
            {
                playerList[i].tag = "NoPlayer";
                playerList[i].SetActive(false);
            }
        }

	}
	
	
}
