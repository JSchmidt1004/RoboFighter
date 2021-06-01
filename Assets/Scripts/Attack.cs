using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    float damage;

    private void Awake()
    {
        type = eType.Attack;
    }

    public override void Apply()
    {
        //apply damage to other robot (onhurt(damage))
        
    }
}
