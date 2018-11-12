using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    #region SINGLETON
    private static CombatController _instance;
    public static CombatController instance
    {
        get { return _instance; }
    }
    #endregion

    #region REFERENCES  
    [SerializeField] private RectTransform player1Rect;
    [SerializeField] private RectTransform player2Rect;
    [SerializeField] private RectTransform locationRect;

    public UnitCard player1Card;
    public UnitCard player2Card;
    public LocationCard location;
    #endregion

    #region ATTRIBUTES
    private PlayerInfo _turn;
    #endregion

    #region PROPERTIES
    public PlayerInfo turn
    {
        get
        {
            return _turn;
        }

        set
        {
            _turn = value;
        }
    }

    public static UnitCard attackingUnit
    {
        get
        {
            if (instance.turn == PlayerInfo.PLAYER1)
                return instance.player1Card;
            else
                return instance.player2Card;
        }
    }

    public static UnitCard defendingUnit
    {
        get
        {
            if (instance.turn == PlayerInfo.PLAYER1)
                return instance.player2Card;
            else
                return instance.player1Card;
        }
    }
    #endregion

    #region METHODS
    private void SwitchTurn()
    {
        OnAttackTurnEnd();

        if (instance.turn == PlayerInfo.PLAYER1)
            instance.turn = PlayerInfo.PLAYER2;
        else
            instance.turn = PlayerInfo.PLAYER1;

        LogWindow.Log("Now " + turn + " gets to attack!");

        OnAttackTurnStart();

        GameController.GetPlayerController(instance.turn).EnableCardsOnHand();
    }

    private void CalculateInitiative()
    {
        switch (location.initiative)
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
    }

    public static void StartCombat(LocationCard locationCard, UnitCard p1, UnitCard p2)
    {
        instance.gameObject.SetActive(true);

        instance.location = locationCard;
        instance.player1Card = p1;
        instance.player2Card = p2;

        instance.location.SetParent(instance.locationRect);
        instance.player1Card.SetParent(instance.player1Rect);
        instance.player2Card.SetParent(instance.player2Rect);

        instance.turn = locationCard.CalculateInitiative(instance.player1Card, instance.player2Card);

        instance.OnCombatStart();
        instance.OnAttackTurnStart();
    }
    #endregion

    #region EVENTS
    private void OnCombatStart()
    {
        LogWindow.Log("Combat Started! It's " + player1Card.name + " Vs " + player2Card.name + " on " + location.name + "!");
        LogWindow.Log(turn + "'s got the advantage!");

        //other controllers
        GameController.OnCombatStart();
        BoardController.OnCombatStart();

        //players
        GameController.GetPlayerController(PlayerInfo.PLAYER1).OnCombatStart();
        GameController.GetPlayerController(PlayerInfo.PLAYER2).OnCombatStart();
        
        //cards
        location.OnCombatStart(player1Card, player2Card);
        player1Card.OnCombatStart(player2Card);
        player2Card.OnCombatStart(player1Card);
    }

    private void OnAttackTurnStart()
    {
        location.OnAttackTurnStart(player1Card, player2Card);
        GameController.GetPlayerController(instance.turn).OnAttackTurnStart();
        //maybe other cards
    }

    public static void OnAttackCardPlayed()
    {
        if (defendingUnit.currentHealth <= 0 && attackingUnit.currentHealth <= 0)
            instance.OnCombatEnd(false, true); //draw
        if (defendingUnit.currentHealth <= 0)
            instance.OnCombatEnd(); //attacker wins
        else if (attackingUnit.currentHealth <= 0)
            instance.OnCombatEnd(true, false); //suicide (reckless)
        else
            instance.SwitchTurn();
    }

    private void OnAttackTurnEnd()
    {
        location.OnAttackTurnEnd(player1Card, player2Card);
        GameController.GetPlayerController(instance.turn).OnAttackTurnEnd();
        //maybe other cards
    }

    private void OnCombatEnd(bool suicide = false, bool draw = false)
    {
        UnitCard winner = attackingUnit;
        UnitCard loser = defendingUnit;

        if (draw) //they both died
        {
            winner = null;
            loser = null;
        }

        if (suicide) //swap winner and loser
        {
            winner = defendingUnit;
            loser = attackingUnit;
        }

        if (winner != null)
            LogWindow.Log("Combat Ended! " + winner.name + " is victorious!");
        else
            LogWindow.Log("Combat Ended! No one came out victorious!");

        gameObject.SetActive(false);

        location.OnCombatEnd(winner, loser);

        player1Card.OnCombatEnd();
        player2Card.OnCombatEnd();

        GameController.GetPlayerController(PlayerInfo.PLAYER1).OnCombatEnd();
        GameController.GetPlayerController(PlayerInfo.PLAYER2).OnCombatEnd();

        BoardController.OnCombatEnd(winner);

        GameController.OnCombatEnd();
    }
    #endregion

    #region UNITY
    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;
            gameObject.SetActive(false);
        }
        else
            DestroyImmediate(gameObject);
    }
    #endregion
}
