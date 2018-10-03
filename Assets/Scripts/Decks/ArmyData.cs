using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Army", menuName = "Army")]
public class ArmyData : ScriptableObject
{
    public List<UnitCardData> units;
    public List<CardData> items;
    public List<AttackCardData> attacks;
    public List<int> attackCounts;
    public List<LocationCardData> locations;
}
