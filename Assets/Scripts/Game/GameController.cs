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

    //test
    public string player1unit;
    public string player2unit;
    public string location;
    public List<string> attacks;

    #region ATTRIBUTES
    private PlayerInfo _turnPlayer;
    #endregion

    #region PROPERTIES
    public static PlayerInfo turnPlayer
    {
        get { return instance._turnPlayer; }
    }
    #endregion

    #region REFERENCES
    public PlayerController player1Controller;
    public PlayerController player2Controller;
    #endregion

    #region METHODS
    public static PlayerController GetPlayerController(PlayerInfo player)
    {
        if (player == PlayerInfo.PLAYER1)
            return instance.player1Controller;
        else
            return instance.player2Controller;
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

        //set players attack card decks
        foreach (string name in attacks)
        {
            player1Controller.attackDeck.AddCardTop(name);
            player2Controller.attackDeck.AddCardTop(name);

            player1Controller.attackDeck.ShuffleDeck();
            player2Controller.attackDeck.ShuffleDeck();
        }

        //draw cards for their hands
        player1Controller.DrawAttackCard(Defines.defaultHandSize);
        player2Controller.DrawAttackCard(Defines.defaultHandSize);

        //set player turn
        _turnPlayer = PlayerInfo.PLAYER1;

        //start combat
        CombatController.instance.StartCombat((LocationCard)CardFactory.CreateCard(location), (UnitCard)CardFactory.CreateCard(player1unit), (UnitCard)CardFactory.CreateCard(player2unit));
    }
    #endregion
}
