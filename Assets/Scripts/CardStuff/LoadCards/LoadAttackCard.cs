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

        costText.text = cardData.cost.ToString();
        baseDamageText.text = cardData.baseDamage.ToString();
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
