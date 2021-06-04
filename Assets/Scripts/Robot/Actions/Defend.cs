using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Action
{
    public float chanceOfProc;
    void Start()
    {
        type = eType.Defend;
    }

    public Defend(string name, string desc, float chance, float cooldown = 1.5f, float stamCost = 5.0f)
    {
        this.name = name;
        //this.desc = desc;
        cooldownTime = cooldown;
        this.stamCost = stamCost;
        chanceOfProc = chance;
    }

    public override void Apply()
    {
        cooldownTimer = 0;
        cooldownUI.Cooldown(cooldownTime);
    }



}
