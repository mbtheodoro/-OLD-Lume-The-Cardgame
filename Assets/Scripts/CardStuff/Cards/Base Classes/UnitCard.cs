using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCard : Card
{
    #region REFERENCES
    public Text healthText;
    public Text strengthText;
    public Text agilityText;
    public Text wisdomText;
    public Text spiritText;
    #endregion

    #region ATTRIBUTES
    private int originalHealth;
    private int originalStrength;
    private int originalAgility;
    private int originalWisdom;
    private int originalSpirit;

    private int currentHealth;
    private int currentStrength;
    private int currentAgility;
    private int currentWisdom;
    private int currentSpirit;
    #endregion

    #region PROPERTIES
    public int OriginalHealth
    {
        get { return originalHealth; }

        set
        {
            originalHealth = value;
            CurrentHealth = value;
        }
    }

    public int OriginalStrength
    {
        get { return originalStrength; }

        set
        {
            originalStrength = value;
            CurrentStrength= value;
        }
    }

    public int OriginalAgility
    {
        get { return originalAgility;}

        set
        {
            originalAgility = value;
            CurrentAgility = value;
        }
    }

    public int OriginalWisdom
    {
        get { return originalWisdom; }

        set
        {
            originalWisdom = value;
            CurrentWisdom = value;
        }
    }

    public int OriginalSpirit
    {
        get { return originalSpirit; }

        set
        {
            originalSpirit = value;
            CurrentSpirit= value;
        }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }

        set
        {
            currentHealth = value;
            healthText.text = currentHealth.ToString();
        }
    }

    public int CurrentStrength
    {
        get { return currentStrength; }

        set
        {
            currentStrength = value;
            strengthText.text = currentStrength.ToString();
        }
    }

    public int CurrentAgility
    {
        get { return currentAgility; }

        set
        {
            currentAgility = value;
            agilityText.text = currentAgility.ToString();
        }
    }

    public int CurrentWisdom
    {
        get { return currentWisdom; }

        set
        {
            currentWisdom = value;
            wisdomText.text = currentWisdom.ToString();
        }
    }

    public int CurrentSpirit
    {
        get { return currentSpirit; }

        set
        {
            currentSpirit = value;
            spiritText.text = currentSpirit.ToString();
        }
    }
    #endregion
}
