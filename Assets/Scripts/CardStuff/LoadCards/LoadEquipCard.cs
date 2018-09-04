using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEquipCard : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public EquipCardData cardData;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;
    public Image cardBack;
    public Image cardBackIcon;

    public Text nameText;
    public Text descriptionText;
    public Text flavorText;
    #endregion

    #region METHODS
    public void LoadCardData(EquipCardData card)
    {
        cardData = card;

        art.sprite = cardData.art;
        nameText.text = cardData.name;
        descriptionText.text = cardData.description;
        flavorText.text = cardData.flavorText;
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
    }
    #endregion
}
