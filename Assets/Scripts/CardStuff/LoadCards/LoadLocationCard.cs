using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLocationCard : LoadCard
{
    #region REFERENCES
    [HideInInspector] public LocationCardData cardData;
    #endregion

    #region METHODS
    public void LoadCardData(LocationCardData card)
    {
        cardData = card;

        LoadRegularCardData(card);
        LocationCard locationCard = GetComponent<LocationCard>();
        locationCard.initiative = card.initiative;
    }

    public override void LoadCardStyle(CardStyle style)
    {
        base.LoadCardStyle(style);
    }
    #endregion
}
