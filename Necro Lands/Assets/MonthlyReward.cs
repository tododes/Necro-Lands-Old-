using UnityEngine;
using System.Collections;

public class MonthlyReward : DailyReward 
{
    protected override void SetText()
    {
        TitleText.text = "WEEKLY REWARD\n" + (PlayerPrefs.GetInt("DAILYSTREAK") / 30) + "WEEK STREAK";
    }

    protected override void StreakReward()
    {
        if (PlayerPrefs.GetInt("DAILYSTREAK") == 30)
        {
            reward.money = 10000;
            reward.exp = 1000;
            reward.platinum = 30;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 60)
        {
            reward.money = 20000;
            reward.exp = 2000;
            reward.platinum = 40;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 90)
        {
            reward.money = 30000;
            reward.exp = 3000;
            reward.platinum = 50;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 120)
        {
            reward.money = 45000;
            reward.exp = 4500;
            reward.platinum = 65;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 150)
        {
            reward.money = 60000;
            reward.exp = 6000;
            reward.platinum = 80;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 180)
        {
            reward.money = 75000;
            reward.exp = 8000;
            reward.platinum = 100;
        }
    }
}
