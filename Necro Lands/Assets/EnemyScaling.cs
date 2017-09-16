using UnityEngine;
using System.Collections;

public class EnemyScaling : MonoBehaviour {

    public static int scaleIndex;
    public static int WaveCount;

    void Start()
    {
        WaveCount = 1;
        scaleIndex = 0;
        ResetKill();
        
    }

    void ResetKill()
    {
        PlayerPrefs.SetInt("Kill", 0);
        PlayerPrefs.SetInt("TuyulTotalKill", 0);
        PlayerPrefs.SetInt("PocongTotalKill", 0);
        PlayerPrefs.SetInt("KuntiTotalKill", 0);
        PlayerPrefs.SetInt("BeguTotalKill", 0);
        PlayerPrefs.SetInt("LeakTotalKill", 0);
    }


}
