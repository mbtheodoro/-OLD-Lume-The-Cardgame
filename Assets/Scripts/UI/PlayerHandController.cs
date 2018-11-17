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
    public Text endTurnButtonText;

    public Sprite activeSprite, inactiveSprite;
    public Image handBackground;

    public float closedSize;
    public float openedSize;

    public PlayerInfo player;
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
            endTurnButton.gameObject.SetActive(active);

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
        endTurnButton.gameObject.SetActive(Active);
    }
    #endregion

    #region EVENTS
    public void OnGameStart()
    {
        Active = false;
    }

    public void OnTurnStart()
    {
        turn = true;
        Active = true;
    }

    public void OnUnitMoved(UnitCard unit, Tile tile)
    {

    }

    public void OnCombatStart()
    {
        inCombat = true;
        Active = false;
        endTurnButtonText.text = "PASS";
    }

    public void OnAttackTurnStart()
    {
        Active = true;
    }

    public void OnAttackCardPlayed(AttackCard card)
    {

    }

    public void OnAttackEnd()
    {
        Active = false;
    }

    public void OnCombatEnd()
    {
        inCombat = false;
        Active = turn;
        endTurnButtonText.text = "END TURN";
    }

    public void OnTurnEnd()
    {
        turn = false;
        Active = false;
    }

    public void OnEndTurnButtonClick()
    {
        if (inCombat)
        {
            LogWindow.Log(player + " decided not to attack that turn!");
            CombatController.OnAttackCardPlayed();
        }
        else
            GameController.instance.EndTurn();
    }
    #endregion

    #region UNITY
    void Start ()
    {
        hand.sizeDelta = new Vector2(0f, openedSize);
    }
    #endregion
}