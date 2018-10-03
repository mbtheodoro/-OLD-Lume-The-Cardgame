using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Initiative
{
    TURNPLAYER,
    NONTURNPLAYER,
    STRENGTH,
    AGILITY,
    WISDOM,
    SPIRIT,
    HEALTH,
    FIRE,
    EARTH,
    WATER
}

[CreateAssetMenu(fileName = "Location Card", menuName = "Card/Location")]
public class LocationCardData : CardData
{
    [Header("Location")]
    public Initiative initiative;

    private void OnEnable()
    {
        type = CardType.LOCATION;
    }
}
