using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCard : Card
{
    #region REFERENCES
    public Text costText;
    public Text baseDamageText;

    public UnitCard user;
    public UnitCard enemy;
    #endregion

    #region ATTRIBUTES
    private int _originalCost;
    private int _currentCost;
    private int _baseDamage;
    private AttackType _type;
    private AttackTarget _target;

    private Vector2 _statTestStrength;
    private Vector2 _statTestAgility;
    private Vector2 _statTestWisdom;
    private Vector2 _statTestSpirit;

    private Vector2 _outStatStrength;
    private Vector2 _outStatAgility;
    private Vector2 _outStatWisdom;
    private Vector2 _outStatSpirit;

    private Vector2 _statFailStrength;
    private Vector2 _statFailAgility;
    private Vector2 _statFailWisdom;
    private Vector2 _statFailSpirit;

    private int _modifyStrength;
    private int _modifyAgility;
    private int _modifyWisdom;
    private int _modifySpirit;
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
    
    public int baseDamage
    {
        get
        {
            return _baseDamage;
        }

        set
        {
            _baseDamage = value;
            baseDamageText.text = baseDamage.ToString();
        }
    }

    public Vector2 statTestStrength
    {
        get
        {
            return _statTestStrength;
        }

        set
        {
            _statTestStrength = value;
        }
    }

    public Vector2 statTestAgility
    {
        get
        {
            return _statTestAgility;
        }

        set
        {
            _statTestAgility = value;
        }
    }

    public Vector2 statTestWisdom
    {
        get
        {
            return _statTestWisdom;
        }

        set
        {
            _statTestWisdom = value;
        }
    }

    public Vector2 statTestSpirit
    {
        get
        {
            return _statTestSpirit;
        }

        set
        {
            _statTestSpirit = value;
        }
    }

    public Vector2 outStatStrength
    {
        get
        {
            return _outStatStrength;
        }

        set
        {
            _outStatStrength = value;
        }
    }

    public Vector2 outStatAgility
    {
        get
        {
            return _outStatAgility;
        }

        set
        {
            _outStatAgility = value;
        }
    }

    public Vector2 outStatWisdom
    {
        get
        {
            return _outStatWisdom;
        }

        set
        {
            _outStatWisdom = value;
        }
    }

    public Vector2 outStatSpirit
    {
        get
        {
            return _outStatSpirit;
        }

        set
        {
            _outStatSpirit = value;
        }
    }

    public Vector2 statFailStrength
    {
        get
        {
            return _statFailStrength;
        }

        set
        {
            _statFailStrength = value;
        }
    }

    public Vector2 statFailAgility
    {
        get
        {
            return _statFailAgility;
        }

        set
        {
            _statFailAgility = value;
        }
    }

    public Vector2 statFailWisdom
    {
        get
        {
            return _statFailWisdom;
        }

        set
        {
            _statFailWisdom = value;
        }
    }

    public Vector2 statFailSpirit
    {
        get
        {
            return _statFailSpirit;
        }

        set
        {
            _statFailSpirit = value;
        }
    }

    public int modifyStrength
    {
        get
        {
            return modifyStrength;
        }

        set
        {
            modifyStrength = value;
        }
    }

    public int modifyAgility
    {
        get
        {
            return modifyAgility;
        }

        set
        {
            modifyAgility = value;
        }
    }

    public int modifyWisdom
    {
        get
        {
            return modifyWisdom;
        }

        set
        {
            modifyWisdom = value;
        }
    }

    public int modifySpirit
    {
        get
        {
            return modifySpirit;
        }

        set
        {
            modifySpirit = value;
        }
    }

    public AttackType type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }

    public AttackTarget target
    {
        get
        {
            return _target;
        }

        set
        {
            _target = value;
        }
    }
    #endregion

    #region METHODS
    public virtual int CalculateDamage()
    {
        int damage = baseDamage;

        //stat tests
        if (statTestStrength.y > 0 && user.CurrentStrength > statTestStrength.x)
            damage += (int) statTestStrength.y;
        if (statTestAgility.y > 0 && user.CurrentAgility > statTestAgility.x)
            damage += (int) statTestAgility.y;
        if (statTestWisdom.y > 0 && user.CurrentWisdom > statTestWisdom.x)
            damage += (int)statTestWisdom.y;
        if (statTestSpirit.y > 0 && user.CurrentSpirit > statTestSpirit.x)
            damage += (int)statTestSpirit.y;

        //stat fails
        if (statFailStrength.y > 0 && enemy.CurrentStrength > statFailStrength.x)
            damage += (int)statFailStrength.y;
        if (statFailAgility.y > 0 && enemy.CurrentAgility > statFailAgility.x)
            damage += (int)statFailAgility.y;
        if (statFailWisdom.y > 0 && enemy.CurrentWisdom > statFailWisdom.x)
            damage += (int)statFailWisdom.y;
        if (statFailSpirit.y > 0 && enemy.CurrentSpirit > statFailSpirit.x)
            damage += (int)statFailSpirit.y;

        //outstats
        if (outStatStrength.y > 0 && user.CurrentStrength - enemy.CurrentStrength > outStatStrength.x)
            damage += (int)outStatStrength.y;
        if (outStatAgility.y > 0 && user.CurrentAgility - enemy.CurrentAgility > outStatAgility.x)
            damage += (int)outStatAgility.y;
        if (outStatWisdom.y > 0 && user.CurrentWisdom - enemy.CurrentWisdom > outStatWisdom.x)
            damage += (int)outStatWisdom.y;
        if (outStatSpirit.y > 0 && user.CurrentSpirit - enemy.CurrentSpirit > outStatSpirit.x)
            damage += (int)outStatSpirit.y;

        //TO DO: unit's combat modifiers


        return damage;
    }
    
    public virtual void Activate()
    {
        if(target == AttackTarget.USER)
        {
            user.ModifyHealth(CalculateDamage());
        }
        else
        {
            enemy.ModifyHealth(CalculateDamage());
        }

    }
    #endregion
}
