using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFactory : MonoBehaviour
{
    private static CardFactory _instance;

    public RectTransform unitCardPrefab;
    public RectTransform equipCardPrefab;
    public RectTransform spellCardPrefab;
    public RectTransform attackCardPrefab;
    public RectTransform locationCardPrefab;

    public CardStyle earthStyle;
    public CardStyle waterStyle;
    public CardStyle fireStyle;
    public CardStyle neutralStyle;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this; //singleton pattern
        }
        else
            DestroyImmediate(gameObject);
    }

    public static CardFactory instance
    {
        get { return _instance; }
    }

    public static RectTransform CreateCard(string name)
    {
        CardData card = CardDatabase.GetCardData(name);
        CardStyle style;
        GameObject go;

        if (card.nation == Nation.EARTH)
            style = instance.earthStyle;
        else if (card.nation == Nation.FIRE)
            style = instance.fireStyle;
        else if (card.nation == Nation.WATER)
            style = instance.waterStyle;
        else
            style = instance.neutralStyle;

        switch (card.type)
        {
            case CardType.ATTACK:
                //instantiate prefab
                go = (GameObject) Instantiate(instance.attackCardPrefab.gameObject, Vector3.zero, Quaternion.identity);

                //load card data and style
                LoadAttackCard loadAttackCard = go.GetComponent<LoadAttackCard>();
                loadAttackCard.LoadCardData((AttackCardData)card);
                loadAttackCard.LoadCardStyle(style);
                
                return go.GetComponent<RectTransform>();

            case CardType.UNIT:
                //instantiate prefab
                go = (GameObject)Instantiate(instance.unitCardPrefab.gameObject, Vector3.zero, Quaternion.identity);

                //load card data and style
                LoadUnitCard loadUnitCard = go.GetComponent<LoadUnitCard>();
                loadUnitCard.LoadCardData((UnitCardData) card);
                loadUnitCard.LoadCardStyle(style);

                return go.GetComponent<RectTransform>();

            case CardType.SPELL:
                //instantiate prefab
                go = (GameObject)Instantiate(instance.attackCardPrefab.gameObject, Vector3.zero, Quaternion.identity);

                //load card data and style
                LoadSpellCard loadSpellCard = go.GetComponent<LoadSpellCard>();
                loadSpellCard.LoadCardData((SpellCardData)card);
                loadSpellCard.LoadCardStyle(style);

                return go.GetComponent<RectTransform>();

            case CardType.LOCATION:
                //instantiate prefab
                go = (GameObject)Instantiate(instance.attackCardPrefab.gameObject, Vector3.zero, Quaternion.identity);

                //load card data and style
                LoadLocationCard loadLocationCard = go.GetComponent<LoadLocationCard>();
                loadLocationCard.LoadCardData((LocationCardData)card);
                loadLocationCard.LoadCardStyle(style);

                return go.GetComponent<RectTransform>();

            case CardType.EQUIP:
                //instantiate prefab
                go = (GameObject)Instantiate(instance.attackCardPrefab.gameObject, Vector3.zero, Quaternion.identity);

                //load card data and style
                LoadEquipCard loadEquipCard = go.GetComponent<LoadEquipCard>();
                loadEquipCard.LoadCardData((EquipCardData)card);
                loadEquipCard.LoadCardStyle(style);

                return go.GetComponent<RectTransform>();
        }

        return null;
    }
}
