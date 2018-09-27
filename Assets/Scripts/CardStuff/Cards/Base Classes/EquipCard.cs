using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCard : Card
{
    #region REFERENCES
    public UnitCard unit;
    #endregion

    #region EVENTS
    public virtual void OnEquip()
    {

    }

    public virtual void OnDiscard()
    {

    }

    public virtual void OnCombatStart(UnitCard enemy, LocationCard location)
    {

    }

    public virtual void OnAttackCardPlayed(AttackCard attack, UnitCard enemy)
    {

    }

    public virtual void OnCombatEnd(UnitCard winner, UnitCard loser)
    {

    }
    #endregion
}
