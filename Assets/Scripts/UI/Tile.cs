using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum TilePlayer
{
    PLAYER1,
    PLAYER2,
    NEUTRAL
}

public class Tile : MonoBehaviour
{
    #region REFERENCES
    public Button button;
    public RectTransform rect;
    [SerializeField] private TilePlayer player;
    #endregion

    #region ATTRIBUTES
    private int _id;

    public UnitCard card;
    #endregion

    #region PROPERTIES
    public TilePlayer Player
    {
        get { return player; }
    }

    public int id
    {
        get { return _id; }
    }
    #endregion

    #region METHODS
    public void AddCard(UnitCard card)
    {
        this.card = card;
        card.SetParent(rect);

        if (card.player.player == PlayerInfo.PLAYER1)
            player = TilePlayer.PLAYER1;
        else
            player = TilePlayer.PLAYER2;
    }

    public void RemoveCard()
    {
        this.card = null;
        player = TilePlayer.NEUTRAL;
    }
    #endregion

    #region EVENTS
    public void OnClick()
    {
        Tile prevSelectedTile = BoardController.instance.selectedTile;

        if (prevSelectedTile == null) //first click
        {
            BoardController.SelectTile(this);
            //enable adjacent tiles
        }
        else
        {
            if(card == null) //second click of a regular move operation
            {
                AddCard(prevSelectedTile.card);
                prevSelectedTile.RemoveCard();
                BoardController.DeSelectTile();
            }
            else //combat initiation
            {
                UnitCard player1Card, player2Card;

                if(Player == TilePlayer.PLAYER1)
                {
                    player1Card = this.card;
                    player2Card = prevSelectedTile.card;
                }
                else
                {
                    player1Card = prevSelectedTile.card;
                    player2Card = this.card;
                }
                
                BoardController.SelectTile(this); //to remember where the winner will stay
                prevSelectedTile.RemoveCard();

                CombatController.StartCombat(GameController.turnPlayerController.DrawLocationCard(), player1Card, player2Card);
            }
        }
    }
    #endregion

    #region UNITY
    private void Start()
    {
        _id = int.Parse(gameObject.name);
    }
    #endregion
}
