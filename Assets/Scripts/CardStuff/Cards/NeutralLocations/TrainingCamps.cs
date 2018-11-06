using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingCamps : LocationCard
{
    public override void OnAttackCardPlayed(AttackCard attack, UnitCard user, UnitCard enemy)
    {
        if (attack.modifyUserStrength > 0)
            user.currentStrength++;
        if (attack.modifyUserAgility > 0)
            user.currentAgility++;
        if (attack.modifyUserWisdom > 0)
            user.currentWisdom++;
        if (attack.modifyUserSpirit> 0)
            user.currentSpirit++;
    }
}
