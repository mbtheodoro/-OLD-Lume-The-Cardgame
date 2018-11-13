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

    public float posXOutOfCombat;
    public float posXOnCombat;
    private float posYOutOfCombat;

    private bool combat;
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
        if(card != null)
            Destroy(card.gameObject);
    }

    private void Open()
    {
        if(combat)
            thisRect.anchoredPosition = new Vector2(posXOnCombat, 0f);
        else
            thisRect.anchoredPosition = new Vector2(posXOutOfCombat, posYOutOfCombat);
    }

    private void Close()
    {
        thisRect.anchoredPosition = new Vector2(0f, posYOutOfCombat);
    }

    public static void OnCombatStart()
    {
        instance.combat = true;
        ResetWindow();
    }

    public static void OnCombatEnd()
    {
        instance.combat = false;
        ResetWindow();
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

    private void Start()
    {
        posYOutOfCombat = thisRect.anchoredPosition.y;
    }
    #endregion
}
