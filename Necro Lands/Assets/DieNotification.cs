using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DieNotification : MonoBehaviour {

    public Text text_1,text_2,score, highScore, highScoreNotif;
    // Use this for initialization
    void Start ()
    {
        CheckHighScore();
	}
	
	// Update is called once per frame
	void Update () {
        if (StartupManager.isFinished && StartupManager.win)
        {
            text_1.text = "MISSION";
            text_2.text = "ACCOMPLISHED";
            text_1.color = Color.green;
            text_2.color = Color.green;
            InitializeText();
        }
        else if (StartupManager.isFinished && StartupManager.lose)
        {
            text_1.text = "MISSION";
            text_2.text = "FAILED";
            text_1.color = Color.red;
            text_2.color = Color.red;
            InitializeText();
        }
        else if (StartupManager.isFinished)
        {
            text_1.text = "YOU";
            text_2.text = "DIED";
            text_1.color = Color.red;
            text_2.color = Color.red;
            InitializeText();
        }
       
	}

    void InitializeText()
    {
            score.text = "YOUR SCORE : " + PlayerPrefs.GetInt("score");
            highScore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("High");
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("High"))
            {
                highScoreNotif.text = "NEW HIGH SCORE : " + PlayerPrefs.GetInt("score");

            }
            else
            {
                highScoreNotif.text = "";
            }

            if (this.name.Contains("Text"))
            {
                if (GetComponent<RectTransform>().localScale.x < 0.5f)
                {
                    GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x + 4*Time.deltaTime, GetComponent<RectTransform>().localScale.y + 4*Time.deltaTime, GetComponent<RectTransform>().localScale.z);
                }
            }
            else
            {
                if (GetComponent<RectTransform>().localScale.x < 2.2f)
                {
                    GetComponent<RectTransform>().localScale = new Vector3(GetComponent<RectTransform>().localScale.x + 4 * Time.deltaTime, GetComponent<RectTransform>().localScale.y + 4 * Time.deltaTime, GetComponent<RectTransform>().localScale.z);
                }
            }


        }
    

    void CheckHighScore()
    {
        if (Application.loadedLevelName.Contains("Mega"))
        {
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("MegaBossHigh"))
            {
                PlayerPrefs.SetInt("MegaBossHigh", PlayerPrefs.GetInt("score"));
            }
        }
        else if (Application.loadedLevelName.Contains("Boss"))
        {
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("BossHigh"))
            {
                PlayerPrefs.SetInt("BossHigh", PlayerPrefs.GetInt("score"));
            }
        }
        else
        {
            if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("High"))
            {
               
                PlayerPrefs.SetInt("High", PlayerPrefs.GetInt("score"));
            }
        }

    }
}
