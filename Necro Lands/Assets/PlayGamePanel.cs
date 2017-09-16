using UnityEngine;
using System.Collections;

public class PlayGamePanel : MonoBehaviour {

    private RectTransform rect;
    private bool Summoned;
    private static PlayGamePanel playGame;
    [SerializeField]
    private AreYouSurePanel panel;

    public void Continue()
    {
        if(PlayerPrefs.GetString("charname") != "")
            Fading.GetInstance().Finish("Game Menu Scene");
        else
            Fading.GetInstance().Finish("CharSelection");
    }

    public void AreYouSureDelete()
    {
        panel.Display();
    }

    public void New()
    {
        PlayerPrefs.DeleteAll();
        Fading.GetInstance().Finish("CharSelection");
    }

    void Awake()
    {
        playGame = this;
    }

    void Start()
    {
        panel = AreYouSurePanel.GetInstance();
    }

    public static PlayGamePanel GetPlayGamePanel()
    {
        return playGame;
    }

    public void Summon()
    {
        Summoned = true;
    }

    public void UnSummon()
    {
        Summoned = false;
    }

	void Update()
    {
        if(!rect)
        {
            rect = GetComponent<RectTransform>();
        }

        if(Summoned)
        {
            if(rect.localScale.x < 1f)
            {
                rect.localScale = new Vector3(rect.localScale.x + 2f * Time.deltaTime, rect.localScale.y + 2f * Time.deltaTime, rect.localScale.z);
            }
        }
        else
        {
            if (rect.localScale.x > 0f)
            {
                rect.localScale = new Vector3(rect.localScale.x - 2f * Time.deltaTime, rect.localScale.y - 2f * Time.deltaTime, rect.localScale.z);
            }
        }
    }
}
