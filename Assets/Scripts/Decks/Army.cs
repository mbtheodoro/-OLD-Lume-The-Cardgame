using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army
{
    private List<string> units;
    private List<string> equips;
    private Deck attackDeck;
    private Deck locationDeck;

    public Army()
    {
        units = new List<string>(Defines.unitsInAnArmy);
        equips = new List<string>(Defines.equipsInAnArmy);
        attackDeck = new Deck(Defines.attackDeckSize);
        locationDeck = new Deck(Defines.locationDeckSize);
    }

    public Army(List<string> units, List<string> equips, Deck attackDeck, Deck locationDeck)
    {
        this.units = units;
        this.equips = equips;
        this.attackDeck = attackDeck;
        this.locationDeck = locationDeck;
    }

    #region GETTERS
    public List<string> Units
    {
        get
        {
            return units;
        }
    }

    public List<string> Equips
    {
        get
        {
            return equips;
        }
    }
    
    public Deck AttackDeck
    {
        get { return attackDeck; }
    }

    public Deck LocationDeck
    {
        get { return locationDeck; }
    }
    #endregion

    #region ADDERS
    public void AddUnit(string unit)
    {
        Units.Add(unit);
    }

    public void AddEquip(string equip)
    {
        Equips.Add(equip);
    }

    public void AddAttack(string attack)
    {
        AttackDeck.AddCardTop(attack);
    }

    public void AddLocation(string location)
    {
        LocationDeck.AddCardTop(location);
    }
    #endregion

    #region SERIALIZE
    //TO DO
    #endregion
}
