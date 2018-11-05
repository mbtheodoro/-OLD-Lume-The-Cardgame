using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempleOfSailaNole : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (player1Unit.currentWisdom >= 5)
            player1Unit.ModifyHealth(-5, true);
        if (player2Unit.currentWisdom >= 5)
            player2Unit.ModifyHealth(-5, true);
    }
}
