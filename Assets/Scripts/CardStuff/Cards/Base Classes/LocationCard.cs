using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCard : Card
{
    #region REFERENCES
    #endregion

    #region ATTRIBUTES
    private Initiative _initiative;
    #endregion

    #region PROPERTIES
    public Initiative initiative
    {
        get
        {
            return _initiative;
        }

        set
        {
            _initiative = value;
        }
    }
    #endregion

    #region EVENTS
    public virtual void OnCombatStart(UnitCard player1, UnitCard player2)
    {

    }

    public virtual void OnAttackCardPlayed(AttackCard attack, UnitCard user, UnitCard enemy)
    {

    }

    public virtual void OnCombatEnd(UnitCard winner, UnitCard loser)
    {

    }
    #endregion

    #region OVERIDES
    #endregion

    #region UNITY
    #endregion
}
