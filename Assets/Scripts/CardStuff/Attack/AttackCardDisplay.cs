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
}
