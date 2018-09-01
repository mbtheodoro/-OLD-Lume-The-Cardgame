using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    UNIT,
    EQUIP,
    ATTACK,
    LOCATION,
    SPELL
}

public enum Nation
{
    EARTH,
    FIRE,
    WATER,
    NEUTRAL
}

public class CardData : ScriptableObject
{
    public new string name;
    public string flavorText;
    public string description;

    public CardType type;
    public Nation nation;

    public Sprite art;
}
