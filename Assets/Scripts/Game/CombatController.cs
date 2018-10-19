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
        if (instance.turn == PlayerInfo.PLAYER1)
            instance.turn = PlayerInfo.PLAYER2;
        else
            instance.turn = PlayerInfo.PLAYER1;
        
        Debug.Log("Now it's " + turn + "'s turn!");
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
                //TO DO:
                break;

            case Initiative.EARTH:
                //TO DO:
                break;

            case Initiative.FIRE:
                //TO DO:
                break;

            default:
                turn = GameController.turnPlayer;
                break;
        }
    }

    public void StartCombat(LocationCard l, UnitCard p1, UnitCard p2)
    {
        gameObject.SetActive(true);

        location = l;
        player1Card = p1;
        player2Card = p2;

        location.SetParent(instance.locationRect);
        player1Card.SetParent(instance.player1Rect);
        player2Card.SetParent(instance.player2Rect);

        CalculateInitiative();

        OnCombatStart();
    }
    #endregion

    #region EVENTS
    public static void OnAttackCardPlayed()
    {
        if(defendingUnit.currentHealth <= 0)
            instance.OnCombatEnd();
        else
            instance.SwitchTurn();
    }

    private void OnCombatStart()
    {
        Debug.Log("Combat Started! It's " + player1Card.name + " Vs " + player2Card.name + " on " + location.name + "!");
        Debug.Log(turn + "'s got the advantage!");

        location.OnCombatStart(player1Card, player2Card);
        player1Card.OnCombatStart(player2Card);
        player2Card.OnCombatStart(player1Card);
        GameController.GetPlayerController(instance.turn).EnableCardsOnHand();
        //TO DO: other controllers?
    }

    private void OnCombatEnd()
    {
        Debug.Log("Combat Ended! " + attackingUnit.name + " is victorious!");
        gameObject.SetActive(false);

        location.OnCombatEnd(attackingUnit, defendingUnit);
        player1Card.OnCombatEnd();
        player2Card.OnCombatEnd();
        //TO DO: player controllers
        GameController.instance.OnCombatEnd();

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
