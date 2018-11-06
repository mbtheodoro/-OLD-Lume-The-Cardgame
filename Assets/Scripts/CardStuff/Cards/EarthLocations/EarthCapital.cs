using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCapital : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if (player1Unit.nation == Nation.EARTH)
            player1Unit.currentStrength++;
        if (player2Unit.nation == Nation.EARTH)
            player2Unit.currentStrength++;
    }
}
