using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCapital : LocationCard
{
    public override void OnAttackTurnStart(UnitCard player1Unit, UnitCard player2Unit)
    {
        PlayerController player1Controler = GameController.GetPlayerController(PlayerInfo.PLAYER1);
        PlayerController player2Controler = GameController.GetPlayerController(PlayerInfo.PLAYER2);

        foreach (AttackCard attack in player1Controler.attacksOnHand)
        {
            if (attack.nation == Nation.FIRE)
                attack.currentCost = attack.originalCost - 5;
        }

        foreach (AttackCard attack in player2Controler.attacksOnHand)
        {
            if (attack.nation == Nation.FIRE)
                attack.currentCost = attack.originalCost - 5;
        }
    }

    public override void OnCombatEnd(UnitCard winner, UnitCard loser)
    {
        PlayerController player1Controler = GameController.GetPlayerController(PlayerInfo.PLAYER1);
        PlayerController player2Controler = GameController.GetPlayerController(PlayerInfo.PLAYER2);

        foreach (AttackCard attack in player1Controler.attacksOnHand)
        {
            attack.currentCost = attack.originalCost;
        }

        foreach (AttackCard attack in player2Controler.attacksOnHand)
        {
            attack.currentCost = attack.originalCost;
        }
    }
}
