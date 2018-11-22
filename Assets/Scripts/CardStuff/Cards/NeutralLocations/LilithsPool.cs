using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilithsPool : LocationCard
{
    public override int DamageModifiers(int damage, AttackCard attack, UnitCard user, UnitCard enemy, bool heal = false)
    {
        if (attack is HealAttackCard)
            return damage + 10;
        return damage;
    }
}
