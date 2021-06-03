using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WorkshopData", menuName = "Data/WorkshopData")]
public class WorkshopBot : ScriptableObject
{
    public string name;
    public float health = 50;
    public float stamina = 50;

    public List<Action> actions;

    public float stamPerSec = 0.5f;

    public float actionTime = 1.5f;

    public string animatorName;

}
