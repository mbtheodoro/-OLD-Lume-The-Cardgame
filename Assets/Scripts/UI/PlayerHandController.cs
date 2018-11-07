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

    public Sprite activeSprite, inactiveSprite;
    public Image handBackground;

    public float closedSize;
    public float openedSize;
    #endregion

    #region ATTRIBUTES
    private bool turn, active, inCombat;
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

    public bool Active
    {
        get { return active; }

        set
        {
            active = value;
            if (active)
                handBackground.sprite = activeSprite;
            else
                handBackground.sprite = inactiveSprite;
        }
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
        endTurnButton.gameObject.SetActive(turn&&!inCombat);
    }
    #endregion

    #region CALLBACKS
    public void OnTurnStart()
    {
        turn = true;
        Active = true;

        endTurnButton.gameObject.SetActive(turn);
    }

    public void OnTurnEnd()
    {
        turn = false;
        Active = false;
        endTurnButton.gameObject.SetActive(false);
    }

    public void OnAttackStart()
    {
        Active = true;
    }

    public void OnAttackEnd()
    {
        Active = false;
    }

    public void OnCombatStart()
    {
        inCombat = true;
        endTurnButton.gameObject.SetActive(false);
    }

    public void OnCombatEnd()
    {
        inCombat = false;
    }
    #endregion

    // Use this for initialization
    void Start ()
    {
        hand.sizeDelta = new Vector2(0f, openedSize);
    }
}
