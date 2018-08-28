using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCardDisplay : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public AttackCard card;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;

    public Text nameText;
    public Text descriptionText;
    public Text flavorText;
    public Text costText;
    public Text baseDamageText;
    #endregion

    #region METHODS
    public void InitiateCard(AttackCard card)
    {
        this.card = card;

        art.sprite = this.card.art;
        cardIcon.sprite = this.card.cardIcon;
        nameBackground.color = this.card.nameBackground;
        descriptionBackground.color = this.card.descriptionBackground;
        nameText.text = this.card.cardName;
        descriptionText.text = this.card.description;
        flavorText.text = this.card.flavorText;
        costText.text = this.card.cost.ToString();
        baseDamageText.text = this.card.baseDamage.ToString();
    }
    #endregion
}
