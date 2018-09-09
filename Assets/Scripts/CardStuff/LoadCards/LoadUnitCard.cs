using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUnitCard : LoadCard
{
    #region REFERENCES
    [HideInInspector] public UnitCardData cardData;

    public Image healthBorder;
    
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

        LoadRegularCardData(card);

        UnitCard unitCard = (UnitCard) GetComponent<UnitCard>();

        unitCard.healthText = healthText;
        unitCard.strengthText = strengthText;
        unitCard.agilityText = agilityText;
        unitCard.wisdomText = wisdomText;
        unitCard.spiritText = spiritText;

        unitCard.OriginalHealth = cardData.health;
        unitCard.OriginalStrength = cardData.strength;
        unitCard.OriginalAgility = cardData.agility;
        unitCard.OriginalWisdom = cardData.wisdom;
        unitCard.OriginalSpirit = cardData.spirit;
    }

    public override void LoadCardStyle(CardStyle style)
    {
        base.LoadCardStyle(style);

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
