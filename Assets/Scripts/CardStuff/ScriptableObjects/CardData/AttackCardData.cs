using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    PHYSICAL,
    MAGICAL
}

public enum AttackTarget
{
    USER,
    ENEMY
}

[CreateAssetMenu(fileName = "Attack Card", menuName = "Card/Attack")]
public class AttackCardData : CardData
{
    [Header("Attack")]
    public int baseDamage;
    public int cost;
    public AttackType attackType;
    public AttackTarget target;

    [Header("Operations")]
    public Vector2 statTestStrength;
    public Vector2 statTestAgility;
    public Vector2 statTestWisdom;
    public Vector2 statTestSpirit;

    public Vector2 outStatStrength;
    public Vector2 outStatAgility;
    public Vector2 outStatWisdom;
    public Vector2 outStatSpirit;

    public Vector2 statFailStrength;
    public Vector2 statFailAgility;
    public Vector2 statFailWisdom;
    public Vector2 statFailSpirit;

    public int modifyStrength;
    public int modifyAgility;
    public int modifyWisdom;
    public int modifySpirit;
}
