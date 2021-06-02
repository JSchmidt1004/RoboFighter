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

    public override void Apply()
    {
        cooldownTimer = 0;
    }



}
