using UnityEngine;
using System.Collections;
using System;

public class TimeManager : MonoBehaviour {

    private static TimeManager instance;

    public bool Morning, Noon, Afternoon, Night;

    private DateTime CurrTime;
    private DateTime BeginTime;
	// Use this for initialization
	void Awake () 
    {
        instance = this;
        BeginTime = DateTime.Now;
    }

    public DateTime GetNow()
    {
        return CurrTime;
    }

    public double GetDurationSeconds()
    {
        TimeSpan t = CurrTime.Subtract(BeginTime);
        return t.TotalSeconds;
    }
	
    void Update()
    {
        CurrTime = DateTime.Now;

        Morning = (CurrTime.Hour >= 5 && CurrTime.Hour <= 10);
        Noon = (CurrTime.Hour >= 11 && CurrTime.Hour <= 15);
        Afternoon = (CurrTime.Hour >= 16 && CurrTime.Hour <= 18);
        Night = (CurrTime.Hour >= 19 && CurrTime.Hour <= 24) || (CurrTime.Hour >= 1 && CurrTime.Hour <= 4);
	}

    public static TimeManager GetInstance()
    {
        return instance;
    }
}
