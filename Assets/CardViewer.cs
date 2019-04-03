using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardViewer : MonoBehaviour
{
    public CardData card;
    public RectTransform container;
    
    // Use this for initialization
    void Start ()
    {
        if(card != null)
        {
            if (card.type == CardType.LOCATION)
                container.sizeDelta = new Vector2(container.sizeDelta.x, 320f);

            Card newCard = CardFactory.CreateCard(card.name);
            newCard.SetParent(container);
        }
	}
}
