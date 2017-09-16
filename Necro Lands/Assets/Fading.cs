using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fading : MonoBehaviour 
{
    public static bool isNotBegan, isBegan, isFinished;
    public float x;
    public string nextScene = "";
	public GameObject loadPanel;

    private static Fading instance;

	private bool loading;
	public Text loadingText;
    private Player player;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () 
    {
        isNotBegan = true;
        isBegan = false;
        isFinished = false;
            x = 1f;
		loading = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		//loadingText = loadPanel.GetComponentInChildren<Text> ();
	}

    public static Fading GetInstance()
    {
        return instance;
    }

    void validate()
    {
        if (x <= 0f)
        {
            x = 0f;
            GetComponent<Image>().enabled = false;
        }
        else
        {
            if (x > 1f)
            {
                x = 1f;
            }
            GetComponent<Image>().enabled = true;
        }
    }
	// Update is called once per frame
	void Update () 
    {
        validate();
        if (isNotBegan && !isFinished)
        {
            if (x > 0f)
            {
                x -= 0.9f * Time.deltaTime;
            }
            else
            {
                isNotBegan = false;
                isBegan = true;
            }
        }

        if(isFinished)
        {
            if (x < 1f)
            {
                x += 0.75f * Time.deltaTime;
            }
            else
            {
				if(!loading)
				{
					loading = true;
					StartCoroutine(LoadingScreen());
				}
            }
        }
        GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, x);
	}

	IEnumerator LoadingScreen()
	{
		loadPanel.SetActive (true);
		AsyncOperation a = Application.LoadLevelAsync (nextScene);
		loadingText.text = "LOADING......";
		a.allowSceneActivation = true;
		yield return a;
	}

    public void Finish(string x)
    {
        isBegan = false;
        isFinished = true;
        if (Time.timeScale <= 0f)
            Time.timeScale = 1f;
        if (x == "ThisScene")
        {
            nextScene = Application.loadedLevelName;
        }
        else
        {
            nextScene = x;
        }
       
    }
}
