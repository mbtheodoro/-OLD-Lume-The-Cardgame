using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCardSpawn : MonoBehaviour
{
    public RectTransform canvas;
    public string cardName;

	// Use this for initialization
	void Start ()
    {
        RectTransform card = CardFactory.CreateCard(cardName);
        card.SetParent(canvas);
        card.localPosition = Vector3.zero;
        card.localScale = Vector3.one;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
