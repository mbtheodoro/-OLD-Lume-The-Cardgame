using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilithsPool : LocationCard
{
    public override void OnAttackCardPlayed(AttackCard attack, UnitCard user, UnitCard enemy)
    {
        if (attack is HealAttackCard)
            user.ModifyHealth(-10);
    }
}
