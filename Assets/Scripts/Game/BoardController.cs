using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BoardController : MonoBehaviour
{
    #region SINGLETON
    private static BoardController _instance;
    public static BoardController instance
    {
        get { return _instance; }
    }
    #endregion

    #region REFERENCES
    public List<Tile> board;

    public RectTransform turnLocationRect;
    #endregion

    #region ATTRIBUTES
    /*[HideInInspector] */
    public Tile selectedTile = null;
    public LocationCard turnLocation;

    public bool combat;
    #endregion

    #region PROPERTIES

    #endregion

    #region METHODS
    #region STATICS
    public static void SelectTile(Tile tile)
    {
        instance.selectedTile = tile;
        instance.EnableAjdacentTiles();
    }

    public static void DeSelectTile()
    {
        instance.selectedTile = null;
        instance.ResetAllTiles();
    }

    public static void SetPlayersUnits(List<UnitCard> player1Cards, List<UnitCard> player2Cards)
    {
        instance.SetPlayersUnitsOnTiles(player1Cards, player2Cards);
    }
    #endregion
    
    private void ResetAllTiles()
    {
        instance.DisableAllTiles();
        instance.EnablePlayerTiles();
    }

    private void DisableAllTiles()
    {
        foreach (Tile t in board)
        {
            t.button.interactable = false;
        }
    }

    private void EnablePlayerTiles()
    {
        TilePlayer turnPlayer = (TilePlayer)Enum.Parse(typeof(TilePlayer), GameController.turnPlayer.ToString());

        foreach (Tile t in board)
        {
            if (t.Player == turnPlayer && !t.moved)
                t.button.interactable = true;
        }
    }

    public void EnableAjdacentTiles()
    {
        DisableAllTiles();
        board[selectedTile.id].button.interactable = true; //enable the clicked tile

        int[] tiles = BoardGraph.GetAdjacentNodes(selectedTile.id);
        for (int i = 0; i < tiles.Length; i++)
        {
            board[tiles[i]].button.interactable = TestTile(tiles[i], selectedTile.Player);
        }
    }

    private bool TestTile(int tile, TilePlayer tilePlayer)
    {
        PlayerInfo player = (PlayerInfo)Enum.Parse(typeof(PlayerInfo), tilePlayer.ToString());

        if (board[tile].card == null)
            return true;

        if (board[tile].card.player.player == player)
            return false;
        else
            return true;
    }

    private void SetPlayersUnitsOnTiles(List<UnitCard> player1Cards, List<UnitCard> player2Cards)
    {
        for (int i = 0; i < player1Cards.Count; i++)
        {
            board[i].AddCard(player1Cards[i]);
        }

        for (int i = 15; i > (15-player2Cards.Count); i--)
        {
            board[i].AddCard(player2Cards[15-i]);
        }
    }
    
    private void DrawLocationCard()
    {
        turnLocation = GameController.turnPlayerController.DrawLocationCard();
        turnLocation.SetParent(turnLocationRect);

        LogWindow.Log("The selected location for this turn is: " + turnLocation.name);
    }
    #endregion

    #region CALLBACKS
    public static void OnGameStart()
    {
        instance.DisableAllTiles();
    }

    public static void OnTurnStart()
    {
        foreach (Tile t in instance.board)
        {
            if (t.moved)
                t.moved = false;
        }

        instance.EnablePlayerTiles();

        instance.DrawLocationCard();
    }

    public static void OnUnitMoved(UnitCard unit, Tile tile)
    {

    }

    public static void OnCombatStart()
    {
        instance.combat = true;
    }

    public static void OnAttackTurnStart()
    {

    }

    public static void OnAttackCardPlayed()
    {

    }

    public static void OnAttackTurnEnd()
    {

    }

    public static void OnCombatEnd(UnitCard victoriousUnit)
    {
        instance.selectedTile.AddCard(victoriousUnit);
        DeSelectTile();
    }

    public static void OnTurnEnd()
    {
        instance.turnLocation.Discard();
        DeSelectTile();
        instance.DisableAllTiles();
        instance.combat = false;
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
    #endregion
}
