using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventories : MonoBehaviour {

    public int maxItemInInventory = 4;
    public Sprite[] equipSprites;

    private List<string> itemList = new List<string>();
    private ItemAbilities itemAbilities;
    private UIController uiController;
    private Status playerStatus;
    private List<Image> equipImages = new List<Image>();

    // Use this for initialization
    void Start ()
    {
        itemAbilities = GetComponent<ItemAbilities>();
        uiController = GameObject.Find("Canvas").GetComponent<UIController>();
        playerStatus = GetComponent<Status>();

        for (int i = 0; i < maxItemInInventory; i++)
        {
            //Debug.Log(PlayerPrefs.GetString("equip" + i));
            itemList.Add(PlayerPrefs.GetString("equip" + i));
            
            equipImages.Add(GameObject.Find("Equip " + (i + 1)).GetComponent<Image>());

        }

       
        checkCurrItems();
        //uiController.setMaxHp(playerStatus.hp);
        SetEquipImage();
    }

    

    void SetEquipImage()
    {
        List<string> temp = new List<string>(itemList);
      
        for (int i=0; i<maxItemInInventory; i++)
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
    }

    void checkCurrItems()
    {
        
        foreach (string item in itemList)
        {

            if (item.ToLower().CompareTo("kujang") == 0)
            {
                itemAbilities.Kujang();
                continue;
            }
            if (item.ToLower().CompareTo("wooden slippers") == 0)
            {
                itemAbilities.WoodenSlippers();
                continue;
            }
            if (item.ToLower().CompareTo("shield of teumaga") == 0)
            {
                itemAbilities.ShieldOfTeumaga();
                continue;
            }
            if (item.ToLower().CompareTo("rencong") == 0)
            {
                itemAbilities.Rencong();
                continue;
            }
            if (item.ToLower().CompareTo("orb of dedemit") == 0)
            {
                itemAbilities.OrbOfDedemit();
                continue;
            }
            if (item.ToLower().CompareTo("celurit") == 0)
            {
                itemAbilities.Celurit();
                continue;
            }
            if (item.ToLower().CompareTo("ghost orb") == 0)
            {
                itemAbilities.GhostOrb();
                continue;
            }
            if (item.ToLower().CompareTo("hell sphere") == 0)
            {
                itemAbilities.HellSphere();
                continue;
            }
            if (item.ToLower().CompareTo("mandau") == 0)
            {
                itemAbilities.Mandau();
                continue;
            }
            if (item.ToLower().CompareTo("salawaku") == 0)
            {
                itemAbilities.Salawaku();
                continue;
            }
            if (item.ToLower().CompareTo("keris") == 0)
            {
                itemAbilities.Keris();
                continue;
            }
            if (item.ToLower().CompareTo("kuntil anak mask") == 0)
            {
                itemAbilities.KuntilAnakMask();
                continue;
            }
            if (item.ToLower().CompareTo("baluse") == 0)
            {
                itemAbilities.Baluse();
                continue;
            }
            if (item.ToLower().CompareTo("sharp bamboo") == 0)
            {
                itemAbilities.BambuRuncing();
                continue;
            }
            if (item.ToLower().CompareTo("parang") == 0)
            {
                itemAbilities.Parang();
                continue;
            }
            if (item.ToLower().CompareTo("shield of awe") == 0)
            {
                itemAbilities.ShieldOfAwe();
                continue;
            }
            if (item.ToLower().CompareTo("piso surit") == 0)
            {
                itemAbilities.PisoSurit();
                continue;
            }
            if (item.ToLower().CompareTo("golok") == 0)
            {
                itemAbilities.Golok();
                continue;
            }
            if (item.ToLower().CompareTo("badik") == 0)
            {
                itemAbilities.Badik();
                continue;
            }
            if (item.ToLower().CompareTo("jenawi sword") == 0)
            {
                itemAbilities.JenawiSword();
                continue;
            }
        }
    }

    public string[] currItems()
    {
        return itemList.ToArray();
    }
}
