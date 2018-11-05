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

    #region METHODS
    public void Discard()
    {
        player.DiscardLocationCard(this);
    }
    #endregion

    #region EVENTS
    public virtual void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {

    }

    public virtual void OnAttackCardPlayed(AttackCard attack, UnitCard user, UnitCard enemy)
    {

    }

    public virtual void OnCombatEnd(UnitCard winner, UnitCard loser)
    {

    }

    public virtual void OnAttackTurnStart(UnitCard player1Unit, UnitCard player2Unit)
    {

    }

    public virtual void OnAttackTurnEnd(UnitCard player1Unit, UnitCard player2Unit)
    {

    }
    #endregion

    #region OVERIDES
    #endregion

    #region UNITY
    #endregion
}
