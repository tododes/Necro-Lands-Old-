using UnityEngine;
using System.Collections;

public class AreYouSureManager : MonoBehaviour {

    private string currentLevel;
    void Start()
    {
        currentLevel = Application.loadedLevelName;
    }
    public void Yes()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("MainScene");
        Time.timeScale = 1;
        
      
    }

    public void No()
    {
        GetComponent<AudioSource>().Play();
        GetComponent<Canvas>().enabled = false;
        GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = true;
    }

    public void RestartScene()
    {
        Application.LoadLevel(currentLevel);
    }

   
    
}
