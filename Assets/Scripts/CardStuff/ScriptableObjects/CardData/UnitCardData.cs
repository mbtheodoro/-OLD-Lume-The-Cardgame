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
}
