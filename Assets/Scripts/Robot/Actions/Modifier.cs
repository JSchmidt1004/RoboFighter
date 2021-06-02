using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifier : Action
{


    enum eEffect
    {
        //attackTime, other things
    }
    enum eEffectType
    {
        Buff, Debuff, Neutral
    }

    private void Start()
    {
        type = eType.Modifier;
    }

    public override void Apply()
    {
        cooldownTimer = 0;
        Debug.Log(name + " used.");
    }
}
