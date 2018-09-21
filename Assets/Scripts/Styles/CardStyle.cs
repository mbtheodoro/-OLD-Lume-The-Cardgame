using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardStyle", menuName = "Styles/CardStyle")]
public class CardStyle : ScriptableObject
{
    [Header("Sprites")]
    public Sprite cardIcon;

    [Header("Colors")]
    public Color mainColorA;
    public Color mainColorB;
    public Color accentColor;
    public Color borderColor;

    [Header("Fonts")]
    public Font nameTextFont;
    public Font descriptionTextFont;
    public Font flavorTextFont;
    public Font numbersTextFont;

    [Header("Text Colors")]
    public Color nameTextColor;
    public Color descriptionTextColor;
    public Color flavorTextColor;
    public Color numbersTextColor;
}
