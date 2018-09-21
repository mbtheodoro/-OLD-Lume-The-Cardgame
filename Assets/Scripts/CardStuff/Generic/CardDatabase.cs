using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    private static CardDatabase _instance;

    public List<CardData> attackList;
    public List<CardData> unitList;
    public List<CardData> equipList;
    public List<CardData> locationList;
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
            foreach(CardData card in attackList)
                cardDatabase.Add(card.name, card);
            foreach (CardData card in unitList)
                cardDatabase.Add(card.name, card);
            foreach (CardData card in equipList)
                cardDatabase.Add(card.name, card);
            foreach (CardData card in locationList)
                cardDatabase.Add(card.name, card);
            
            attackList.Clear();
            unitList.Clear();
            equipList.Clear();
            locationList.Clear();
        }
        else
            DestroyImmediate(gameObject);
    }

    public static CardData GetCardData(string cardName)
    {
        return instance.cardDatabase[cardName];
    }
}
