using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private int deckSize;
    private List<string> deck;

    #region PROPERTIES
    public int DeckSize
    {
        get { return deckSize; }
    }
    #endregion

    #region CONSTRUCTORS
    public Deck(int deckSize)
    {
        this.deckSize = deckSize;
        deck = new List<string>(deckSize);
    }
    #endregion

    #region METHODS
    public void ShuffleDeck()
    {
        deck.Shuffle<string>();
    }

    public void AddCardBottom(string cardName)
    {
        deck.Add(cardName);
    }

    public void AddCardTop(string cardName)
    {
        deck.Insert(0, cardName);
    }

    public Card DrawCard()
    {
        string card = deck[0];
        deck.RemoveAt(0);
        return CardFactory.CreateCard(card);
    }

    public int Count()
    {
        return deck.Count;
    }
    #endregion
}

public static class ExtensionMethods
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            int k = Random.Range(0, n) % n;
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
