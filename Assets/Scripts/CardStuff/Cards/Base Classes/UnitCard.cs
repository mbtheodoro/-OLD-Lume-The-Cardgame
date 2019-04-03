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

    public EquipCard equip;
    #endregion

    #region ATTRIBUTES
    protected Color regularTextColor;

    private int _originalHealth;
    private int _originalStrength;
    private int _originalAgility;
    private int _originalWisdom;
    private int _originalSpirit;

    private int _currentHealth;
    private int _currentStrength;
    private int _currentAgility;
    private int _currentWisdom;
    private int _currentSpirit;

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
    public int originalHealth
    {
        get { return _originalHealth; }

        set
        {
            _originalHealth = value;
            _currentHealth = value;
            regularTextColor = healthText.color;
            healthText.text = _originalHealth.ToString();
        }
    }

    public int originalStrength
    {
        get { return _originalStrength; }

        set
        {
            _originalStrength = value;
            _currentStrength = value;
            strengthText.text = _originalStrength.ToString();
        }
    }

    public int originalAgility
    {
        get { return _originalAgility; }

        set
        {
            _originalAgility = value;
            _currentAgility = value;
            agilityText.text = _originalAgility.ToString();
        }
    }

    public int originalWisdom
    {
        get { return _originalWisdom; }

        set
        {
            _originalWisdom = value;
            _currentWisdom = value;
            wisdomText.text = _originalWisdom.ToString();
        }
    }

    public int originalSpirit
    {
        get { return _originalSpirit; }

        set
        {
            _originalSpirit = value;
            _currentSpirit = value;
            spiritText.text = _originalSpirit.ToString();
        }
    }

    public int currentHealth
    {
        get { return _currentHealth; }

        set
        {
            _currentHealth = Mathf.Max(0, value);
            healthText.text = _currentHealth.ToString();


            if (currentHealth > originalHealth)
                healthText.color = Color.green;
            else if (currentHealth < originalHealth && currentHealth > Defines.criticalHp)
                healthText.color = new Color(1.0f, 0.5f, 0.0f);
            else if (currentHealth <= Defines.criticalHp)
                healthText.color = Color.red;
            else
                healthText.color = regularTextColor;
        }
    }

    public int currentStrength
    {
        get { return _currentStrength; }

        set
        {
            if (value < _currentStrength)
            {
                if (defiant)
                    LogWindow.Log(name + "'s Defiant prevents its stat from getting lowered.");
                else
                {
                    if (_currentStrength == 0)
                        LogWindow.Log(name + "'s Strength can't get any lower!");
                    else
                    {
                        LogWindow.Log(name + "'s Strength is reduced by " + (_currentStrength - value));
                        _currentStrength = value;
                        if (_currentStrength < _originalStrength)
                            strengthText.color = Color.red;
                    }
                }
            }
            else if (value > _currentStrength)
            {
                LogWindow.Log(name + "'s Strength is increased by " + (value - _currentStrength));
                _currentStrength = value;
                if (_currentStrength > _originalStrength)
                    strengthText.color = Color.green;
            }

            strengthText.text = _currentStrength.ToString();
        }
    }

    public int currentAgility
    {
        get { return _currentAgility; }

        set
        {
            if (value < _currentAgility)
            {
                if (defiant)
                    LogWindow.Log(name + "'s Defiant prevents its stat from getting lowered.");
                else
                {
                    if (_currentAgility == 0)
                        LogWindow.Log(name + "'s Agility can't get any lower!");
                    else
                    {
                        LogWindow.Log(name + "'s Agility is reduced by " + (_currentAgility - value));
                        _currentAgility = value;
                        if (_currentAgility < originalAgility)
                            agilityText.color = Color.red;
                    }
                }
            }
            else if (value > _currentAgility)
            {
                LogWindow.Log(name + "'s Agility is increased by " + (value - _currentAgility));
                _currentAgility = value;
                if (_currentAgility > originalAgility)
                    agilityText.color = Color.green;
            }

            agilityText.text = _currentAgility.ToString();
        }
    }

    public int currentWisdom
    {
        get { return _currentWisdom; }

        set
        {
            if (value < _currentWisdom)
            {
                if (defiant)
                    LogWindow.Log(name + "'s Defiant prevents its stat from getting lowered.");
                else
                {
                    if (_currentWisdom == 0)
                        LogWindow.Log(name + "'s Wisdom can't get any lower!");
                    else
                    {
                        LogWindow.Log(name + "'s Wisdom is reduced by " + (_currentWisdom - value));
                        _currentWisdom = value;
                        if (_currentWisdom < originalWisdom)
                            wisdomText.color = Color.red;
                    }
                }
            }
            else if (value > _currentWisdom)
            {
                LogWindow.Log(name + "'s Wisdom is increased by " + (value - _currentWisdom));
                _currentWisdom = value;
                if (_currentWisdom > originalWisdom)
                    wisdomText.color = Color.green;
            }

            wisdomText.text = _currentWisdom.ToString();
        }
    }

    public int currentSpirit
    {
        get { return _currentSpirit; }

        set
        {
            if (value < _currentSpirit)
            {
                if (defiant)
                    LogWindow.Log(name + "'s Defiant prevents its stat from getting lowered.");
                else
                {
                    if (_currentSpirit == 0)
                        LogWindow.Log(name + "'s Spirit can't get any lower!");
                    else
                    {
                        LogWindow.Log(name + "'s Spirit is reduced by "+(_currentSpirit - value));
                        _currentSpirit = value;
                        if (_currentSpirit < originalSpirit)
                            spiritText.color = Color.red;
                    }
                }
            }
            else if (value > _currentSpirit)
            {
                LogWindow.Log(name + "'s Spirit is increased by " + (value - _currentSpirit));
                _currentSpirit = value;
                if (_currentSpirit > originalSpirit)
                    spiritText.color = Color.green;
            }
                
            spiritText.text = _currentSpirit.ToString();
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
    public virtual int ModifyHealth(int value, bool gain=false)
    {
        int oldHealth = currentHealth;
        int temp = currentHealth - value;

        if (value < 0 && currentHealth < originalHealth) //heal && health below original
        {
            if (gain)
                currentHealth = temp;
            else
                currentHealth = Mathf.Min(originalHealth, temp); //can't heal past original health without gain
        }
        else
        {
            if (value < 0 && currentHealth >= originalHealth) //heal but already gained health
            {
                if (gain)
                    currentHealth = temp;
            }
            else 
            {
                if(value > 0) //normal damage
                    currentHealth = temp;
            }
        }

        return currentHealth - oldHealth;
    }

    protected void Weaken(UnitCard enemy)
    {
        if(weaken > 0)
        {
            LogWindow.Log(name + "'s Weaken activates");
            enemy.currentStrength -= weaken;
        }
    }

    protected void Restrain(UnitCard enemy)
    {
        if (restrain > 0)
        {
            LogWindow.Log(name + "'s Restrain activates");
            enemy.currentAgility -= restrain;
        }
    }

    protected void Hypnosis(UnitCard enemy)
    {
        if (hypnosis > 0)
        {
            LogWindow.Log(name + "'s Hypnosis activates");
            enemy.currentWisdom -= hypnosis;
        }
    }

    protected void Intimidate(UnitCard enemy)
    {
        if (intimidate > 0)
        {
            LogWindow.Log(name + "'s Intimidate activates");
            enemy.currentSpirit -= intimidate;
        }
    }

    protected void Reckless()
    {
        if(reckless > 0)
        {
            LogWindow.Log(name + " is Reckless and deals "+reckless+" damage to itself");
            ModifyHealth(reckless);
        }
    }
    
    protected void Regenerate()
    {
        if(regenerate > 0)
        {
            LogWindow.Log(name + " is Regenerate healed " + regenerate + " HP");
            ModifyHealth(-regenerate);
        }
    }

    protected void Support()
    {
        //int supportingUnits = BoardController.GetSupportingUnits(this);
    }
    
    public bool Infiltrated()
    {
        int tile = BoardController.instance.selectedTile.id;
        Debug.Log("infiltrate test: tile = " + tile);
        if (player.player == PlayerInfo.PLAYER1)
        {
            if (tile > 9)
                return true;
            return false;
        }
        else
        {
            if (tile < 6)
                return true;
            return false;
        }
    }
    
    public virtual int UserDamageModifiers(int damage, AttackCard attack, UnitCard target, bool heal = false)
    {
        if (!heal)
        {
            if (attack.type == AttackType.PHYSICAL)
            {
                //aggresion
                damage += aggression;

                //berserk
                if (currentHealth <= Defines.criticalHp && berserk)
                    damage *= Defines.criticalHpMultiplier;
            }
            else //type == AttackType.MAGICAL
            {
                //analytic
                damage += analytic;

                //overdrive
                if (currentHealth <= Defines.criticalHp && overdrive)
                    damage *= Defines.criticalHpMultiplier;
            }

            if (infiltrate > 0 && Infiltrated())
                damage += infiltrate;
        }

        return damage;
    }

    public virtual int TargetDamageModifiers(int damage, AttackCard attack, UnitCard attacker, bool heal = false)
    {
        if (!heal)
        {
            if (attack.type == AttackType.PHYSICAL)
                damage -= armor; //armor
            else //type == AttackType.MAGICAL
                damage -= endurance; //endurance
        }

        return Mathf.Max(damage, 0);
    }
    #endregion

    #region EVENTS
    public virtual void OnTurnStart()
    {

    }

    public virtual void OnUnitMoved(UnitCard unit, Tile tile)
    {

    }

    public virtual void OnCombatStart(UnitCard enemy)
    {
        Weaken(enemy);
        Restrain(enemy);
        Hypnosis(enemy);
        Intimidate(enemy);
        Support();
    }

    public virtual void OnAttackTurnStart()
    {

    }

    public virtual void OnAttackCardPlayed(AttackCard attack, UnitCard enemy)
    {
        Reckless();
    }

    public virtual void OnAttackCardTarget(AttackCard attack, UnitCard enemy)
    {

    }

    public virtual void OnAttackTurnEnd()
    {

    }

    public virtual void OnCombatEnd()
    {
        if (currentHealth <= 0)
        {
            player.DiscardUnitCard(this);
        }
        else
            Regenerate();
    }

    public virtual void OnTurnEnd()
    {

    }
    
    #endregion
}
