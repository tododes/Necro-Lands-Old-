using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade : MonoBehaviour {

    public static int index;

    private TextMesh detail, nextValue;
    private string[] detailText = { "Increase shooting capabilities", "Increase defensive capabilities", "Increase durability capabilities"};
    public Slider s;
    public Text t;

    private string[] key = { "A", "AR", "D" };
    private Image[] n;

    void Start()
    {
        index = 0;
       
        detail = GameObject.Find("DetailText").GetComponent<TextMesh>();
        n = new Image[3];
        for (int x = 0; x < 3; x++)
        {
            n[x] = GameObject.Find("N" + x).GetComponent<Image>();
        }
    }

    void Update()
    {
        detail.text = detailText[index];
        SliderMechanic();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt(key[i]) == 1)
            {
                n[i].enabled = true;
            }
            else
            {
                n[i].enabled = false;
            }
        }
        
    }

    void SliderMechanic()
    {
        
        if (index == 0)
        {
            s.minValue = 1000 + 5 * PlayerPrefs.GetInt("attack") * PlayerPrefs.GetInt("attack") * PlayerPrefs.GetInt("attack");
            s.value = PlayerPrefs.GetInt("gold");
            s.maxValue = 1000 + 5 * (PlayerPrefs.GetInt("attack") + 1) * (PlayerPrefs.GetInt("attack") + 1) * (PlayerPrefs.GetInt("attack") + 1);
            if (s.value >= s.maxValue)
            {
                if (!PlayerPrefs.HasKey("A"))
                {
                    PlayerPrefs.SetInt("A", 0);
                }
                PlayerPrefs.SetInt("A", 1);
            }
            t.text = PlayerPrefs.GetInt("gold") + " / " + s.maxValue;
           
        }
        else if (index == 1)
        {
            s.minValue = 1000 + 5 * PlayerPrefs.GetInt("armor") * PlayerPrefs.GetInt("armor") * PlayerPrefs.GetInt("armor");
            s.value = PlayerPrefs.GetInt("gold");
            s.maxValue = 1000 + 5 * (PlayerPrefs.GetInt("armor") + 1) * (PlayerPrefs.GetInt("armor") + 1) * (PlayerPrefs.GetInt("armor") + 1);
            if (s.value >= s.maxValue)
            {
                if (!PlayerPrefs.HasKey("AR"))
                {
                    PlayerPrefs.SetInt("AR", 0);
                }
                PlayerPrefs.SetInt("AR", 1);
            }
            t.text = PlayerPrefs.GetInt("gold") + " / " + s.maxValue;
        }
        else if (index == 2)
        {
            s.minValue = 1000 + 5 * PlayerPrefs.GetInt("dur") * PlayerPrefs.GetInt("dur") * PlayerPrefs.GetInt("dur");
            s.value = PlayerPrefs.GetInt("gold");
            s.maxValue = 1000 + 5 * (PlayerPrefs.GetInt("dur") + 1) * (PlayerPrefs.GetInt("dur") + 1) * (PlayerPrefs.GetInt("dur") + 1);
            if (s.value >= s.maxValue)
            {
                if (!PlayerPrefs.HasKey("D"))
                {
                    PlayerPrefs.SetInt("D", 0);
                }
                PlayerPrefs.SetInt("D", 1);
            }
            t.text = PlayerPrefs.GetInt("gold") + " / " + s.maxValue;
        }
    }
    void OnMouseDown()
    {
     
        switch (index)
        {
            case 0:
                getAttackBonus();
                break;
            case 1:
                getArmorBonus();
                break;
            case 2:
                getHPBonus();
                break;
        }
    }

    void getAttackBonus()
    {
       
        if (PlayerPrefs.GetInt("gold") >= 1000 + 5 * PlayerPrefs.GetInt("attack") * PlayerPrefs.GetInt("attack") * PlayerPrefs.GetInt("attack"))
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - (1000 + 5 * PlayerPrefs.GetInt("attack") * PlayerPrefs.GetInt("attack") * PlayerPrefs.GetInt("attack")));
            PlayerPrefs.SetInt("attack", PlayerPrefs.GetInt("attack") + 1);
            PlayerPrefs.SetInt("A",0);
        }
    }
    void getArmorBonus()
    {
       
        if (PlayerPrefs.GetInt("gold") >= 1000 + 5 * PlayerPrefs.GetInt("armor") * PlayerPrefs.GetInt("armor") * PlayerPrefs.GetInt("armor"))
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - (1000 + 5 * PlayerPrefs.GetInt("armor") * PlayerPrefs.GetInt("armor") * PlayerPrefs.GetInt("armor")));
            PlayerPrefs.SetInt("armor", PlayerPrefs.GetInt("armor") + 1);
            PlayerPrefs.SetInt("A", 0);
        }
    }
    void getHPBonus()
    {
       
        if (PlayerPrefs.GetInt("gold") >= 1000 + 5 * PlayerPrefs.GetInt("dur") * PlayerPrefs.GetInt("dur") * PlayerPrefs.GetInt("dur"))
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") - (1000 + 5 * PlayerPrefs.GetInt("dur") * PlayerPrefs.GetInt("dur") * PlayerPrefs.GetInt("dur")));
            PlayerPrefs.SetInt("dur", PlayerPrefs.GetInt("dur") + 1);
            PlayerPrefs.SetInt("A", 0);
        }
    }
}
