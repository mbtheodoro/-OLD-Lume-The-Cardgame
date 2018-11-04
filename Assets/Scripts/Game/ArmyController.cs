using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyController : MonoBehaviour
{
    #region REFERENCES
    public PlayerController player1Controller;
    public PlayerController player2Controller;

    public ArmyData earthArmy;
    public ArmyData fireArmy;
    public ArmyData waterArmy;
    #endregion

    #region ATTRIBUTES
    private ArmyData player1army;
    private ArmyData player2army;
    #endregion

    #region PROPERTIES

    #endregion

    #region METHODS
    public void SetBothPlayersArmies(Nation player1Nation, Nation player2Nation)
    {
        player1Controller.nation = player1Nation;
        player2Controller.nation = player2Nation;

        switch(player1Controller.nation)
        {
            case Nation.FIRE:
                player1army = fireArmy;
                break;
            case Nation.EARTH:
                player1army = earthArmy;
                break;
            default:
                player1army = waterArmy;
                break;
        }

        switch (player2Controller.nation)
        {
            case Nation.FIRE:
                player2army = fireArmy;
                break;
            case Nation.EARTH:
                player2army = earthArmy;
                break;
            default:
                player2army = waterArmy;
                break;
        }

        SetPlayersCards();
    }

    public void SetPlayer1Army(Nation nation)
    {
        player1Controller.nation = nation;

        switch (player1Controller.nation)
        {
            case Nation.FIRE:
                player1army = fireArmy;
                break;
            case Nation.EARTH:
                player1army = earthArmy;
                break;
            default:
                player1army = waterArmy;
                break;
        }
    }

    public void SetPlayer2Army(Nation nation)
    {
        player2Controller.nation = nation;

        switch (player1Controller.nation)
        {
            case Nation.FIRE:
                player2army = fireArmy;
                break;
            case Nation.EARTH:
                player2army = earthArmy;
                break;
            default:
                player2army = waterArmy;
                break;
        }
    }

    public void SetPlayersCards()
    {
        SetPlayersUnits();
        SetPlayersAttacks();
        SetPlayersLocations();
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

        player1Controller.DrawAttackCard(Defines.defaultHandSize);
        player2Controller.DrawAttackCard(Defines.defaultHandSize);
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
    #endregion
}
