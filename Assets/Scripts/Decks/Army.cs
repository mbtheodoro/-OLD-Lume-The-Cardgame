using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army
{
    private List<string> units;
    private List<string> equips;
    private Deck spellDeck;
    private Deck attackDeck;
    private Deck locationDeck;

    public Army()
    {
        units = new List<string>(Defines.maxUnits);
        equips = new List<string>(Defines.maxEquips);
        spellDeck = new Deck(Defines.maxSpells);
        attackDeck = new Deck(Defines.maxAttacks);
        locationDeck = new Deck(Defines.maxLocations);
    }

    public Army(List<string> units, List<string> equips, Deck spellDeck, Deck attackDeck, Deck locationDeck)
    {
        this.units = units;
        this.equips = equips;
        this.spellDeck = spellDeck;
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

    public Deck SpellDeck
    {
        get
        {
            return spellDeck;
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

    public void AddSpell(string spell)
    {
        SpellDeck.AddCardTop(spell);
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
