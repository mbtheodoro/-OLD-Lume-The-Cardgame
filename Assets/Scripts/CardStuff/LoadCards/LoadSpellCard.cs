using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSpellCard : LoadCard
{
    #region REFERENCES
    [HideInInspector] public SpellCardData cardData;

    public Image costBorder;
    public Text costText;
    #endregion

    #region METHODS
    public void LoadCardData(SpellCardData card)
    {
        cardData = card;

        LoadRegularCardData(card);

        costText.text = cardData.cost.ToString();
    }

    public override void LoadCardStyle(CardStyle style)
    {
        base.LoadCardStyle(style);

        costText.color = style.borderColor;
        costText.font = style.numbersTextFont;
        costBorder.color = style.borderColor;
    }
    #endregion
}
