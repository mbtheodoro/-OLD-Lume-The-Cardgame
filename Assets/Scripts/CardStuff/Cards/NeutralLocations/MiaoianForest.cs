using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiaoianForest : LocationCard
{
    UnitCard affectedCard;

    public override void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        if(player1Unit.currentWisdom == player2Unit.currentWisdom)
            return;

        if (player1Unit.currentWisdom > player2Unit.currentWisdom)
            affectedCard = player1Unit;
        else if (player1Unit.currentWisdom < player2Unit.currentWisdom)
            affectedCard = player2Unit;

        affectedCard.masteryAgility += 5;
    }

    public override void OnCombatEnd(UnitCard winner, UnitCard loser)
    {
        if (affectedCard != null)
        {
            affectedCard.masteryAgility -= 5;
        }
    }
}
