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
    public RectTransform thisRect;
    public RectTransform rect;

    public UnitCard card;
    [SerializeField] private TilePlayer player;
    #endregion

    #region ATTRIBUTES
    private int _id;
    private bool _moved;
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

    public bool moved
    {
        get { return  _moved; }
        set { _moved = value; }
    }
    #endregion

    #region METHODS
    public void AddCard(UnitCard card)
    {
        if(card == null)
        {
            RemoveCard();
            return;
        }

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
        }
        else if(prevSelectedTile.id == this.id)
        {
            BoardController.DeSelectTile();
        }
        else
        {
            if(card == null) //second click of a regular move operation
            {
                AddCard(prevSelectedTile.card);
                prevSelectedTile.RemoveCard();
                moved = true;
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

                CombatController.StartCombat(BoardController.instance.turnLocation, player1Card, player2Card);
            }
        }
    }
    #endregion

    #region UNITY
    private void Start()
    {
        _id = int.Parse(gameObject.name);
        rect.sizeDelta = new Vector2(rect.sizeDelta.x, thisRect.sizeDelta.y-10);
    }
    #endregion
}
