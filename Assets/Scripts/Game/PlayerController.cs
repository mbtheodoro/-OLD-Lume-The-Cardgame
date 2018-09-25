using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region REFERENCES
    public RectTransform thisRect;
    public RectTransform hand;
    
    public float closedSize;
    public float openedSize;
    #endregion

    #region ATTRIBUTES
    public PlayerInfo player;

    public DiscardPile attackDiscardPile;
    public DiscardPile locationDiscardPile;
    public Deck attackDeck;
    public Deck locationDeck;
    #endregion

    #region METHODS
    public void ReshuffleAttackDeck()
    {
        for(int i = 0; i < attackDiscardPile.size; i++)
            attackDeck.AddCardTop(attackDiscardPile.GetTopCard());
        attackDeck.ShuffleDeck();
    }

    public void ReshuffleLocationDeck()
    {
        for (int i = 0; i < locationDiscardPile.size; i++)
            locationDeck.AddCardTop(locationDiscardPile.GetTopCard());
        locationDeck.ShuffleDeck();
    }

    public void DrawAttackCard()
    {
        if (attackDeck.Count() <= 0)
            ReshuffleAttackDeck();

        AttackCard card = (AttackCard) attackDeck.DrawCard();
        card.player = this;
        card.SetParent(hand);
        hand.ForceUpdateRectTransforms();
    }

    public void DrawAttackCard(int n)
    {
        for (int i = 0; i < n; i++)
            DrawAttackCard();
    }

    public LocationCard DrawLocationCard()
    {
        if (locationDeck.Count() <= 0)
            ReshuffleLocationDeck();

        LocationCard card = (LocationCard) locationDeck.DrawCard();
        card.player = this;
        return card;
    }

    public void DiscardAttackCard(AttackCard card)
    {
        attackDiscardPile.AddCard(card.name);
        Destroy(card.gameObject);
    }

    public void DiscardLocationCard(LocationCard card)
    {
        locationDiscardPile.AddCard(card.name);
        Destroy(card.gameObject);
    }

    #region VISUALS
    public void OpenHand()
    {
        thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, openedSize);

        hand.gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(hand);
    }

    public void CloseHand()
    {
        thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, closedSize);

        hand.gameObject.SetActive(false);
    }
    #endregion
    #endregion

    #region CALLBACKS
    public void OnAttackCardPlayed(AttackCard card)
    {
        DiscardAttackCard(card);
        DrawAttackCard();
    }
    #endregion

    #region UNITY
    private void Start()
    {
        attackDiscardPile = new DiscardPile();
        locationDiscardPile = new DiscardPile();
        attackDeck = new Deck(Defines.attackDeckSize);
        locationDeck = new Deck(Defines.locationDeckSize);

        hand.sizeDelta = new Vector2(0f, openedSize);
    }
    #endregion
}
