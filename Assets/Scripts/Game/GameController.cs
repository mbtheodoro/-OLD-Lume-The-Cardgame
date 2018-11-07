using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerInfo
{
    PLAYER1,
    PLAYER2
}

public class GameController : MonoBehaviour
{
    #region SINGLETON
    private static GameController _instance;
    public static GameController instance
    {
        get { return _instance; }
    }
    #endregion
    
    #region ATTRIBUTES
    private PlayerInfo _turnPlayer;
    #endregion

    #region PROPERTIES
    public static PlayerInfo turnPlayer
    {
        get { return instance._turnPlayer; }
    }

    public static PlayerController turnPlayerController
    {
        get
        {
            if(instance._turnPlayer == PlayerInfo.PLAYER1)
                return instance.player1Controller;
            else
                return instance.player2Controller;
        }
    }
    #endregion

    #region REFERENCES
    public PlayerController player1Controller;
    public PlayerController player2Controller;
    public ArmyController armyController;
    #endregion

    #region METHODS
    public static PlayerController GetPlayerController(PlayerInfo player)
    {
        if (player == PlayerInfo.PLAYER1)
            return instance.player1Controller;
        else
            return instance.player2Controller;
    }

    public void EndTurn()
    {
        LogWindow.Log(_turnPlayer + "'s turn has ended!");
        SwitchTurn();
    }

    private void SwitchTurn()
    {
        BoardController.OnTurnEnd();
        GameController.turnPlayerController.OnTurnEnd();

        if (_turnPlayer == PlayerInfo.PLAYER1)
            _turnPlayer = PlayerInfo.PLAYER2;
        else
            _turnPlayer = PlayerInfo.PLAYER1;

        LogWindow.Log(_turnPlayer + "'s starts now!");
        BoardController.OnTurnStart();
        GameController.turnPlayerController.OnTurnStart();
    }
    #endregion

    #region EVENTS
    #endregion

    #region CALLBACKS
    public static void OnCombatEnd()
    {
        instance.EndTurn();
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

    private void Start()
    {
        //set player controllers
        player1Controller.player = PlayerInfo.PLAYER1;
        player2Controller.player = PlayerInfo.PLAYER2;

        armyController.SetBothPlayersArmies(Defines.player1nation, Defines.player2nation);
        
        ////set player turn
        _turnPlayer = PlayerInfo.PLAYER1;

        BoardController.ResetAllTiles();
        BoardController.OnTurnStart();
        GameController.turnPlayerController.OnTurnStart();

        //set starting resources
        player1Controller.RegenResources();
        player2Controller.RegenResources();
    }
    #endregion
}
