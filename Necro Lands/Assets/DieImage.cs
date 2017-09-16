using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DieImage : MonoBehaviour {

   
    private Player player;
    private Image die;
    public Canvas playerCanvas;
    private RectTransform myRect;

    public string SceneScaleSaveKey;

    public void SaveData(string x)
    {
        player.SaveData();
        PlayerPrefs.SetInt("Level", player.level);
        PlayerPrefs.SetInt("Exp", player.xp);
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
	// Use this for initialization
	void Start () 
    {
        die = GetComponent<Image>();
        myRect = GetComponent<RectTransform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
	}
	
	// Update is called once per frame
	void Update () 
    {
     
        if (playerCanvas.enabled != (!die.enabled))
            playerCanvas.enabled = (!die.enabled);

        if (die.enabled != (player.HP <= 0 || GameManager.Lose))
            die.enabled = (player.HP <= 0 || GameManager.Lose);

        if(die.enabled && myRect.localScale.x < 3f)
        {
            myRect.localScale = new Vector3(myRect.localScale.x + 6f * Time.deltaTime, myRect.localScale.y + 6f * Time.deltaTime, myRect.localScale.z);
        }
        else if (!die.enabled && myRect.localScale.x > 0f)
        {
            myRect.localScale = new Vector3(0f, 0f, myRect.localScale.z);
        }
	}
}
