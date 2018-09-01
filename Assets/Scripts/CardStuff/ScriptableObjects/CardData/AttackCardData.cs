using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack Card", menuName = "Card/Attack")]
public class AttackCardData : CardData
{
    public int baseDamage;
    public int cost;
}
