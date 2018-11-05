using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalCastle : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (player1Unit.name.Equals("Princess Izumi"))
            player1Unit.ModifyHealth(-10, true);
        if (player2Unit.name.Equals("Princess Izumi"))
            player2Unit.ModifyHealth(-10, true);
    }
}
