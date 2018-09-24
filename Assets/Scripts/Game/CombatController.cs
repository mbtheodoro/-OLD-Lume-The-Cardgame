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
        if(instance.turn == PlayerInfo.PLAYER1)
            instance.turn = PlayerInfo.PLAYER2;
        else
            instance.turn = PlayerInfo.PLAYER1;
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
                if (player1Card.CurrentStrength > player2Card.CurrentStrength)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.CurrentStrength < player2Card.CurrentStrength)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.AGILITY:
                if (player1Card.CurrentAgility > player2Card.CurrentAgility)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.CurrentAgility < player2Card.CurrentAgility)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.WISDOM:
                if (player1Card.CurrentWisdom > player2Card.CurrentWisdom)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.CurrentWisdom < player2Card.CurrentWisdom)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.SPIRIT:
                if (player1Card.CurrentSpirit > player2Card.CurrentSpirit)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.CurrentSpirit < player2Card.CurrentSpirit)
                    turn = PlayerInfo.PLAYER2;
                else
                    turn = GameController.turnPlayer;
                break;

            case Initiative.HEALTH:
                if (player1Card.CurrentHealth > player2Card.CurrentHealth)
                    turn = PlayerInfo.PLAYER1;
                else if (player1Card.CurrentHealth < player2Card.CurrentHealth)
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

    private void StartCombat()
    {
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
        if(defendingUnit.CurrentHealth <= 0)
            instance.OnCombatEnd();
        else
            instance.SwitchTurn();
    }

    private void OnCombatStart()
    {
        location.OnCombatStart(player1Card, player2Card);
        player1Card.OnCombatStart(player2Card);
        player2Card.OnCombatStart(player1Card);
        //TO DO: then controllers
    }

    private void OnCombatEnd()
    {
        location.OnCombatEnd(player1Card, player2Card);
        player1Card.OnCombatEnd();
        player2Card.OnCombatEnd();
        //TO DO: then controllers
        gameObject.SetActive(false);
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
    
    private void OnEnable()
    {
        StartCombat();
    }
    #endregion
}
