using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    float damage;
    List<string> effects;

    private void Awake()
    {
        type = eType.Attack;
    }

    public void Apply(Robot target)
    {
        //apply damage to other robot (onhurt(damage))
        target.OnHurt(damage);
        cooldownTimer = 0;
    }

    public override void Apply()
    {
        throw new System.NotImplementedException();
    }
}
