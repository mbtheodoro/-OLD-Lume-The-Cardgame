using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile
{
    private List<string> cards;

    public DiscardPile()
    {
        cards = new List<string>();
    }

    public void AddCard(string cardName)
    {
        cards.Add(cardName);
    }

    public void RemoveCard(string cardName)
    {
        cards.Remove(cardName);
    }

    public bool Contains(string cardName)
    {
        return cards.Contains(cardName);
    }

    public string Peek()
    {
        return cards[cards.Count - 1];
    }

    public string GetTopCard()
    {
        string card = cards[cards.Count - 1];
        RemoveCard(card);
        return card;
    }

    public int size
    {
        get { return cards.Count; }
    }
}
