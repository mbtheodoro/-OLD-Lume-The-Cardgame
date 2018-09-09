using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardSpawn : MonoBehaviour
{
    public RectTransform canvas;
    public List<string> cardNames;

	// Use this for initialization
	void Start ()
    {
        foreach (string name in cardNames)
        {
            Card card = CardFactory.CreateCard(name);
            card.SetParent(canvas);
        }
	}
}
