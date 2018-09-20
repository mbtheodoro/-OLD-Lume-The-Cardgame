using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    PHYSICAL,
    MAGICAL
}

[CreateAssetMenu(fileName = "Attack Card", menuName = "Card/Attack")]
public class AttackCardData : CardData
{
    [Header("Attack")]
    public int baseDamage;
    public int cost;
    public AttackType attackType;

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

    public int modifyUserStrength;
    public int modifyUserAgility;
    public int modifyUserWisdom;
    public int modifyUserSpirit;

    public int modifyEnemyStrength;
    public int modifyEnemyAgility;
    public int modifyEnemyWisdom;
    public int modifyEnemySpirit;
}
