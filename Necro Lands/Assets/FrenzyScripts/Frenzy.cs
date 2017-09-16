using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Frenzy : MonoBehaviour
{
    int minute;
    float second, minisecond;
    private GameObject timerText;
    
    //private Status playerStatus;
    // Use this for initialization
    void Start()
    {
        minute = 2;
        second = 0f;
        minisecond = 1f;
        timerText = GameObject.Find("TimerText");
        //playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<Status>();
    }

    void Update()
    {
     
       if (StartupManager.isStarted)
            minisecond -= Time.deltaTime;
        decreaseMinute();
        decreaseSecond();
        winCondition();
        if(second < 10)
            timerText.GetComponent<Text>().text = minute + " : 0" + second;
        else
            timerText.GetComponent<Text>().text = minute + " : " + second;
        KillTextDisplay();
        loseCondition();
    }
    void decreaseSecond()
    {
        if (minisecond <= 0f)
        {
            second--;
            minisecond = 1f;
        }
    }

    void KillTextDisplay()
    {
        switch (Application.loadedLevelName)
        {
            case "Main Game - Kuntilanak Frenzy":
                GameObject.Find("KillText").GetComponent<Text>().text = "Kuntilanaks killed : " + PlayerPrefs.GetInt("KuntiTotalKill")+"/40";
                break;
            case "Main Game - Begu Frenzy":
                GameObject.Find("KillText").GetComponent<Text>().text = "Begu Ganjangs killed : " + PlayerPrefs.GetInt("BeguTotalKill") + "/40";
                break;
            case "Main Game - Tuyul Frenzy":
                GameObject.Find("KillText").GetComponent<Text>().text = "Tuyuls killed : " + PlayerPrefs.GetInt("TuyulTotalKill") + "/40";
                break;
            case "Main Game - Pocong Frenzy":
                GameObject.Find("KillText").GetComponent<Text>().text = "Pocongs killed : " + PlayerPrefs.GetInt("PocongTotalKill") + "/40";
                break;
            case "Main Game - Leak Frenzy":
                GameObject.Find("KillText").GetComponent<Text>().text = "Leaks killed : " + PlayerPrefs.GetInt("LeakTotalKill") + "/40";
                break;
           
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

    void winCondition()
    {
        if (Application.loadedLevelName == "Main Game - Kuntilanak Hunt")
        {
            if (PlayerPrefs.GetInt("KuntiTotalKill") >= 40)
            {
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 200);
                if (!PlayerPrefs.HasKey("Kunti Frenzy"))
                {
                    PlayerPrefs.SetInt("Kunti Frenzy", 0);
                }
                PlayerPrefs.SetInt("Kunti Frenzy", PlayerPrefs.GetInt("Kunti Frenzy") + 1);
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 250);
                StartupManager.isStarted = false;
                StartupManager.isFinished = true;
                StartupManager.win = true;
            }
        }
        else if (Application.loadedLevelName == "Main Game - Leak Hunt")
        {
            if (PlayerPrefs.GetInt("LeakTotalKill") >= 40)
            {
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 200);
                if (!PlayerPrefs.HasKey("Leak Frenzy"))
                {
                    PlayerPrefs.SetInt("Leak Frenzy", 0);
                }
                PlayerPrefs.SetInt("Leak Frenzy", PlayerPrefs.GetInt("Leak Frenzy") + 1);
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 250);
                StartupManager.isStarted = false;
                StartupManager.isFinished = true;
                StartupManager.win = true;
            }
        }
        else if (Application.loadedLevelName == "Main Game - Pocong Hunt")
        {
            if (PlayerPrefs.GetInt("PocongTotalKill") >= 40)
            {
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 200);
                if (!PlayerPrefs.HasKey("Pocong Frenzy"))
                {
                    PlayerPrefs.SetInt("Pocong Frenzy", 0);
                }
                PlayerPrefs.SetInt("Pocong Frenzy", PlayerPrefs.GetInt("Pocong Frenzy") + 1);
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 250);
                StartupManager.isStarted = false;
                StartupManager.isFinished = true;
                StartupManager.win = true;
            }
        }
        else if (Application.loadedLevelName == "Main Game - Tuyul Hunt")
        {
            if (PlayerPrefs.GetInt("TuyulTotalKill") >= 40)
            {
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 200);
                if (!PlayerPrefs.HasKey("Tuyul Frenzy"))
                {
                    PlayerPrefs.SetInt("Tuyul Frenzy", 0);
                }
                PlayerPrefs.SetInt("Tuyul Frenzy", PlayerPrefs.GetInt("Tuyul Frenzy") + 1);
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 250);
                StartupManager.isStarted = false;
                StartupManager.isFinished = true;
                StartupManager.win = true;
            }
        }
        else if (Application.loadedLevelName == "Main Game - Begu Hunt")
        {
            if (PlayerPrefs.GetInt("BeguTotalKill") >= 40)
            {
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 200);
                if (!PlayerPrefs.HasKey("Begu Frenzy"))
                {
                    PlayerPrefs.SetInt("Begu Frenzy", 0);
                }
                PlayerPrefs.SetInt("Begu Frenzy", PlayerPrefs.GetInt("Begu Frenzy") + 1);
                PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + 250);
                StartupManager.isStarted = false;
                StartupManager.isFinished = true;
                StartupManager.win = true;
            }
        }
        
    }

    void loseCondition()
    {
        if ((second <= 0f && minute <= 0f))
        {
            StartupManager.isStarted = false;
            StartupManager.isFinished = true;
            StartupManager.lose = true;
        }
    }


}
