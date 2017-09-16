using UnityEngine;
using System.Collections;

public class TheAchievement : MonoBehaviour {

    public Sprite crossSprite, checkListSprite, blueSprite;
    void Start()
    {
       
        if (PlayerPrefs.GetInt(this.gameObject.name) == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = blueSprite;
            GetComponentInChildren<TextMesh>().text = "CLAIM\nREWARD!!";
        }
        else if (PlayerPrefs.GetInt(this.gameObject.name) == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = crossSprite;
            GetComponentInChildren<TextMesh>().text = "";
        }
        else if (PlayerPrefs.GetInt(this.gameObject.name) == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            GetComponentInChildren<TextMesh>().text = "";
        }
    }

    void OnMouseDown()
    {
        
        if (this.gameObject.name != "Canvas")
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == blueSprite)
            {
                GetComponent<AudioSource>().Play();
                PlayerPrefs.SetInt(this.gameObject.name, 2);
                giveReward();
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            }
        }
    }

    void giveReward()
    {
        if (this.gameObject.name == "1000ScoreAchieve")
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 2000);
        }
        else if (this.gameObject.name == "2000ScoreAchieve")
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 4000);
        }
        
    }

    void OnMouseEnter()
    {

    }

    void OnMouseExit()
    {

    }

    public void GoToGameMenu()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("MainScene");
    }
	
}
