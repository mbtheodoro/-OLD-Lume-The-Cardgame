using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    #endregion

    #region ATTRIBUTES
    /*[HideInInspector] */
    public Tile selectedTile = null;
    #endregion

    #region PROPERTIES

    #endregion

    #region METHODS
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
        PlayerInfo player;
        if (tilePlayer == TilePlayer.PLAYER1)
            player = PlayerInfo.PLAYER1;
        else
            player = PlayerInfo.PLAYER2;

        if (board[tile].card == null)
            return true;

        if (board[tile].card.player.player == player)
            return false;
        else
            return true;
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
        foreach (Tile t in board)
        {
            if(t.Player != TilePlayer.NEUTRAL)
                t.button.interactable = true;
        }
    }

    private void ResetAllTiles()
    {
        DisableAllTiles();
        EnablePlayerTiles();
    }

    private void SetPlayersUnitsOnTiles(List<UnitCard> player1Cards, List<UnitCard> player2Cards)
    {
        for (int i = 0; i < player1Cards.Count; i++)
        {
            board[i].AddCard(player1Cards[i]);
        }

        for (int i = 15; i > (15-player1Cards.Count); i--)
        {
            board[i].AddCard(player2Cards[15-i]);
        }
    }
    #endregion

    #region CALLBACKS
    public static void OnCombatEnd(UnitCard victoriousUnit)
    {
        instance.selectedTile.AddCard(victoriousUnit);
        DeSelectTile();
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
