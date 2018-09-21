using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEquipCard : LoadCard
{
    #region REFERENCES
    [HideInInspector] public EquipCardData cardData;
    #endregion

    #region METHODS
    public void LoadCardData(EquipCardData card)
    {
        cardData = card;

        LoadRegularCardData(card);
    }

    public override void LoadCardStyle(CardStyle style)
    {
        base.LoadCardStyle(style);
    }
    #endregion
}
