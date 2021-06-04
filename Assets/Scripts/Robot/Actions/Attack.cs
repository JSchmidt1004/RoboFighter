using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    public float damage;
    List<string> effects;

    public Attack(string name, string desc, float damage,  float cooldown = 1.5f, float stamCost = 5.0f )
    {
        this.name = name;
        //this.desc = desc;
        cooldownTime = cooldown;
        this.stamCost = stamCost;
        this.damage = damage;
    }
    private void Awake()
    {
        type = eType.Attack;
    }

    public void ApplyDamage(Robot target)
    {
        //apply damage to other robot (onhurt(damage))
        target.OnHurt(damage);
        cooldownTimer = 0;
        cooldownUI.Cooldown(cooldownTime);

    }

    public override void Apply()
    {

    }
}
