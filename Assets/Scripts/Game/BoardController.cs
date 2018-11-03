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
    /*[HideInInspector] */public Tile selectedTile = null;
    #endregion

    #region PROPERTIES

    #endregion
    
    #region METHODS
    public static void SelectTile(Tile tile)
    {
        instance.selectedTile = tile;
    }

    public static void DeSelectTile()
    {
        instance.selectedTile = null;
    }

    public static void SetPlayersUnits(List<UnitCard> player1Cards, List<UnitCard> player2Cards)
    {
        instance.SetPlayersUnitsOnTiles(player1Cards, player2Cards);
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
