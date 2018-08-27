using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayEquipCard : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public EquipCard card;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;

    public Text nameText;
    public Text descriptionText;
    public Text flavorText;
    #endregion
}
