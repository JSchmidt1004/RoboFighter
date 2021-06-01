using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : MonoBehaviour
{
    public string name;
    public float cooldown;
    public enum eType
    {
        Attack, Defend, Modifier, Misc
    }

    public eType type;

    public abstract void Apply();


}
