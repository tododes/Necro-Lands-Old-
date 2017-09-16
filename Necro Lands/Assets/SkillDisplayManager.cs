using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillDisplayManager : MonoBehaviour {

    string[] name = {"Grant", "Trevor", "Marcia", "Lucy"};
    string[] skill = {"Gentleman's spirit","Fatal Shot", "Cheerful Death", "Hypnocharm"};
    public Sprite[] s1, s2, s3, s4;
    public Sprite[] sprite;
    public Image[] notif;
    int index = -1;
	// Use this for initialization
	void Start ()
    {
      
       
            for (int i = 0; i < name.Length; i++)
            {
                if (PlayerPrefs.GetString("charname") == name[i])
                {
                    index = i;
                    break;
                }
            }

        GameObject.Find("s1").GetComponent<Image>().sprite = sprite[index];
        GameObject.Find("SkillText").GetComponent<Text>().text = skill[index];
        GameObject.Find("T1").GetComponent<Image>().sprite = s1[index];
        GameObject.Find("T2").GetComponent<Image>().sprite = s2[index];
        GameObject.Find("T3").GetComponent<Image>().sprite = s3[index];
        GameObject.Find("T4").GetComponent<Image>().sprite = s4[index];
    }

    void CheckCondition()
    {
        if (PlayerPrefs.GetInt("currSkill") == 1 && PlayerPrefs.GetInt("gold") >= 2500)
        {
            notif[0].enabled = true;
        }
        else
        {
            notif[0].enabled = false;
        }

        if (PlayerPrefs.GetInt("currSkill") == 2 && PlayerPrefs.GetInt("gold") >= 5000)
        {
            notif[1].enabled = true;
        }
        else
        {
            notif[1].enabled = false;
        }

        if (PlayerPrefs.GetInt("currSkill") == 3 && PlayerPrefs.GetInt("gold") >= 10000)
        {
            notif[2].enabled = true;
        }
        else
        {
            notif[2].enabled = false;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        CheckCondition();
	}

    public void Back()
    {
        Application.LoadLevel("Game Menu Scene");
    }
}
