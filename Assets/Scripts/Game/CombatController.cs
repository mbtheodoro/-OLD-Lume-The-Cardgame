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

    public UnitCard player1Card;
    public UnitCard player2Card;
    //public LocationCard location;
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
    public void SwitchTurn()
    {
        if(instance.turn == PlayerInfo.PLAYER1)
            instance.turn = PlayerInfo.PLAYER2;
        else
            instance.turn = PlayerInfo.PLAYER1;
    }

    public static void OnAttackCardPlayed()
    {
        instance.SwitchTurn();
    }
    #endregion

    #region UNITY
    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;
        }
        else
            DestroyImmediate(gameObject);
    }

    private void OnEnable()
    {
        //TO DO: location determines turn
        turn = PlayerInfo.PLAYER1;

        if (player1Card != null && player2Card != null)
        {
            player1Card.SetParent(instance.player1Rect);
            player2Card.SetParent(instance.player2Rect);
        }
    }
    #endregion
}
