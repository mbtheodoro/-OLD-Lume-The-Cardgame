using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUnitCard : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public UnitCard card;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;

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
    public void InitiateCard(UnitCard card)
    {
        this.card = card;

        art.sprite = this.card.art;
        cardIcon.sprite = this.card.cardIcon;
        nameBackground.color = this.card.nameBackground;
        descriptionBackground.color = this.card.descriptionBackground;
        nameText.text = this.card.cardName;
        descriptionText.text = this.card.description;
        flavorText.text = this.card.flavorText;
        healthText.text = this.card.health.ToString();
        strengthText.text = this.card.strength.ToString();
        agilityText.text = this.card.agility.ToString();
        wisdomText.text = this.card.wisdom.ToString();
        spiritText.text = this.card.spirit.ToString();
    }
    #endregion
}
