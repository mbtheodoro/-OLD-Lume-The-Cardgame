using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStoneWall : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        player1Unit.masteryStrength += 10;
        player2Unit.masteryStrength += 10;
    }

    public override void OnCombatEnd(UnitCard winner, UnitCard loser)
    {
        winner.masteryStrength -= 10;
        loser.masteryStrength -= 10;
    }
}
