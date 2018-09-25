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

    //keywords
    private int _aggression;
    private int _analytic;

    private int _masteryStrength;
    private int _masteryAgility;
    private int _masteryWisdom;
    private int _masterySpirit;

    private int _weaken;
    private int _restrain;
    private int _hypnosis;
    private int _intimidate;

    private int _supportStrenght;
    private int _supportAgility;
    private int _supportWisdom;
    private int _supportSpirit;

    private int _infiltrate;

    private bool _berserk;
    private bool _overdrive;

    private int _armor;
    private int _endurance;

    private int _reckless;
    private int _regenerate;

    private bool _defiant;
    private bool _stubborn;
    private bool _piercer;
    private bool _taunt;
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
            currentHealth = Mathf.Max(0, value);
            healthText.text = currentHealth.ToString();
        }
    }

    public int CurrentStrength
    {
        get { return currentStrength; }

        set
        {
            currentStrength = Mathf.Max(0, value);
            strengthText.text = currentStrength.ToString();
        }
    }

    public int CurrentAgility
    {
        get { return currentAgility; }

        set
        {
            currentAgility = Mathf.Max(0, value);
            agilityText.text = currentAgility.ToString();
        }
    }

    public int CurrentWisdom
    {
        get { return currentWisdom; }

        set
        {
            currentWisdom = Mathf.Max(0, value);
            wisdomText.text = currentWisdom.ToString();
        }
    }

    public int CurrentSpirit
    {
        get { return currentSpirit; }

        set
        {
            currentSpirit = Mathf.Max(0, value);
            spiritText.text = currentSpirit.ToString();
        }
    }

    public int aggression
    {
        get
        {
            return _aggression;
        }

        set
        {
            _aggression = value;
        }
    }

    public int analytic
    {
        get
        {
            return _analytic;
        }

        set
        {
            _analytic = value;
        }
    }

    public int masteryStrength
    {
        get
        {
            return _masteryStrength;
        }

        set
        {
            _masteryStrength = value;
        }
    }

    public int masteryAgility
    {
        get
        {
            return _masteryAgility;
        }

        set
        {
            _masteryAgility = value;
        }
    }

    public int masteryWisdom
    {
        get
        {
            return _masteryWisdom;
        }

        set
        {
            _masteryWisdom = value;
        }
    }

    public int masterySpirit
    {
        get
        {
            return _masterySpirit;
        }

        set
        {
            _masterySpirit = value;
        }
    }

    public int weaken
    {
        get
        {
            return _weaken;
        }

        set
        {
            _weaken = value;
        }
    }

    public int restrain
    {
        get
        {
            return _restrain;
        }

        set
        {
            _restrain = value;
        }
    }

    public int hypnosis
    {
        get
        {
            return _hypnosis;
        }

        set
        {
            _hypnosis = value;
        }
    }

    public int intimidate
    {
        get
        {
            return _intimidate;
        }

        set
        {
            _intimidate = value;
        }
    }

    public int supportStrenght
    {
        get
        {
            return _supportStrenght;
        }

        set
        {
            _supportStrenght = value;
        }
    }

    public int supportAgility
    {
        get
        {
            return _supportAgility;
        }

        set
        {
            _supportAgility = value;
        }
    }

    public int supportWisdom
    {
        get
        {
            return _supportWisdom;
        }

        set
        {
            _supportWisdom = value;
        }
    }

    public int supportSpirit
    {
        get
        {
            return _supportSpirit;
        }

        set
        {
            _supportSpirit = value;
        }
    }

    public int infiltrate
    {
        get
        {
            return _infiltrate;
        }

        set
        {
            _infiltrate = value;
        }
    }

    public bool berserk
    {
        get
        {
            return _berserk;
        }

        set
        {
            _berserk = value;
        }
    }

    public bool overdrive
    {
        get
        {
            return _overdrive;
        }

        set
        {
            _overdrive = value;
        }
    }

    public int armor
    {
        get
        {
            return _armor;
        }

        set
        {
            _armor = value;
        }
    }

    public int endurance
    {
        get
        {
            return _endurance;
        }

        set
        {
            _endurance = value;
        }
    }

    public int reckless
    {
        get
        {
            return _reckless;
        }

        set
        {
            _reckless = value;
        }
    }

    public int regenerate
    {
        get
        {
            return _regenerate;
        }

        set
        {
            _regenerate = value;
        }
    }

    public bool defiant
    {
        get
        {
            return _defiant;
        }

        set
        {
            _defiant = value;
        }
    }

    public bool stubborn
    {
        get
        {
            return _stubborn;
        }

        set
        {
            _stubborn = value;
        }
    }

    public bool piercer
    {
        get
        {
            return _piercer;
        }

        set
        {
            _piercer = value;
        }
    }

    public bool taunt
    {
        get
        {
            return _taunt;
        }

        set
        {
            _taunt = value;
        }
    }
    #endregion

    #region METHODS
    public virtual void ModifyHealth(int value, bool gain=false)
    {
        if (value < 0) //heal
        {
            int temp = CurrentHealth - value;
            if (gain)
                CurrentHealth = temp;
            else
                CurrentHealth = Mathf.Max(CurrentHealth, temp);
        }
        else
            CurrentHealth -= value;
    }
    #endregion

    #region EVENTS
    public virtual void OnCombatStart(UnitCard enemy)
    {

    }

    public virtual void OnAttack(AttackCard attack, UnitCard enemy)
    {

    }

    public virtual void OnAttackTarget(AttackCard attack, UnitCard enemy)
    {

    }

    public virtual void OnCombatEnd()
    {

    }
    #endregion
}
