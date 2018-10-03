using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAttackCard : AttackCard
{
    public override int baseDamage
    {
        get
        {
            return _baseDamage;
        }

        set
        {
            _baseDamage = value;
            baseDamageText.text = "0";
        }
    }

    public override void Activate()
    {
        SetUserEnemy();

        //deal damage
        int heal = baseDamage;

        heal += StatBasedDamageCalculation();
        user.ModifyHealth(-heal);

        if (heal > 0)
            Debug.Log(user.name + " used " + name + " on itself and healed " + heal + " damage!");

        //modifying status come after damage
        ModifyUserStats();
        ModifyEnemyStats();

        //callbacks
        CombatController.instance.location.OnAttackCardPlayed(this, user, enemy); //first resolve location effects
        user.OnAttack(this, enemy); //then resolve user
        enemy.OnAttackTarget(this, user); //then resolve enemy
        player.OnAttackCardPlayed(this); //then discard card and draw a new one
        CombatController.OnAttackCardPlayed(); //and finally, switch turns
    }
}
