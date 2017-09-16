using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Todo;

public class GameMenuController : MonoBehaviour {

    public Text[] equipments;
    public Canvas gameMenu;
    public Canvas equipmentMenu;
    public int maxEquip = 4;
    public Sprite[] equipSprites;
    public Sprite defaultSprite;

    private Text goldText;
    private int gold;
    private List<string> listEquipment = new List<string>();
    public List<Image> equipImages = new List<Image>();
    private Image notifSkill;

    public Fading Fade;
 
    void Start () 
    {
        if (!PlayerPrefs.HasKey("Player Level"))
            PlayerPrefs.SetInt("Player Level", 1);
        goldText = GameObject.Find("Gold Text").GetComponent<Text>();
        notifSkill = GameObject.Find("NotifImage").GetComponent<Image>();

        if (!PlayerPrefs.HasKey("gold"))
        {
            PlayerPrefs.SetInt("gold", 10500);
            gold = 10500;
        }
        else
        {
            gold = PlayerPrefs.GetInt("gold");
        }

        //CheckEquipments();

        //InitCurrEquipments();

        //SetEquipImage();

      
    }

    public void IntoAttributeUpgrade()
    {
        GameObject.Find("Upgrade Attribute Canvas").GetComponent<Canvas>().enabled = true;
    }

    public void StartPlay()
    {
        if (!PlayerPrefs.HasKey("Training Finished"))
        {
            Fade.Finish("Tutorial New");
            PlayerPrefs.SetInt("Training Finished", 1);
        }
        else
        {
            Fade.Finish("ModeScene");
        }
    }

   
	// Update is called once per frame
	void Update () {
        if (goldText.text != "" + PlayerPrefs.GetInt("gold"))
            goldText.text = ""+PlayerPrefs.GetInt("gold");
        if(notifSkill)
        {
            if (CheckNotifSkill())
                notifSkill.enabled = true;
            else
                notifSkill.enabled = false;
        }
		
    }

   
    bool CheckNotifSkill()
    {
        if (PlayerPrefs.GetInt("currSkill") == 1 && PlayerPrefs.GetInt("gold") >= 4000)
        {
            return true;
        }
        else if (PlayerPrefs.GetInt("currSkill") == 2 && PlayerPrefs.GetInt("gold") >= 8000)
        {
            return true;
        }
        else if (PlayerPrefs.GetInt("currSkill") == 3 && PlayerPrefs.GetInt("gold") >= 12000)
        {
            return true;
        }
        return false;
    }

   /* private void ResetEquipSprites()
    {
        for (int i = 0; i < 4; i++)
            equipImages[i].sprite = defaultSprite;
    }

    private void InitCurrEquipments()
    {
        for (int i = 1; i <= 4; i++)
        {
            equipImages.Add(GameObject.Find("Equip " + i).GetComponent<Image>());
            if (PlayerPrefs.HasKey("equip" + (i)))
            {
                for (int j = 0; j < i; j++)
                {
                    if(listEquipment[i-1] != listEquipment[j])
                        listEquipment.Add(PlayerPrefs.GetString("equip" + (i)));
                }
                    
            }
               
        }
    }

    void SetEquipImage()
    {
        ResetEquipSprites();

        List<string> temp = new List<string>();

        foreach (string isi in listEquipment)
            temp.Add(isi);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < equipSprites.Length; j++)
            {
                if (temp.IndexOf(equipSprites[j].name) >= 0)
                {
                    temp.Remove(equipSprites[j].name);
                    equipImages[i].sprite = equipSprites[j];
                    break;
                }
            }
        }

        
    }*/

    public void ChangeScene(string sceneName)
    {
        /*int index = -1;
        for (int i = 0; i < 4; i++)
            PlayerPrefs.DeleteKey("equip" + (i+1));

        for (int i = 0; i < listEquipment.Count; i++)
        {
            PlayerPrefs.SetString("equip" + (i+1), listEquipment[i]);
            for (int j = 1; j <= 50; j++)
            {
                if (PlayerPrefs.GetString("item" + j) == PlayerPrefs.GetString("equip" + i))
                {
                    index = i;
                    break;
                }
            }
            Debug.Log(index);
            if (index > -1)
            {
                PlayerPrefs.SetInt("equipqty" + (i + 1), PlayerPrefs.GetInt("item" + index + "qty"));
            }
        }
        GetComponent<AudioSource>().Play();
        */
            //Application.LoadLevel(sceneName);
    }

    public void GoToEquipment()
    {
        gameMenu.enabled = false;
        equipmentMenu.enabled = true;
        GetComponent<AudioSource>().Play();
    }

  

    public void GoToMainMenu()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("MainScene");
    }

    public void GoToAchievement()
    {
        GetComponent<AudioSource>().Play();
        Application.LoadLevel("Achieve");
    }



    /* public void AddEquipment(string equipment)
     {
         GetComponent<AudioSource>().Play();

         if (listEquipment.IndexOf(equipment.ToLower()) >= 0)
         {
             // if(PlayerPrefs.GetInt(equipment.ToLower()) > 0)
             //listEquipment.Add(equipment);
             listEquipment.Remove(equipment.ToLower());
         }
         else if (listEquipment.Count == maxEquip)
         {

         }
         //Debug.Log("Equipment Penuh");
         else
         {
             listEquipment.Add(equipment);
         }
  
         for (int i = 0; i < listEquipment.Count; i++)
             Debug.Log(listEquipment[i] + "\n");
         SetEquipImage();
     }

     void CheckEquipments()
     {
         bool hadEquipment;

         foreach(Text equipment in equipments)
         {
             hadEquipment = false;

             for (int i = 1; i <= 50; i++)
                 if (PlayerPrefs.HasKey("item" + i))
                     if (equipment.text.ToLower().Contains(PlayerPrefs.GetString("item" + i)))
                     {
                         hadEquipment = true;
                         break;
                     }
            
             /*if (!hadEquipment)
             {
                 equipment.text = "";

             }
         }
     }*/
}
