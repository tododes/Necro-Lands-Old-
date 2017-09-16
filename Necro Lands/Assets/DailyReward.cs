using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public struct Reward
{
    public int money;
    public int exp;
    public int platinum;
}

public class DailyReward : MonoBehaviour 
{
    public Reward reward = new Reward();

    public DateTime prevDate;
    public DateTime now;
    public TimeSpan totalTime;
    public bool isOneStreak;
    public bool isAvailable;
    public RectTransform rect;
    public Text TitleText;
    public int StreakDays;

    protected Image myImage;

    protected void Start()
    {
        myImage = GetComponent<Image>();
        if (!PlayerPrefs.HasKey("YEAR"))
        {
            prevDate = DateTime.Now;
            PlayerPrefs.SetInt("YEAR", DateTime.Now.Year);
            PlayerPrefs.SetInt("MONTH", DateTime.Now.Month);
            PlayerPrefs.SetInt("DAY", DateTime.Now.Day);
            PlayerPrefs.SetInt("HOUR", DateTime.Now.Hour);
            PlayerPrefs.SetInt("MINUTE", DateTime.Now.Minute);
            PlayerPrefs.SetInt("SECOND", DateTime.Now.Second);
        }
        prevDate = new DateTime(PlayerPrefs.GetInt("YEAR"), PlayerPrefs.GetInt("MONTH"), PlayerPrefs.GetInt("DAY"), PlayerPrefs.GetInt("HOUR"), PlayerPrefs.GetInt("MINUTE"), PlayerPrefs.GetInt("SECOND"));
        now = DateTime.Now;
        totalTime = now.Subtract(prevDate);
        if (!PlayerPrefs.HasKey("FIRST REWARD"))
            PlayerPrefs.SetInt("FIRST REWARD", 0);

        isAvailable = (PlayerPrefs.GetInt("FIRST REWARD") == 0);
        
        if (!PlayerPrefs.HasKey("DAILYSTREAK"))
            PlayerPrefs.SetInt("DAILYSTREAK", 0);
        if (totalTime.TotalDays >= StreakDays + 1)
        {
            isOneStreak = true;
        }
        else if (totalTime.TotalDays >= StreakDays)
        {
            isOneStreak = true;
            PlayerPrefs.SetInt("DAILYSTREAK", PlayerPrefs.GetInt("DAILYSTREAK") + 1);
        }

        StreakReward();
    }

    protected virtual void StreakReward()
    {
       
        if (PlayerPrefs.GetInt("DAILYSTREAK") == 0)
        {
            reward.money = 300;
            reward.exp = 0;
            reward.platinum = 0;
        }
        else if(PlayerPrefs.GetInt("DAILYSTREAK") == 1)
        {
            reward.money = 600;
            reward.exp = 100;
            reward.platinum = 0;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 2)
        {
            reward.money = 1000;
            reward.exp = 200;
            reward.platinum = 0;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 3)
        {
            reward.money = 1500;
            reward.exp = 300;
            reward.platinum = 3;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 4)
        {
            reward.money = 2000;
            reward.exp = 400;
            reward.platinum = 5;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") >= 5)
        {
            reward.money = 2500;
            reward.exp = 500;
            reward.platinum = 10;
        }
    }

    public void SetReward()
    {
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + reward.money);
        PlayerPrefs.SetInt("EXP", PlayerPrefs.GetInt("EXP") + reward.exp);
        PlayerPrefs.SetInt("platinum", PlayerPrefs.GetInt("platinum") + reward.platinum);
        isOneStreak = false;
        isAvailable = false;
    }

    protected virtual void SetText()
    {
        TitleText.text = "DAILY REWARD\n" + PlayerPrefs.GetInt("DAILYSTREAK") + "DAY STREAK";
    }

    protected void Update()
    {
        SetText();
        if (isOneStreak || isAvailable)
        {
            if (rect.localScale.x < 4f)
            {
                rect.localScale = new Vector3(rect.localScale.x + 6f * Time.deltaTime, rect.localScale.y + 6f * Time.deltaTime, rect.localScale.z);
            }
        }
        else
        {
            if (rect.localScale.x > 0f)
            {
                rect.localScale = new Vector3(rect.localScale.x - 6f * Time.deltaTime, rect.localScale.y - 6f * Time.deltaTime, rect.localScale.z);
            }
        }

        if (rect.localScale.x <= 0f && myImage.enabled)
        {
            myImage.enabled = false;
        }
        else if (rect.localScale.x > 0f && !myImage.enabled)
        {
            myImage.enabled = true;
        }
    }

}
