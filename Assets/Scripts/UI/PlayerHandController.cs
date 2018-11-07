using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHandController : MonoBehaviour
{
    #region REFERENCES
    public RectTransform thisRect;
    public RectTransform hand;

    public Button endTurnButton;

    public Text staminaText;
    public Text manaText;
    public Text playerText;

    public float closedSize;
    public float openedSize;
    #endregion

    #region ATTRIBUTES
    private bool turn;
    #endregion

    #region PROPERTIES
    public int stamina
    {
        set { staminaText.text = value.ToString(); }
    }

    public int mana
    {
        set { manaText.text = value.ToString(); }
    }
    #endregion

    #region METHODS
    public void AddCard(AttackCard card)
    {
        card.SetParent(hand);
        hand.ForceUpdateRectTransforms();
    }
    #endregion

    #region VISUALS
    public void OpenHand()
    {
        thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, openedSize);

        hand.gameObject.SetActive(true);
        LayoutRebuilder.ForceRebuildLayoutImmediate(hand);

        playerText.gameObject.SetActive(false);
        endTurnButton.gameObject.SetActive(false);
    }

    public void CloseHand()
    {
        thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, closedSize);

        hand.gameObject.SetActive(false);
        playerText.gameObject.SetActive(true);
        endTurnButton.gameObject.SetActive(turn);
    }
    #endregion

    #region CALLBACKS
    public void OnTurnStart()
    {
        turn = true;
        endTurnButton.gameObject.SetActive(turn);
    }

    public void OnTurnEnd()
    {
        turn = false;
        endTurnButton.gameObject.SetActive(false);
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        hand.sizeDelta = new Vector2(0f, openedSize);
    }
}
