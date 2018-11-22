using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationCard : Card
{
    #region REFERENCES
    #endregion

    #region ATTRIBUTES
    private Initiative _initiative;
    #endregion

    #region PROPERTIES
    public Initiative initiative
    {
        get { return _initiative; }

        set { _initiative = value; }
    }
    #endregion

    #region METHODS
    public void Discard()
    {
        player.DiscardLocationCard(this);
    }

    public PlayerInfo CalculateInitiative(UnitCard player1Card, UnitCard player2Card)
    {
        PlayerInfo turn;
        switch (initiative)
        {
            case Initiative.NONTURNPLAYER:
                turn = GameController.turnPlayer;
                if (turn == PlayerInfo.PLAYER1)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = PlayerInfo.PLAYER1;
                break;

            case Initiative.STRENGTH:
                if (player1Card.currentStrength > player2Card.currentStrength)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.currentStrength < player2Card.currentStrength)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.AGILITY:
                if (player1Card.currentAgility > player2Card.currentAgility)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.currentAgility < player2Card.currentAgility)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.WISDOM:
                if (player1Card.currentWisdom > player2Card.currentWisdom)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.currentWisdom < player2Card.currentWisdom)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.SPIRIT:
                if (player1Card.currentSpirit > player2Card.currentSpirit)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.currentSpirit < player2Card.currentSpirit)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.HEALTH:
                if (player1Card.currentHealth > player2Card.currentHealth)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.currentHealth < player2Card.currentHealth)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.WATER:
                if (player1Card.nation == Nation.WATER && player2Card.nation == Nation.WATER)
                    turn = GameController.turnPlayer;
                else if (player1Card.nation == Nation.WATER)
                    turn = PlayerInfo.PLAYER1;
                else
                    turn = PlayerInfo.PLAYER2;
                break;

            case Initiative.EARTH:
                if (player1Card.nation == Nation.EARTH && player2Card.nation == Nation.EARTH)
                    turn = GameController.turnPlayer;
                else if (player1Card.nation == Nation.EARTH)
                    turn = PlayerInfo.PLAYER1;
                else
                    turn = PlayerInfo.PLAYER2;
                break;

            case Initiative.FIRE:
                if (player1Card.nation == Nation.FIRE && player2Card.nation == Nation.FIRE)
                    turn = GameController.turnPlayer;
                else if (player1Card.nation == Nation.FIRE)
                    turn = PlayerInfo.PLAYER1;
                else
                    turn = PlayerInfo.PLAYER2;
                break;

            default:
                turn = GameController.turnPlayer;
                break;
        }
        return turn;
    }
    
    public virtual int DamageModifiers(int damage, UnitCard attacker, UnitCard defender, bool heal = false)
    {
        return damage;
    }
    #endregion

    #region EVENTS
    public virtual void OnCombatStart(UnitCard player1Unit, UnitCard player2Unit)
    {

    }

    public virtual void OnAttackTurnStart(UnitCard player1Unit, UnitCard player2Unit)
    {

    }

    public virtual void OnAttackCardPlayed(AttackCard attack, UnitCard user, UnitCard enemy)
    {

    }

    public virtual void OnAttackTurnEnd(UnitCard player1Unit, UnitCard player2Unit)
    {

    }

    public virtual void OnCombatEnd(UnitCard winner, UnitCard loser)
    {

    }
    #endregion
}
