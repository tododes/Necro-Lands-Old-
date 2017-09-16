using UnityEngine;
using System.Collections;

public class CharacterGrowthRate : MonoBehaviour 
{

    public int BaseHP, BaseMana, BaseAtk, BaseArmor, BaseAS;
    [SerializeField]
    public int HPGrowthRate, ManaGrowthRate, AttackGrowthRate, ArmorGrowthRate, AttackSpeedGrowthRate;

    void Start()
    {
        if(!PlayerPrefs.HasKey("HP"))
        {
            PlayerPrefs.SetFloat("HP", BaseHP);
            PlayerPrefs.SetFloat("Mana", BaseMana);
            PlayerPrefs.SetFloat("Attack", BaseAtk);
            PlayerPrefs.SetFloat("Armor", BaseArmor);
            PlayerPrefs.SetInt("Attack Speed", BaseAS);
        }
    }
}
