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

    public override int CalculateDamage()
    {
        int heal = baseDamage;

        heal += StatBasedDamageCalculation();

        heal = user.UserDamageModifiers(heal, this, enemy, true);

        heal = enemy.TargetDamageModifiers(heal, this, user, true);

        heal = CombatController.instance.location.DamageModifiers(heal, user, enemy, true);

        return heal;
    }

    public override void Activate()
    {
        SetUserEnemy();

        //deal damage
        int heal = CalculateDamage();
        
        int result = user.ModifyHealth(-heal);

        if (result > 0)
            LogWindow.Log(user.name + " used " + name + " and healed " + result + " damage!");
        else
            LogWindow.Log(user.name + " can't be healed right now!");

        //modifying status come after damage
        ModifyUserStats();
        ModifyEnemyStats();

        //callbacks
        CombatController.instance.location.OnAttackCardPlayed(this, user, enemy); //first resolve location effects
        user.OnAttackCardPlayed(this, enemy); //then resolve user
        enemy.OnAttackCardTarget(this, user); //then resolve enemy
        player.OnAttackCardPlayed(this); //then discard card and draw a new one
        CombatController.OnAttackCardPlayed(); //and finally, switch turns
    }
}
