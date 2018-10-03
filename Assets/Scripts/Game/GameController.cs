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


        //set players attack decks
        for(int i = 0; i < earthArmy.attackCounts.Count; i++)
        {
            for(int j = 0; j < earthArmy.attackCounts[i]; j++)
            {
                player1Controller.attackDeck.AddCardTop(earthArmy.attacks[i].name);
                player2Controller.attackDeck.AddCardTop(earthArmy.attacks[i].name);
            }
        }
        player1Controller.attackDeck.ShuffleDeck();
        player2Controller.attackDeck.ShuffleDeck();


        //set players location decks
        foreach (LocationCardData card in earthArmy.locations)
        {
            player1Controller.locationDeck.AddCardTop(card.name);
            player2Controller.locationDeck.AddCardTop(card.name);
        }
        player1Controller.locationDeck.ShuffleDeck();
        player2Controller.locationDeck.ShuffleDeck();


        //draw cards for their hands
        player1Controller.DrawAttackCard(Defines.defaultHandSize);
        player2Controller.DrawAttackCard(Defines.defaultHandSize);

        //set player turn
        _turnPlayer = PlayerInfo.PLAYER1;

        //start combat
        CombatController.instance.StartCombat(turnPlayerController.DrawLocationCard(), (UnitCard)CardFactory.CreateCard(earthArmy.units[0].name), (UnitCard)CardFactory.CreateCard(earthArmy.units[1].name));
    }
    #endregion
}
