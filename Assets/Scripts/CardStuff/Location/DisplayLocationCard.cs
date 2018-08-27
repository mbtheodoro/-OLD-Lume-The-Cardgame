using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLocationCard : MonoBehaviour
{
    #region REFERENCES
    [HideInInspector] public LocationCard card;

    public Image art;
    public Image cardIcon;
    public Image nameBackground;
    public Image descriptionBackground;

    public Text nameText;
    public Text descriptionText;
    public Text flavorText;
    #endregion
}
