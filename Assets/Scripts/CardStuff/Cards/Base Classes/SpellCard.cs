using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellCard : Card
{
    #region REFERENCES
    public Text costText;
    #endregion

    #region ATTRIBUTES
    private int _originalCost;

    private int _currentCost;

    private int _baseDamage;
    #endregion

    #region PROPERTIES
    public int originalCost
    {
        get
        {
            return _originalCost;
        }

        set
        {
            _originalCost = value;
            currentCost = value;
        }
    }

    public int currentCost
    {
        get
        {
            return _currentCost;
        }

        set
        {
            _currentCost = value;
            costText.text = currentCost.ToString();
        }
    }
    #endregion
}
