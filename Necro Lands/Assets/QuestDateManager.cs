using UnityEngine;
using System.Collections;
using System;

public class QuestDateManager : MonoBehaviour 
{
    private DateTime prevLoginTime;
    private DateTime currLoginTime;
    private TimeSpan totalTime;

    void Start()
    {
        if(!PlayerPrefs.HasKey("QUEST YEAR"))
        {
            prevLoginTime = DateTime.Now;
            //PlayerPrefs.SetInt("QUEST YEAR", DateTime.Now.Year);
            //PlayerPrefs.SetInt("QUEST MONTH", DateTime.Now.Month);
            //PlayerPrefs.SetInt("QUEST DAY", DateTime.Now.Day);
            //PlayerPrefs.SetInt("QUEST HOUR", DateTime.Now.Hour);
            //PlayerPrefs.SetInt("QUEST MINUTE", DateTime.Now.Minute);
            //PlayerPrefs.SetInt("QUEST SECOND", DateTime.Now.Second);
        }
        else
            prevLoginTime = new DateTime(PlayerPrefs.GetInt("QUEST YEAR"), PlayerPrefs.GetInt("QUEST MONTH"), PlayerPrefs.GetInt("QUEST DAY"), PlayerPrefs.GetInt("QUEST HOUR"), PlayerPrefs.GetInt("QUEST MINUTE"), PlayerPrefs.GetInt("QUEST SECOND"));
        
        currLoginTime = DateTime.Now;
        PlayerPrefs.SetInt("QUEST YEAR", DateTime.Now.Year);
        PlayerPrefs.SetInt("QUEST MONTH", DateTime.Now.Month);
        PlayerPrefs.SetInt("QUEST DAY", DateTime.Now.Day);
        PlayerPrefs.SetInt("QUEST HOUR", DateTime.Now.Hour);
        PlayerPrefs.SetInt("QUEST MINUTE", DateTime.Now.Minute);
        PlayerPrefs.SetInt("QUEST SECOND", DateTime.Now.Second);

        totalTime = currLoginTime.Subtract(prevLoginTime);
    }
    
}
