using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PassiveSkillImage : MonoBehaviour 
{
    public Sprite[] sprites;
    public int index;
    public string[] skillNames = { "Gentle Aura", "Fatal Shot", "Cheerful Strike", "Hypnocharm"};
    public string[] names = { "Grant", "Trevor", "Marcia", "Lucy"};
    void Awake()
    {
        for (int i = 0; i < names.Length; i++)
        {
            if (PlayerPrefs.GetString("charname") == names[i])
            {
                index = i;
                break;
            }
        }
        if (GetComponent<Image>() != null)
            GetComponent<Image>().sprite = sprites[index];
        else if (GetComponent<Text>() != null)
            GetComponent<Text>().text = skillNames[index];
    }
}
