using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinImage : MonoBehaviour {

    public GameManager manager;
    private Player myPlayer;
    private PlayerMove move;
    private RectTransform myRect;
    private Image win;
    public Canvas playerCanvas;

    public string SceneScaleSaveKey;
   // private GameObject myObject;
    public void SaveData(string x)
    {
        myPlayer.SaveData();
        PlayerPrefs.SetInt("Level", myPlayer.level);
        PlayerPrefs.SetInt("Exp", myPlayer.xp);
        if (Application.loadedLevelName.Contains("Mega"))
            SceneScaleSaveKey = "Mega Boss Scale Record";
        else if (Application.loadedLevelName.Contains("Boss"))
            SceneScaleSaveKey = "Boss Scale Record";
        else
            SceneScaleSaveKey = "Scale Record";
        if (x == "")
        {
            PlayerPrefs.SetInt(SceneScaleSaveKey, SpawnEnemy.spawnScale);
        }
        else
        {
            PlayerPrefs.SetInt(SceneScaleSaveKey, 0);
        }
    }

	void Start () 
    {
        /*if (!PlayerPrefs.HasKey(Application.loadedLevelName + "Level"))
            PlayerPrefs.SetInt(Application.loadedLevelName + "Level", 1);*/
        myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        myRect = GetComponent<RectTransform>();
        win = GetComponent<Image>();
       
	}

	void Update () 
    {
        if (playerCanvas.enabled != (!win.enabled))
            playerCanvas.enabled = (!win.enabled);

        if (win.enabled != (GameManager.kills >= manager.totalKillsRequired || GameManager.Win))
        {
            win.enabled = (GameManager.kills >= manager.totalKillsRequired || GameManager.Win);
            move.isNavigable = !win.enabled;
        }
            

        if (win.enabled && myRect.localScale.x < 3f)
        {
            myRect.localScale = new Vector3(myRect.localScale.x + 6f * Time.deltaTime, myRect.localScale.y + 6f * Time.deltaTime, myRect.localScale.z);
        }
        if (!win.enabled && myRect.localScale.x > 0f)
        {
            myRect.localScale = new Vector3(0f, 0f, myRect.localScale.z);
        }
	}

    public void GiveReward()
    {
        int emptySlot = GetEmptySlotInItem();
        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + manager.goldReward * PlayerPrefs.GetInt(Application.loadedLevelName+"Level"));
        PlayerPrefs.SetInt("EXP", PlayerPrefs.GetInt("EXP") + manager.expReward * PlayerPrefs.GetInt(Application.loadedLevelName + "Level"));
        PlayerPrefs.SetInt("platinum", PlayerPrefs.GetInt("platinum") + manager.platinumReward * PlayerPrefs.GetInt(Application.loadedLevelName + "Level"));
        if (manager.itemRewards.Length > 0)
        {
            for (int i = emptySlot; i < emptySlot + manager.itemRewards.Length; i++)
            {
                PlayerPrefs.SetString("item"+i, manager.itemRewards[i]);
            }
        }
        if (Application.loadedLevelName.Contains("Defend") || Application.loadedLevelName.Contains("Frenzy"))
        {
            PlayerPrefs.SetInt(Application.loadedLevelName + "Level", PlayerPrefs.GetInt(Application.loadedLevelName + "Level") + 1);
        }
       
    }

    int GetEmptySlotInItem()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (PlayerPrefs.GetString("item" + i) == "")
            {
                return i;
            }
        }
        return -1;
    }
}
