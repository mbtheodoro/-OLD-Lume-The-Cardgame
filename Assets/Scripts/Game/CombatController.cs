using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Turn
{
    PLAYER1,
    PLAYER2
}

public class CombatController : MonoBehaviour
{
    #region SINGLETON
    private static CombatController _instance;
    public static CombatController instance
    {
        get { return _instance; }
    }
    #endregion

    [SerializeField] private RectTransform player1Rect;
    [SerializeField] private RectTransform player2Rect;

    public UnitCard player1Card;
    public UnitCard player2Card;
    //public LocationCard location;

    private Turn _turn;

    #region PROPERTIES
    public Turn turn
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
            if (instance.turn == Turn.PLAYER1)
                return instance.player1Card;
            else
                return instance.player2Card;
        }
    }

    public static UnitCard defendingUnit
    {
        get
        {
            if (instance.turn == Turn.PLAYER1)
                return instance.player2Card;
            else
                return instance.player1Card;
        }
    }
    #endregion

    #region METHODS
    public static void SwitchTurn()
    {
        if(instance.turn == Turn.PLAYER1)
            instance.turn = Turn.PLAYER2;
        else
            instance.turn = Turn.PLAYER1;
    }
    #endregion

    #region UNITY
    private void Awake()
    {
        if(instance == null)
        {
            _instance = this;
        }
        else
            DestroyImmediate(gameObject);

    }

    private void OnEnable()
    {
        //TO DO: location determines turn
        turn = Turn.PLAYER1;

        if (player1Card != null && player2Card != null)
        {
            player1Card.SetParent(instance.player1Rect);
            player2Card.SetParent(instance.player2Rect);
        }
    }
    #endregion
}
