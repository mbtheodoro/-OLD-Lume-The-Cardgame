using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Spell Card", menuName = "Card/Spell")]
public class SpellCardData: CardData
{
    [Header("Spell")]
    public int cost;
}
