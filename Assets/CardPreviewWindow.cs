using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPreviewWindow : MonoBehaviour
{
    #region SINGLETON
    private static CardPreviewWindow _instance;
    public static CardPreviewWindow instance
    {
        get { return _instance; }
    }
    #endregion

    #region REFERENCES
    public RectTransform thisRect;
    #endregion

    #region ATTRIBUTES
    Card card;

    public float posX;
    #endregion

    #region METHODS
    public static void Preview(Card card)
    {
        instance.AddCard((Card) GameObject.Instantiate(card));
        instance.Open();
    }

    public static void ResetWindow()
    {
        instance.RemoveCard();
        instance.Close();
    }

    private void AddCard(Card card)
    {
        this.card = card;
        this.card.SetParent(thisRect);
    }

    private void RemoveCard()
    {
        Destroy(card.gameObject);
    }

    private void Open()
    {
        thisRect.anchoredPosition = new Vector2(posX, thisRect.anchoredPosition.y);
    }

    private void Close()
    {
        thisRect.anchoredPosition = new Vector2(0f, thisRect.anchoredPosition.y);
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
