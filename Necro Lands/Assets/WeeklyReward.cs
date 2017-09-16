using UnityEngine;
using System.Collections;

public class WeeklyReward : DailyReward {

    protected override void SetText()
    {
        TitleText.text = "WEEKLY REWARD\n" + (PlayerPrefs.GetInt("DAILYSTREAK") / 7) + "WEEK STREAK";
    }

    protected override void StreakReward()
    {
        if (PlayerPrefs.GetInt("DAILYSTREAK") == 7)
        {
            reward.money = 3000;
            reward.exp = 0;
            reward.platinum = 5;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 14)
        {
            reward.money = 5000;
            reward.exp = 500;
            reward.platinum = 10;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 21)
        {
            reward.money = 7000;
            reward.exp = 700;
            reward.platinum = 15;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 28)
        {
            reward.money = 10000;
            reward.exp = 1000;
            reward.platinum = 25;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 35)
        {
            reward.money = 13000;
            reward.exp = 1400;
            reward.platinum = 35;
        }
        else if (PlayerPrefs.GetInt("DAILYSTREAK") == 42)
        {
            reward.money = 17000;
            reward.exp = 1800;
            reward.platinum = 50;
        }
    }
}
