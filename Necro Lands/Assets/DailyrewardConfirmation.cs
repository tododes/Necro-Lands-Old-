using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DailyrewardConfirmation : MonoBehaviour {

    private Image parentImage;

    void Start()
    {
        parentImage = GetComponentInParent<Image>();
    }

    
    public void RewardConfirmation()
    {
        GetComponent<AudioSource>().Play();
        //AdsManager.singleton.ShowAd();
        PlayerPrefs.SetInt("FIRST REWARD", 1);
        System.DateTime buttonPressTime = System.DateTime.Now;
        PlayerPrefs.SetInt("YEAR", buttonPressTime.Year);
        PlayerPrefs.SetInt("MONTH", buttonPressTime.Month);
        PlayerPrefs.SetInt("DAY", buttonPressTime.Day);
        PlayerPrefs.SetInt("HOUR", buttonPressTime.Hour);
        PlayerPrefs.SetInt("MINUTE", buttonPressTime.Minute);
        PlayerPrefs.SetInt("SECOND", buttonPressTime.Second);
        
        //GetComponentInParent<DailyReward>().isOneDay = false;
    }
	
}
