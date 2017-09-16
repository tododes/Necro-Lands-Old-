using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour {

    [SerializeField]
    private EquipSprite[] equips;

    public void GiveRandomStoneToPlayer()
    {
        int r = Random.Range(0, 100);
        if(r >= 95 && r <= 99)
        {
            foreach(EquipSprite e in equips)
            {
                e.EquipExp += 500;
            }
            //PlayerPrefs.SetInt("LEGEND GEM", PlayerPrefs.GetInt("LEGEND GEM") + 1);
        }
        else if (r >= 80 && r <= 94)
        {
            foreach (EquipSprite e in equips)
            {
                e.EquipExp += 100;
            }
            //PlayerPrefs.SetInt("RARE GEM", PlayerPrefs.GetInt("RARE GEM") + 1);
        }
        else if (r >= 50 && r <= 79)
        {
            foreach (EquipSprite e in equips)
            {
                e.EquipExp += 50;
            }
            //PlayerPrefs.SetInt("UNCOMMON GEM", PlayerPrefs.GetInt("UNCOMMON GEM") + 1);
        }
        else if (r >= 0 && r <= 49)
        {
            foreach (EquipSprite e in equips)
            {
                e.EquipExp += 20;
            }
            //PlayerPrefs.SetInt("COMMON GEM", PlayerPrefs.GetInt("COMMON GEM") + 1);
        }
    }
	
	void Start () 
    {
        equips = FindObjectsOfType<EquipSprite>();
	}
	

	void Update () 
    {
	
	}
}
