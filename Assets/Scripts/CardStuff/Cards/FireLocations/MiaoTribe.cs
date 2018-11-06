using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiaoTribe : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (player1Unit.currentAgility < 5)
        {
            player1Unit.currentStrength -= 1;
            player1Unit.currentSpirit -= 1;
        }
        if (player2Unit.currentAgility < 5)
        {
            player2Unit.currentStrength -= 1;
            player2Unit.currentSpirit -= 1;
        }
    }
}
