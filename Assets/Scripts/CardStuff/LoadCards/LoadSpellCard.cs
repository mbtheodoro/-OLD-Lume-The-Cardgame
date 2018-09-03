using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSpellCard : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public SpellCardData cardData;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;
    public Image costBorder;

    public Text nameText;
    public Text descriptionText;
    public Text flavorText;
    public Text costText;
    #endregion

    #region METHODS
    public void LoadCardData(SpellCardData card)
    {
        cardData = card;

        art.sprite = cardData.art;
        nameText.text = cardData.name;
        descriptionText.text = cardData.description;
        flavorText.text = cardData.flavorText;
        costText.text = cardData.cost.ToString();
    }

    public void LoadCardStyle(CardStyle style)
    {
        cardIcon.sprite = style.cardIcon;

        nameBackground.color = style.mainColorA;
        nameText.font = style.nameTextFont;
        nameText.color = style.nameTextColor;

        descriptionBackground.color = style.mainColorB;
        descriptionText.font = style.descriptionTextFont;
        descriptionText.color = style.descriptionTextColor;

        flavorText.color = style.flavorTextColor;
        flavorText.font = style.flavorTextFont;

        costText.color = style.borderColor;
        costText.font = style.numbersTextFont;
        costBorder.color = style.borderColor;
    }
    #endregion
}
