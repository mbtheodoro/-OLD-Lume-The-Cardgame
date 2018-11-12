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
    public EndGameWindow endGameWindow;
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
        BoardController.OnTurnEnd();
        GameController.turnPlayerController.OnTurnEnd();

        LogWindow.Log(_turnPlayer + "'s turn has ended!");

        SwitchTurn();
        StartTurn();
    }

    private void EndGame()
    {
        if (player1Controller.units.Count > 0)
        {
            Debug.Log(player1Controller.units.Count);
            endGameWindow.OnGameEnd(PlayerInfo.PLAYER1, player1Controller.nation);
        }
        else
            endGameWindow.OnGameEnd(PlayerInfo.PLAYER2, player2Controller.nation);
    }

    private void SwitchTurn()
    {
        if (_turnPlayer == PlayerInfo.PLAYER1)
            _turnPlayer = PlayerInfo.PLAYER2;
        else
            _turnPlayer = PlayerInfo.PLAYER1;
    }

    private void StartGame()
    {
        //set itself
        _turnPlayer = PlayerInfo.PLAYER1;

        //set players
        player1Controller.OnGameStart(PlayerInfo.PLAYER1);
        player2Controller.OnGameStart(PlayerInfo.PLAYER2);

        armyController.SetBothPlayersArmies(Defines.player1nation, Defines.player2nation);

        //set board
        BoardController.OnGameStart();

        //after everything is set, start the first turn:
        StartTurn();
    }

    private void StartTurn()
    {
        LogWindow.Log(_turnPlayer + "'s turn starts now!");

        BoardController.OnTurnStart();
        GameController.turnPlayerController.OnTurnStart();
    }
    #endregion
        
    public static void OnCombatEnd()
    {
        bool count = false;
        if (instance.player1Controller.units.Count == 0)
            count = true;
        else if (instance.player2Controller.units.Count == 0)
            count = true;

        if (count)
            instance.EndGame();
        else
            instance.EndTurn();
    }

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
        StartGame();
    }
    #endregion
}
