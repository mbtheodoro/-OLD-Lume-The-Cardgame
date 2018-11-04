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
    private ArmyData player1army;
    private ArmyData player2army;

    private UnitCard unit1;
    private UnitCard unit2;
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

    public ArmyData earthArmy;
    public ArmyData fireArmy;
    public ArmyData waterArmy;
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
        SwitchTurn();
    }

    private void SetPlayersAttacks()
    {
        //player 1
        for (int i = 0; i < player1army.attackCounts.Count; i++)
        {
            for (int j = 0; j < player1army.attackCounts[i]; j++)
                player1Controller.attackDeck.AddCardTop(player1army.attacks[i].name);
        }
        player1Controller.attackDeck.ShuffleDeck();

        //player 2
        for (int i = 0; i < player2army.attackCounts.Count; i++)
        {
            for (int j = 0; j < player2army.attackCounts[i]; j++)
                player2Controller.attackDeck.AddCardTop(player2army.attacks[i].name);
        }
        player2Controller.attackDeck.ShuffleDeck();
    }

    private void SetPlayersLocations()
    {
        //player 1
        foreach (LocationCardData card in player1army.locations)
            player1Controller.locationDeck.AddCardTop(card.name);

        player1Controller.locationDeck.ShuffleDeck();

        //player 2
        foreach (LocationCardData card in player2army.locations)
            player2Controller.locationDeck.AddCardTop(card.name);

        player2Controller.locationDeck.ShuffleDeck();
    }

    private void SetPlayersUnits()
    {
        // player 1
        foreach (UnitCardData card in player1army.units)
        {
            UnitCard unitCard = (UnitCard)CardFactory.CreateCard(card.name);
            unitCard.player = player1Controller;
            player1Controller.units.Add(unitCard);
        }

        //player 2
        foreach (UnitCardData card in player2army.units)
        {
            UnitCard unitCard = (UnitCard)CardFactory.CreateCard(card.name);
            unitCard.player = player2Controller;
            player2Controller.units.Add(unitCard);
        }

        BoardController.SetPlayersUnits(player1Controller.units, player2Controller.units);
    }
    
    private void SwitchTurn()
    {
        BoardController.OnTurnEnd();
        if (_turnPlayer == PlayerInfo.PLAYER1)
            _turnPlayer = PlayerInfo.PLAYER2;
        else
            _turnPlayer = PlayerInfo.PLAYER1;
        BoardController.OnTurnStart();
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

        player1Controller.nation = Nation.EARTH;
        player2Controller.nation = Nation.FIRE;

        player1army = earthArmy;
        player2army = fireArmy;

        ////set players units
        SetPlayersUnits();

        ////set players attack decks
        SetPlayersAttacks();

        ////set players location decks
        SetPlayersLocations();


        ////draw cards for their hands
        player1Controller.DrawAttackCard(Defines.defaultHandSize);
        player2Controller.DrawAttackCard(Defines.defaultHandSize);

        ////set player turn
        _turnPlayer = PlayerInfo.PLAYER1;

        BoardController.ResetAllTiles();

        ////start combat
        //test();
        //CombatController.instance.StartCombat(turnPlayerController.DrawLocationCard(), unit1, unit2);
    }
    #endregion
}
