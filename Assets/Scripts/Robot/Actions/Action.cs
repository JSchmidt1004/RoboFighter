using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public string name;
    public enum eType
    {
        Attack, Defend, Modifier, Misc
    }
    public enum eTarget
    {
        Self, Other, Both
    }

    public eType type;
    public eTarget target;
    public float stamCost = 1.0f;
    public float cooldownTime = 2.0f;
    public float cooldownTimer = 0;


    public abstract void Apply();


    private void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    public bool OffCooldown()
    {
        bool off = (cooldownTimer >= cooldownTime);
        if (off) cooldownTimer = 0;
        return off;
    }



}
