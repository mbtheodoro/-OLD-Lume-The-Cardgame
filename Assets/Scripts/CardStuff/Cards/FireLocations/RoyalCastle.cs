using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalCastle : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (string.Equals(player1Unit.name, "Princess Izumi", System.StringComparison.OrdinalIgnoreCase))
            player1Unit.ModifyHealth(-10, true);
        if (string.Equals(player2Unit.name, "Princess Izumi", System.StringComparison.OrdinalIgnoreCase))
            player2Unit.ModifyHealth(-10, true);
    }
}
