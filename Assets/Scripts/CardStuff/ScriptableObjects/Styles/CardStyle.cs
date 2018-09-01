using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Style", menuName = "CardStyle")]
public class CardStyle : ScriptableObject
{
    public Sprite cardIcon;

    public Color mainColorA;
    public Color mainColorB;
    public Color accentColor;

    public Font nameTextFont;
    public Font descriptionTextFont;
    public Font flavorTextFont;
    public Font numbersTextFont;

    public Color nameTextColor;
    public Color descriptionTextColor;
    public Color flavorTextColor;
    public Color numbersTextColor;
}
