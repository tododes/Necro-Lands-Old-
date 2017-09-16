using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static int kills, TuyulKill, GenderuwoKill, PocongKill, LeakKill, KuntilanakKill, RedKuntilanakKill;
    public static bool matchBegin;
    public static bool Lose;
    public static bool Win;
    public int totalKillsRequired;
    public GameObject[] characters;
    public GameObject realCharacter;

    public int goldReward;
    public int expReward;
    public int platinumReward;
    public string[] itemRewards;

    private Canvas pauseCanvas;
    void Awake()
    {
        kills = 0;
        matchBegin = false;

        for (int i = 0; i < characters.Length; i++)
        {
            if (PlayerPrefs.GetString("charname") == characters[i].name)
            {
                realCharacter = characters[i];
                
            }
            else 
            {
                characters[i].SetActive(false);
            }
        }
        realCharacter.tag = "Player";
        pauseCanvas = GameObject.Find("Pause Canvas").GetComponent<Canvas>();
        AddSceneFeature();
    }

    void AddSceneFeature()
    {
        if (Application.loadedLevelName.Contains("Defend"))
        {
            gameObject.AddComponent<DefendingFrenzy>();
            DefendingFrenzy defendingFrenzy = gameObject.GetComponent<DefendingFrenzy>();
            defendingFrenzy.min = 10;
            defendingFrenzy.sec = 0;
        }
        else if (!Application.loadedLevelName.Contains("Defend") && Application.loadedLevelName.Contains("Frenzy"))
        {
            gameObject.AddComponent<GhostFrenzy>();
            GhostFrenzy ghostFrenzy = gameObject.GetComponent<GhostFrenzy>();
            if(Application.loadedLevelName.Contains("Kunti"))
                ghostFrenzy.keyName = "Kunti";
            else if (Application.loadedLevelName.Contains("Pocong"))
                ghostFrenzy.keyName = "Pocong";
            else if (Application.loadedLevelName.Contains("Tuyul"))
                ghostFrenzy.keyName = "Tuyul";
            else if (Application.loadedLevelName.Contains("Leak"))
                ghostFrenzy.keyName = "Leak";
            else if (Application.loadedLevelName.Contains("Genderuwo"))
                ghostFrenzy.keyName = "Genderuwo";
            ghostFrenzy.min = 3;
            ghostFrenzy.sec = 0;
            ghostFrenzy.requiredKills = 40;
            ghostFrenzy.kills = 0;
        }
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) && !pauseCanvas.enabled)
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0f;
        }
    }

    public void UnPause()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1f;
    }
}
