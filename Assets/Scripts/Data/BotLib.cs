using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BotLibrary", menuName = "Data/BotLibrary")]
public class BotLib : ScriptableObject
{
    public List<WorkshopBot> bots = new List<WorkshopBot>();

}
