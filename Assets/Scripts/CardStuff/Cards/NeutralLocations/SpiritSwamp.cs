using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSwamp : LocationCard
{
    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        player1Unit.masterySpirit += 10;
        player2Unit.masterySpirit += 10;
    }

    public override void OnCombatEnd(UnitCard player1Unit, UnitCard player2Unit)
    {
        player1Unit.masterySpirit -= 10;
        player2Unit.masterySpirit -= 10;

        player.DiscardLocationCard(this);
    }
}
