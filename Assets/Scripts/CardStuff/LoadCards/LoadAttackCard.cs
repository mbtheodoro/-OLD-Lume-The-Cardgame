using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadAttackCard : LoadCard
{
    #region REFERENCES
    [HideInInspector] public AttackCardData cardData;

    public Image costBorder;
    public Image attackTypeIcon;

    public Sprite physicalIcon;
    public Sprite magicalIcon;
    
    public Text costText;
    public Text baseDamageText;
    #endregion

    #region METHODS
    public void LoadCardData(AttackCardData card)
    {
        cardData = card;

        LoadRegularCardData(card);

        AttackCard attackCard = (AttackCard) GetComponent<AttackCard>();

        attackCard.costText = costText;
        attackCard.baseDamageText = baseDamageText;

        attackCard.originalCost = card.cost;
        attackCard.baseDamage = card.baseDamage;
        attackCard.type = card.attackType;

        attackCard.statTestStrength = card.statTestStrength;
        attackCard.statTestAgility = card.statTestAgility;
        attackCard.statTestWisdom = card.statTestWisdom;
        attackCard.statTestSpirit = card.statTestSpirit;

        attackCard.outStatStrength = card.outStatStrength;
        attackCard.outStatAgility = card.outStatAgility;
        attackCard.outStatWisdom = card.outStatWisdom;
        attackCard.outStatSpirit = card.outStatSpirit;

        attackCard.statFailStrength = card.statFailStrength;
        attackCard.statFailAgility = card.statFailAgility;
        attackCard.statFailWisdom = card.statFailWisdom;
        attackCard.statFailSpirit = card.statFailSpirit;

        attackCard.modifyUserStrength = card.modifyUserStrength;
        attackCard.modifyUserAgility = card.modifyUserAgility;
        attackCard.modifyUserWisdom = card.modifyUserWisdom;
        attackCard.modifyUserSpirit = card.modifyUserSpirit;

        attackCard.modifyEnemyStrength = card.modifyEnemyStrength;
        attackCard.modifyEnemyAgility = card.modifyEnemyAgility;
        attackCard.modifyEnemyWisdom = card.modifyEnemyWisdom;
        attackCard.modifyEnemySpirit = card.modifyEnemySpirit;
    }

    public override void LoadCardStyle(CardStyle style)
    {
        base.LoadCardStyle(style);

        costText.color = style.borderColor;
        costText.font = style.nameTextFont;
        costBorder.color = style.borderColor;

        baseDamageText.font = style.numbersTextFont;
        baseDamageText.color = style.descriptionTextColor;

        if(cardData.attackType == AttackType.PHYSICAL)
            attackTypeIcon.sprite = physicalIcon;
        if (cardData.attackType == AttackType.MAGICAL)
            attackTypeIcon.sprite = magicalIcon;
    }
    #endregion
}
