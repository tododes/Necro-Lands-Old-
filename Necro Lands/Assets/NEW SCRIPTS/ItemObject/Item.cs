using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public bool CanActivate;
    public int coolDown;

    public Rarity R;
    public enum Rarity
    {
        Common, Uncommon, Rare, Legend
    }

    public int Exp, Level, MaxExp;
    public int BaseMaxExpBonus, BonusMaxExpMultiplier;

    [Header("Extra Attribute")]
    public float HPBonus;
    public float ManaBonus;
    public float AttackBonus;
    public float ArmorBonus;
    public float MoveSpeedBonus;
    public int AttackSpeedBonus;
    public float HPRegenBonus;
    public float ManaRegenBonus;

    [Header("Extra Modifier")]
    public float LifeSteal;
    public float Critical;
    public float CriticalChance;
    public float ArmorRed;
    public float burnDamage;
    public float DamageReturnRate;
    public float SlowRate;
    public float Cleave;

    [Header("Activate Effects Attribute")]
    public int duration;
    public float ExtraHPBonus;
    public float ExtraManaBonus;
    public float ExtraAttackBonus;
    public float ExtraArmorBonus;
    public float ExtraMoveSpeedBonus;
    public int ExtraAttackSpeedBonus;
    public float ExtraHPRegenBonus;
    public float ExtraManaRegenBonus;

    [Header("Activate Effects Modifier")]
    public float ExtraLifeSteal;
    public float ExtraCritical;
    public float ExtraCriticalChance;
    public float ExtraArmorRed;
    public float ExtraburnDamage;
    public float ExtraDamageReturnRate;
    public float ExtraSlowRate;
    public float ExtraCleave;

    protected void Update()
    {
        if (BaseMaxExpBonus == 0 && BonusMaxExpMultiplier == 0)
        {
            switch (R)
            {
                case Rarity.Common:
                    BaseMaxExpBonus = 120;
                    BonusMaxExpMultiplier = 2;
                    break;

                case Rarity.Uncommon:
                    BaseMaxExpBonus = 180;
                    BonusMaxExpMultiplier = 4;
                    break;

                case Rarity.Rare:
                    BaseMaxExpBonus = 240;
                    BonusMaxExpMultiplier = 6;
                    break;

                case Rarity.Legend:
                    BaseMaxExpBonus = 300;
                    BonusMaxExpMultiplier = 8;
                    break;
            }
        }
       
        if(Level == 10)
        {
            Exp = 0;
        }

        MaxExp = BaseMaxExpBonus + BonusMaxExpMultiplier * Level * Level * Level;

        if(Exp >= MaxExp && Level < 10)
        {
            Level++;
            Exp -= MaxExp;
            //MaxExp += BaseMaxExpBonus + MultiplierMaxExpBonus * MultiplierMaxExpBonus * MultiplierMaxExpBonus;
        }


    }

    public void AddAttributes(Player pl)
    {
        pl.HP += HPBonus;
        pl.MaxHP += HPBonus;
        pl.Attack += AttackBonus;
        pl.Armor += ArmorBonus;
        pl.MoveSpeed += MoveSpeedBonus;
        pl.AttackSpeed += AttackSpeedBonus;
        pl.HPRegen += HPRegenBonus;
        pl.ManaRegen += ManaRegenBonus;
    }

    public void AddModifiers(Modifier m)
    {
        m.LifeSteal += LifeSteal;
        m.Critical += Critical;
        m.CriticalChance += CriticalChance;
        m.ArmorReduction += ArmorRed;
        m.burnDamage += burnDamage;
        m.DamageReturn += DamageReturnRate;
        m.SlowRate += SlowRate;
        m.CleaveRate += Cleave;
    }

    public void ActivateExtraAttributes(Player pl)
    {
        pl.HP += ExtraHPBonus;
        pl.MaxHP += ExtraHPBonus;
        pl.Attack += ExtraAttackBonus;
        pl.Armor += ExtraArmorBonus;
        pl.MoveSpeed += ExtraMoveSpeedBonus;
        pl.AttackSpeed += ExtraAttackSpeedBonus;
        pl.HPRegen += ExtraHPRegenBonus;
        pl.ManaRegen += ExtraManaRegenBonus;
    }

    public void DeActivateExtraAttributes(Player pl)
    {
        pl.HP -= ExtraHPBonus;
        pl.MaxHP -= ExtraHPBonus;
        pl.Attack -= ExtraAttackBonus;
        pl.Armor -= ExtraArmorBonus;
        pl.MoveSpeed -= ExtraMoveSpeedBonus;
        pl.AttackSpeed -= ExtraAttackSpeedBonus;
        pl.HPRegen -= ExtraHPRegenBonus;
        pl.ManaRegen -= ExtraManaRegenBonus;
    }

    public void ActivateExtraModifiers(Modifier m)
    {
        m.LifeSteal += ExtraLifeSteal;
        m.Critical += ExtraCritical;
        m.CriticalChance += ExtraCriticalChance;
        m.ArmorReduction += ExtraArmorRed;
        m.burnDamage += ExtraburnDamage;
        m.DamageReturn += ExtraDamageReturnRate;
        m.SlowRate += ExtraSlowRate;
        m.CleaveRate += ExtraCleave;
    }

    public void DeActivateExtraModifiers(Modifier m)
    {
        m.LifeSteal -= ExtraLifeSteal;
        m.Critical -= ExtraCritical;
        m.CriticalChance -= ExtraCriticalChance;
        m.ArmorReduction -= ExtraArmorRed;
        m.burnDamage -= ExtraburnDamage;
        m.DamageReturn -= ExtraDamageReturnRate;
        m.SlowRate -= ExtraSlowRate;
        m.CleaveRate -= ExtraCleave;
    }
}
