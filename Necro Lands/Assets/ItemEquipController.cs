using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemEquipController : MonoBehaviour {

    public bool Initiated;
    public EquipImage[] equipImages;
	void Awake () 
    {
        Initiated = false;
	}

   

    public void FillEquipList(string n)
    {
      
        for (int i = 1; i <= 8; i++)
        {
            Debug.Log(PlayerPrefs.GetString("equip" + i));
            for (int j = 0; j <= i; j++)
            {
                if (n == PlayerPrefs.GetString("equip" + (j+1)))
                    return;
            }
            if(PlayerPrefs.GetString("equip"+i) == "")
            {
                equipImages[i - 1].Initiated = false;
                PlayerPrefs.SetString("equip" + i, n);
                break;
            }

        }
     
        
    }
}
