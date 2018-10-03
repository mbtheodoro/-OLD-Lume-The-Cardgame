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
    NEUTRAL,
    EARTH,
    FIRE,
    WATER
}

public class CardData : ScriptableObject
{
    [Header("Script")]
    public string className;
    [Header("General")]
    public new string name;
    [TextArea(2, 3)]
    public string description;
    [TextArea(2, 3)]
    public string flavorText;

    public CardType type;
    public Nation nation;

    public Sprite art;
}
