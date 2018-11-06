using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthKingdomArmory : LocationCard
{
    UnitCard affectedCard1;
    UnitCard affectedCard2;

    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (player1Unit.nation == Nation.EARTH)
        {
            affectedCard1 = player1Unit;
            player1Unit.armor += 5;
        }
        if (player2Unit.nation == Nation.EARTH)
        {
            affectedCard2 = player2Unit;
            player2Unit.armor += 5;
        }
    }

    public override void OnCombatEnd(UnitCard winner, UnitCard loser)
    {
        if (affectedCard1 != null)
            affectedCard1.armor -= 5;
        if (affectedCard2 != null)
            affectedCard2.armor -= 5;
    }
}
