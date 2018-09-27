using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AttackCard : Card
{
    #region REFERENCES
    public UnitCard user;
    public UnitCard enemy;

    public new BoxCollider2D collider;
    private AspectRatioFitter aspectRatioFitter;

    public Text costText;
    public Text baseDamageText;
    #endregion

    #region ATTRIBUTES
    private int _originalCost;
    private int _currentCost;
    private int _baseDamage;
    private AttackType _type;

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

    private int _modifyUserStrength;
    private int _modifyUserAgility;
    private int _modifyUserWisdom;
    private int _modifyUserSpirit;

    private int _modifyEnemyStrength;
    private int _modifyEnemyAgility;
    private int _modifyEnemyWisdom;
    private int _modifyEnemySpirit;
    #endregion

    #region PROPERTIES
    public virtual int originalCost
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

    public virtual int currentCost
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
    
    public virtual int baseDamage
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

    public virtual Vector2 statTestStrength
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

    public virtual Vector2 statTestAgility
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

    public virtual Vector2 statTestWisdom
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

    public virtual Vector2 statTestSpirit
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

    public virtual Vector2 outStatStrength
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

    public virtual Vector2 outStatAgility
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

    public virtual Vector2 outStatWisdom
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

    public virtual Vector2 outStatSpirit
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

    public virtual Vector2 statFailStrength
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

    public virtual Vector2 statFailAgility
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

    public virtual Vector2 statFailWisdom
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

    public virtual Vector2 statFailSpirit
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

    public virtual int modifyUserStrength
    {
        get
        {
            return _modifyUserStrength;
        }

        set
        {
            _modifyUserStrength = value;
        }
    }

    public virtual int modifyUserAgility
    {
        get
        {
            return _modifyUserAgility;
        }

        set
        {
            _modifyUserAgility = value;
        }
    }

    public virtual int modifyUserWisdom
    {
        get
        {
            return _modifyUserWisdom;
        }

        set
        {
            _modifyUserWisdom = value;
        }
    }

    public virtual int modifyUserSpirit
    {
        get
        {
            return _modifyUserSpirit;
        }

        set
        {
            _modifyUserSpirit = value;
        }
    }

    public virtual int modifyEnemyStrength
    {
        get
        {
            return _modifyEnemyStrength;
        }

        set
        {
            _modifyEnemyStrength = value;
        }
    }

    public virtual int modifyEnemyAgility
    {
        get
        {
            return _modifyEnemyAgility;
        }

        set
        {
            _modifyEnemyAgility = value;
        }
    }

    public virtual int modifyEnemyWisdom
    {
        get
        {
            return _modifyEnemyWisdom;
        }

        set
        {
            _modifyEnemyWisdom = value;
        }
    }

    public virtual int modifyEnemySpirit
    {
        get
        {
            return _modifyEnemySpirit;
        }

        set
        {
            _modifyEnemySpirit = value;
        }
    }

    public virtual AttackType type
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
    #endregion

    #region METHODS
    protected virtual int StatBasedDamageCalculation()
    {
        int damage = 0;

        //stat tests
        if (statTestStrength.y > 0 && user.currentStrength >= statTestStrength.x)
        {
            damage += (int)statTestStrength.y;
            damage += user.masteryStrength; //mastery
        }
        if (statTestAgility.y > 0 && user.currentAgility >= statTestAgility.x)
        {
            damage += (int)statTestAgility.y;
            damage += user.masteryAgility; //mastery
        }
        if (statTestWisdom.y > 0 && user.currentWisdom >= statTestWisdom.x)
        {
            damage += (int)statTestWisdom.y;
            damage += user.masteryWisdom; //mastery
        }
        if (statTestSpirit.y > 0 && user.currentSpirit >= statTestSpirit.x)
        {
            damage += (int)statTestSpirit.y;
            damage += user.masterySpirit; //mastery
        }

        //stat fails
        if (statFailStrength.y > 0 && enemy.currentStrength < statFailStrength.x)
            damage += (int)statFailStrength.y;
        if (statFailAgility.y > 0 && enemy.currentAgility < statFailAgility.x)
            damage += (int)statFailAgility.y;
        if (statFailWisdom.y > 0 && enemy.currentWisdom < statFailWisdom.x)
            damage += (int)statFailWisdom.y;
        if (statFailSpirit.y > 0 && enemy.currentSpirit < statFailSpirit.x)
            damage += (int)statFailSpirit.y;

        //outstats
        if (outStatStrength.y > 0 && user.currentStrength - enemy.currentStrength >= outStatStrength.x)
        {
            damage += (int)outStatStrength.y;
            damage += user.masteryStrength; //mastery
        }
        if (outStatAgility.y > 0 && user.currentAgility - enemy.currentAgility >= outStatAgility.x)
        {
            damage += (int)outStatAgility.y;
            damage += user.masteryAgility; //mastery
        }
        if (outStatWisdom.y > 0 && user.currentWisdom - enemy.currentWisdom >= outStatWisdom.x)
        {
            damage += (int)outStatWisdom.y;
            damage += user.masteryWisdom; //mastery
        }
        if (outStatSpirit.y > 0 && user.currentSpirit - enemy.currentSpirit >= outStatSpirit.x)
        {
            damage += (int)outStatSpirit.y;
            damage += user.masterySpirit; //mastery
        }

        return damage;
    }

    protected virtual int UserDamageModifiers(int damage)
    {
        if (type == AttackType.PHYSICAL)
        {
            //aggresion
            damage += user.aggression;

            //berserk
            if (user.currentHealth <= Defines.criticalHp && user.berserk)
                damage *= Defines.criticalHpMultiplier;
        }
        else //type == AttackType.MAGICAL
        {
            //analytic
            damage += user.analytic;

            //overdrive
            if (user.currentHealth <= Defines.criticalHp && user.overdrive)
                damage *= Defines.criticalHpMultiplier;
        }

        return damage;
    }

    protected virtual int EnemyDamageModifiers(int damage)
    {
        if (type == AttackType.PHYSICAL)
            damage -= enemy.armor; //armor
        else //type == AttackType.MAGICAL
            damage -= enemy.endurance; //endurance

        return damage;
    }

    public virtual int CalculateDamage()
    {
        int damage = baseDamage;

        damage += StatBasedDamageCalculation();
        
        damage = UserDamageModifiers(damage);
        damage = EnemyDamageModifiers(damage);

        return damage;
    }
    
    public virtual void SetUserEnemy()
    {
        user = CombatController.attackingUnit;
        enemy = CombatController.defendingUnit;
    }

    public void ModifyUserStats()
    {
        user.currentStrength += modifyUserStrength;
        user.currentAgility += modifyUserAgility;
        user.currentWisdom += modifyUserWisdom;
        user.currentSpirit += modifyUserSpirit;
    }

    public void ModifyEnemyStats()
    {
        enemy.currentStrength += modifyEnemyStrength;
        enemy.currentAgility += modifyEnemyAgility;
        enemy.currentWisdom += modifyEnemyWisdom;
        enemy.currentSpirit += modifyEnemySpirit;
    }

    public virtual void Activate()
    {
        SetUserEnemy();

        //deal damage
        int damage = CalculateDamage();
        enemy.ModifyHealth(damage);
        Debug.Log(user.name + " used " + name + " on " + enemy.name + " and dealt " + damage + " damage!");

        //modifying status come after damage
        ModifyUserStats();
        ModifyEnemyStats();

        //callbacks
        CombatController.instance.location.OnAttackCardPlayed(this, user, enemy); //first resolve location effects
        user.OnAttack(this, enemy); //then resolve user
        enemy.OnAttackTarget(this, user); //then resolve enemy
        player.OnAttackCardPlayed(this); //then discard card and draw a new one
        CombatController.OnAttackCardPlayed(); //and finally, switch turns
    }
    #endregion

    #region OVERIDES
    public override void SetParent(RectTransform parent)
    {
        base.SetParent(parent);
        collider.size = new Vector2(parent.sizeDelta.y * aspectRatioFitter.aspectRatio, parent.sizeDelta.y);
    }
    #endregion

    #region UNITY
    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        aspectRatioFitter = GetComponent<AspectRatioFitter>();
    }

    private void OnMouseUpAsButton()
    {
        Activate();
    }
    #endregion
}
