using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCapital : LocationCard
{
    public override void OnCombatStart(UnitCard player1, UnitCard player2)
    {
        if (player1.nation == Nation.WATER)
            player1.ModifyHealth(-10, true);
        if (player2.nation == Nation.WATER)
            player2.ModifyHealth(-10, true);
    }
}
