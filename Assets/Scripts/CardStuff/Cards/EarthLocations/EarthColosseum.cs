using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthColosseum : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (player1Unit.currentStrength == player2Unit.currentStrength)
            return;

        if (player1Unit.currentStrength > player2Unit.currentStrength)
            player1Unit.ModifyHealth(-10, true);
        else if (player1Unit.currentStrength < player2Unit.currentStrength)
            player2Unit.ModifyHealth(-10, true);
    }
}
