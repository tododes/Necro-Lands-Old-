using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField]
    private CharacterGrowthRate growthRate;

    void Update()
    {
        GetComponent<Button>().enabled = GetComponent<Image>().enabled = GetComponentInChildren<Text>().enabled = (PlayerPrefs.GetInt("UPGRADE POINT") > 0);
    }

    public void PressToUpgrade(string st)
    {
        if(!growthRate)
        {
            foreach (CharacterGrowthRate gr in FindObjectsOfType<CharacterGrowthRate>())
            {
                if (gr.gameObject.activeInHierarchy)
                {
                    growthRate = gr;
                    break;
                }
            }
        }

        if(st.Contains("HP"))
        {
            PlayerPrefs.SetFloat(st, PlayerPrefs.GetFloat(st) + growthRate.HPGrowthRate);
        }
        else if (st.Contains("Mana"))
        {
            PlayerPrefs.SetFloat(st, PlayerPrefs.GetFloat(st) + growthRate.ManaGrowthRate);
        }
        else if (st.Contains("Attack Speed"))
        {
            PlayerPrefs.SetFloat(st, PlayerPrefs.GetFloat(st) + growthRate.AttackSpeedGrowthRate);
        }
        else if (st.Contains("Attack"))
        {
            PlayerPrefs.SetFloat(st, PlayerPrefs.GetFloat(st) + growthRate.AttackGrowthRate);
        }
        else if (st.Contains("Armor"))
        {
            PlayerPrefs.SetFloat(st, PlayerPrefs.GetFloat(st) + growthRate.ArmorGrowthRate);
        }
        
    }
    //public Image icon;
    //private Text indicatorText;
    //private Image mainImage;

    //public AVAILABILITY A;
    //public enum AVAILABILITY
    //{
    //    YES, NO
    //}

    //void Awake()
    //{
    //    indicatorText = GetComponentInChildren<Text>();
    //    mainImage = GetComponent<Image>();
    //}

    //void Update()
    //{
    //    if (PlayerPrefs.GetInt("currSkill") >= 4 && gameObject.activeInHierarchy)
    //    {
    //        gameObject.SetActive(false);
    //    }

    //    if (A == AVAILABILITY.YES && mainImage.color != Color.blue)
    //    {
    //        mainImage.color = Color.blue;
    //        indicatorText.text = "UPGRADE!!";
    //        icon.enabled = true;
    //    }
    //    else if (A == AVAILABILITY.NO && mainImage.color != Color.white)
    //    {
    //        mainImage.color = Color.white;
    //        indicatorText.text = "LOCKED!";
    //        icon.enabled = false;
    //    }

    //    if (PlayerPrefs.GetInt("gold") >= PlayerPrefs.GetInt("currSkill") * 4000 && A != AVAILABILITY.YES)
    //    {
    //        A = AVAILABILITY.YES;
    //    }
    //    else if (PlayerPrefs.GetInt("gold") < PlayerPrefs.GetInt("currSkill") * 4000 && A != AVAILABILITY.NO)
    //    {
    //        A = AVAILABILITY.NO;
    //    }
    //}

    //public void OnPointerEnter(PointerEventData p)
    //{
    //    if (A == AVAILABILITY.YES)
    //        mainImage.color = Color.red;
    //}

    //public void OnPointerExit(PointerEventData p)
    //{
    //    if (A == AVAILABILITY.YES)
    //        mainImage.color = Color.blue;
    //}

    //public void Upgrade()
    //{
    //    if (A == AVAILABILITY.YES && PlayerPrefs.GetInt("currSkill") < 4)
    //    {
    //        PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - PlayerPrefs.GetInt("currSkill") * 4000);
    //        PlayerPrefs.SetInt("currSkill", PlayerPrefs.GetInt("currSkill") + 1);
    //    }

    //}
}
