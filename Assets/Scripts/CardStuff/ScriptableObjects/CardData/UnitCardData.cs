using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit Card", menuName = "Card/Unit")]
public class UnitCardData : CardData
{
    [Header("Unit")]
    public int health;
    public int strength;
    public int agility;
    public int wisdom;
    public int spirit;

    [Header("Keywords")]
    public int aggression;
    public int analytic;

    public int masteryStrenght;
    public int masteryAgility;
    public int masteryWisdom;
    public int masterySpirit;

    public int weaken;
    public int restrain;
    public int hypnosis;
    public int intimidate;

    public int supportStrenght;
    public int supportAgility;
    public int supportWisdom;
    public int supportSpirit;

    public int infiltrate;

    public bool berserk;
    public bool overdrive;

    public int armor;
    public int endurance;

    public int reckless;
    public int regenerate;

    public bool defiant;
    public bool stubborn;
    public bool piercer;
    //public bool taunt;
    //public bool stealth;

    private void OnEnable()
    {
        type = CardType.UNIT;
    }
}
