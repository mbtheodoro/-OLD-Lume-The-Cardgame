using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    public string cardName;
    public string flavorText;
    public string description;

    public Sprite art;
    public Sprite cardIcon;

    public Color nameBackground;
    public Color descriptionBackground;
}
