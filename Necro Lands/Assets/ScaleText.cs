using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScaleText : MonoBehaviour {

    private Text myText;

    private GameObject managerObject;
    // Use this for initialization
    void Start()
    {
        myText = GetComponent<Text>();
        managerObject = GameObject.FindGameObjectWithTag("Game Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName.Contains("Frenzy") && !Application.loadedLevelName.Contains("Defend"))
        {
             GhostFrenzy ghost = managerObject.GetComponent<GhostFrenzy>();
             if (myText.text != "DEDEMIT KILL : " + ghost.kills + " / " + ghost.requiredKills)
                 myText.text = "DEDEMIT KILL : " + ghost.kills+" / "+ghost.requiredKills;
        }
        else if (Application.loadedLevelName.Contains("Defend"))
        {
            DefendingFrenzy defend = managerObject.GetComponent<DefendingFrenzy>();
            if (myText.text != defend.min + " : " + defend.sec)
                myText.text = defend.min + " : " + defend.sec;
        }
        else
        {
            if (myText.text != "ENEMY LEVEL : " + SpawnEnemy.spawnScale.ToString())
            {
                myText.text = "ENEMY LEVEL : " + SpawnEnemy.spawnScale.ToString();
            }
        }
       
    }
}
