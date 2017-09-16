using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartupManager : MonoBehaviour {

    public static bool isPreStarted, isStarted, isFinished, win, lose;
   

    private float timer;
    private GameObject[] lowUI, highUI;
    private float[] lowDes, highDes;
    private float slideDes;
    private GameObject slide, readyText, fightText;
   
	void Start () {
        isStarted = false;
        isPreStarted = false;
        isFinished = false;
        win = false;
        lose = false;
        //soundPlayed = false;
        timer = 0f;
        PlayerPrefs.SetInt("score",0);
        if (Application.loadedLevelName == "Main Game - Defending Frenzy")
        {
            gameObject.AddComponent<DefendingFrenzy>();
        }
        else if (Application.loadedLevelName == "Main Game - Killing Frenzy")
        {
            gameObject.AddComponent<KillingFrenzy>();
        }
        else if (Application.loadedLevelName == "Main Game - Kuntilanak Frenzy" || Application.loadedLevelName == "Main Game - Tuyul Frenzy" || Application.loadedLevelName == "Main Game - Leak Frenzy" || Application.loadedLevelName == "Main Game - Begu Frenzy" || Application.loadedLevelName == "Main Game - Pocong Frenzy")
        {
            gameObject.AddComponent<Frenzy>();
        }

        lowUI = GameObject.FindGameObjectsWithTag("LowUI");
        highUI = GameObject.FindGameObjectsWithTag("HighUI");
        slide = GameObject.FindGameObjectWithTag("HP Life");
        readyText = GameObject.Find("ReadyText");
        fightText = GameObject.Find("ReadyText2");

        lowDes = new float[lowUI.Length];
        highDes = new float[highUI.Length];

        readyText.transform.localScale = Vector3.zero;
        fightText.transform.localScale = Vector3.zero;

        for (int i = 0; i < highUI.Length; i++)
        {
            
            highDes[i] = highUI[i].GetComponent<RectTransform>().position.y;
            highUI[i].GetComponent<RectTransform>().position = new Vector3(highUI[i].GetComponent<RectTransform>().position.x, highUI[i].GetComponent<RectTransform>().position.y + 80f, highUI[i].GetComponent<RectTransform>().position.z);

        }
        for (int i = 0; i < lowUI.Length; i++)
        {
            lowDes[i] = lowUI[i].GetComponent<RectTransform>().position.y;
            lowUI[i].GetComponent<RectTransform>().position = new Vector3(lowUI[i].GetComponent<RectTransform>().position.x, lowUI[i].GetComponent<RectTransform>().position.y - 300f, lowUI[i].GetComponent<RectTransform>().position.z);
        }

        slideDes = slide.GetComponent<RectTransform>().position.y;
        slide.GetComponent<RectTransform>().position = new Vector3(slide.GetComponent<RectTransform>().position.x, slide.GetComponent<RectTransform>().position.y - 300f, slide.GetComponent<RectTransform>().position.z);
        //readyText = GameObject.Find("ReadyText").GetComponent<Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (readyText.transform.localScale.x < 1f && !isFinished)
        {
            readyText.transform.localScale = new Vector3(readyText.transform.localScale.x + 1.2f * Time.deltaTime, readyText.transform.localScale.y + 1.2f * Time.deltaTime, readyText.transform.localScale.z);
        }
        else
        {
            isPreStarted = true;
            if (!GetComponent<AudioSource>().isPlaying && !isFinished)
            {
                GetComponent<AudioSource>().Play();
            }
          
        }

        if (timer >= 1.8f && isPreStarted && !isFinished)
        {
            readyText.transform.localScale = Vector3.zero;
            if (fightText.transform.localScale.x < 1f)
            {
                fightText.transform.localScale = new Vector3(fightText.transform.localScale.x + 1.2f * Time.deltaTime, fightText.transform.localScale.y + 1.2f * Time.deltaTime, fightText.transform.localScale.z);
            }
            else
            {
                GetComponent<AudioSource>().enabled = true;
                if (!GetComponent<AudioSource>().isPlaying && !isFinished)
                {
                    GetComponent<AudioSource>().Play();
                }
                
                if (timer >= 3.3f)
                {
                    
                    isStarted = true;
                }
            }

        }

        if (isStarted)
        {
            fightText.transform.localScale = Vector3.zero;
        }
      
        if (isStarted)
        {
            DisplayUI();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isStarted)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = true;
            }

            else
            {
                Time.timeScale = 1;
                GameObject.Find("PauseCanvas").GetComponent<Canvas>().enabled = false;
            }
               
        }
    }

    void DisplayUI()
    {
        for (int i = 0; i < lowUI.Length; i++)
        {
            if (lowUI[i].GetComponent<RectTransform>().position.y < lowDes[i])
                lowUI[i].GetComponent<RectTransform>().Translate(Vector3.up * 300f * Time.deltaTime);
        }
        for (int i = 0; i < highUI.Length; i++)
        {
            if (highUI[i].GetComponent<RectTransform>().position.y > highDes[i])
                highUI[i].GetComponent<RectTransform>().Translate(Vector3.down * 80f * Time.deltaTime);
        }
        if (slide.GetComponent<RectTransform>().position.y < slideDes)
            slide.GetComponent<RectTransform>().Translate(Vector3.up * 300f * Time.deltaTime);
    }

   

}
