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

        UnitCard unitCard = GetComponent<UnitCard>();

        //references
        unitCard.healthText = healthText;
        unitCard.strengthText = strengthText;
        unitCard.agilityText = agilityText;
        unitCard.wisdomText = wisdomText;
        unitCard.spiritText = spiritText;

        //stats
        unitCard.OriginalHealth = cardData.health;
        unitCard.OriginalStrength = cardData.strength;
        unitCard.OriginalAgility = cardData.agility;
        unitCard.OriginalWisdom = cardData.wisdom;
        unitCard.OriginalSpirit = cardData.spirit;

        //keywords
        unitCard.aggression = cardData.aggression;
        unitCard.analytic = cardData.analytic;

        unitCard.masteryStrength = cardData.masteryStrenght;
        unitCard.masteryAgility = cardData.masteryAgility;
        unitCard.masteryWisdom = cardData.masteryWisdom;
        unitCard.masterySpirit = cardData.masterySpirit;

        unitCard.weaken = cardData.weaken;
        unitCard.hypnosis = cardData.hypnosis;
        unitCard.intimidate = cardData.intimidate;

        unitCard.supportStrenght = cardData.supportStrenght;
        unitCard.supportAgility = cardData.supportAgility;
        unitCard.supportWisdom = cardData.supportWisdom;
        unitCard.supportSpirit = cardData.supportSpirit;

        unitCard.infiltrate = cardData.infiltrate;

        unitCard.berserk = cardData.berserk;
        unitCard.overdrive = cardData.overdrive;

        unitCard.armor = cardData.armor;
        unitCard.endurance = cardData.endurance;

        unitCard.reckless = cardData.reckless;
        unitCard.regenerate = cardData.regenerate;

        unitCard.defiant = cardData.defiant;
        unitCard.stubborn = cardData.stubborn;
        unitCard.piercer = cardData.piercer;
        unitCard.taunt = cardData.taunt;
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
