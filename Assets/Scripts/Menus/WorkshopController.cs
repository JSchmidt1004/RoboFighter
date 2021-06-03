using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkshopController : MonoBehaviour
{
    public WorkshopBot currentBot;
    public BotLib botLib;
    public AllActions actionsLib;

    public TMP_InputField nameInput;

    public void OnCreate()
    {
        if(nameInput.text.Trim().Equals(""))
        {
            //Display that creation is invalid without a name
        }
        //check if they have at least one module
        botLib.bots.Add(new Robot(currentBot));

    }

    public void OnChangeBotVisual(string name)
    {
        currentBot.animatorName = name;
    }
    public void AddModule(Action action)
    {
        currentBot.actions.Add(action);
    }
    public void RemoveModule(Action action)
    {
        currentBot.actions.Remove(action);
    }
}
