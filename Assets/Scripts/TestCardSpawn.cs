using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardSpawn : MonoBehaviour
{
    public RectTransform canvas;

    public List<string> cardNames;
    public string player1unit;
    public string player2unit;

	// Use this for initialization
	void Start ()
    {
        CombatController.instance.gameObject.SetActive(false);
        foreach (string name in cardNames)
        {
            Card card = CardFactory.CreateCard(name);
            card.SetParent(canvas);
        }

        CombatController.instance.player1Card = (UnitCard) CardFactory.CreateCard(player1unit);
        CombatController.instance.player2Card = (UnitCard) CardFactory.CreateCard(player2unit);
        CombatController.instance.gameObject.SetActive(true);
    }
}
