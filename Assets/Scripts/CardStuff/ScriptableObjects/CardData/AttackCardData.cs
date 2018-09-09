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
}
