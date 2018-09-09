using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDiscardPile : MonoBehaviour
{
    public RectTransform pile;
    public Card topCard;

    private DiscardPile discardPile = new DiscardPile();
    
    public void AddCard(Card card)
    {
        discardPile.AddCard(card.name);

        Destroy(topCard.gameObject);
        topCard = card;
        topCard.SetParent(pile);
    }

    public void RemoveCard(Card card)
    {
        if(card.name.Equals(topCard.name))
        {
            Destroy(topCard.gameObject);
            topCard = CardFactory.CreateCard(discardPile.GetTopCard());
            topCard.SetParent(pile);
        }
    }

    public Card GetCard(string cardName)
    {
        if (!discardPile.Contains(cardName))
            return null;

        if (cardName.Equals(topCard.name))
            return topCard;

        discardPile.RemoveCard(cardName);
        return CardFactory.CreateCard(cardName);
    }
}
