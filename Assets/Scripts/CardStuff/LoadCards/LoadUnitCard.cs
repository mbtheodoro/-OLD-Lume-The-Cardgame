using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUnitCard : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public UnitCardData cardData;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;
    public Image healthBorder;

    public Text nameText;
    public Text descriptionText;
    public Text flavorText;
    public Text healthText;
    public Text strengthText;
    public Text agilityText;
    public Text wisdomText;
    public Text spiritText;
    #endregion

    #region METHODS
    public void LoadCardData(UnitCardData card)
    {
        cardData = card;

        art.sprite = cardData.art;
        nameText.text = cardData.name;
        descriptionText.text = cardData.description;
        flavorText.text = cardData.flavorText;
        healthText.text = cardData.health.ToString();
        strengthText.text = cardData.strength.ToString();
        agilityText.text = cardData.agility.ToString();
        wisdomText.text = cardData.wisdom.ToString();
        spiritText.text = cardData.spirit.ToString();
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

        healthText.color = style.borderColor;
        healthBorder.color = style.borderColor;
        healthText.font = style.nameTextFont;

        strengthText.color = style.numbersTextColor;
        strengthText.font = style.numbersTextFont;
        agilityText.color = style.numbersTextColor;
        agilityText.font = style.numbersTextFont;
        wisdomText.color = style.numbersTextColor;
        wisdomText.font = style.numbersTextFont;
        spiritText.color = style.numbersTextColor;
        spiritText.font = style.numbersTextFont;
    }
    #endregion
}
