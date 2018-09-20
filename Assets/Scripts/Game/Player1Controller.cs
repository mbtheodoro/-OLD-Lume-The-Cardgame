using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Controller : MonoBehaviour
{
    public RectTransform thisRect;
    public RectTransform hand;
    public DiscardPile discardPile;
    public Deck attackDeck;
    public Deck locationDeck;

    public float closedSize;
    public float openedSize;

    public void DrawAttackCard()
    {
        Card card = attackDeck.DrawCard();
        card.SetParent(hand);
        hand.ForceUpdateRectTransforms();
    }

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
}
