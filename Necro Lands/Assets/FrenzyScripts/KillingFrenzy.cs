using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillingFrenzy : MonoBehaviour {
    int minute;
    float second, minisecond;
    

    void Start()
    {
        minute = 5;
        second = 0f;
        minisecond = 1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(StartupManager.isStarted)
        minisecond -= Time.deltaTime;
        decreaseMinute();
        decreaseSecond();
        winLoseCondition();
        TextDisplay();
        if (second < 10)
        {
            GameObject.Find("TimerText").GetComponent<Text>().text = minute + " : 0" + second;
        }
        else
            GameObject.Find("TimerText").GetComponent<Text>().text = minute + " : " + second;
    }

    void TextDisplay()
    {
        GameObject.Find("KillText").GetComponent<Text>().text = "Enemies killed : "+PlayerPrefs.GetInt("Kill")+"/120";
    }

    void decreaseSecond()
    {
        if (minisecond <= 0f)
        {
            second--;
            minisecond = 1f;
        }
    }
    void decreaseMinute()
    {

        if (second < 0f && minute >= 0)
        {
            minute--;
            second = 59f;
        }
    }

    void winLoseCondition()
    {
        if (PlayerPrefs.GetInt("Kill") >= 120)
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 300);
            if (!PlayerPrefs.HasKey("Killing Frenzy"))
            {
                PlayerPrefs.SetInt("Killing Frenzy", 0);
            }
            PlayerPrefs.SetInt("Killing Frenzy", PlayerPrefs.GetInt("Killing Frenzy") + 1);
            StartupManager.isStarted = false;
            StartupManager.isFinished = true;
            StartupManager.win = true;
        }
        else if (minute <= 0 && second <= 0 && PlayerPrefs.GetInt("Kill") < 120)
        {
          
            StartupManager.isStarted = false;
            StartupManager.isFinished = true;
            StartupManager.lose = true;
        }
    }
}
