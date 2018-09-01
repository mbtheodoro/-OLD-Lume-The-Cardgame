using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    private static CardDatabase _instance;

    public List<CardData> cardList;
    private Dictionary<string, CardData> cardDatabase = new Dictionary<string, CardData>();

    private static CardDatabase instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this; //singleton pattern

            //instantiate card database
            foreach(CardData card in cardList)
            {
                cardDatabase.Add(card.name, card);
            }

            cardList.Clear();
        }
        else
            DestroyImmediate(gameObject);
    }

    public static CardData GetCardData(string cardName)
    {
        return instance.cardDatabase[cardName];
    }
}
