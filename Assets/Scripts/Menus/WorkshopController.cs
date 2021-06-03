using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkshopController : MonoBehaviour
{
    public WorkshopBot currentBot;
    public BotLibrary botLib;
    public AllActions actionsLib;
    public MenuController menuController;

    public Image selectedBot;

    public TMP_InputField nameInput;
    public List<ModuleButton> moduleButtons = new List<ModuleButton>();

    public List<TMP_Text> selectedMods;

    private void Start()
    {
        currentBot.animatorName = "Pete/PeteController";
        foreach(ModuleButton moduleButton in moduleButtons)
        {
            moduleButton.SetDisplay();
        }
    }

    public void OnCreate()
    {
        if(nameInput.text.Trim().Equals(""))
        {
            //Display that creation is invalid without a name
            Debug.Log("Empty Name");
            return;
        }
        if(currentBot.actions.Count == 0)
        {
            //must have one module
            Debug.Log("Need more than one module");
            return;
        }
        currentBot.name = nameInput.text;
        WorkshopBot newBot = currentBot;
        botLib.bots.Add(newBot);
        menuController.LoadMainMenu();
        //Load Main menu

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            foreach(WorkshopBot robot in botLib.bots)
            {
                if(robot == null)
                {
                    Debug.Log("robot is null?");
                    continue;
                }
                Debug.Log("Name : " + robot.name);
                Debug.Log("Actions");
                foreach(Action  action in robot.actions)
                {
                    Debug.Log(action.name);
                }

            }
        }
    }

    public void AddModule(Action action)
    {
        
        if(currentBot.actions.Count < 3) currentBot.actions.Add(action);
        else
        {
            //shift all mods down one and remove end;
            currentBot.actions[2] = currentBot.actions[1];
            currentBot.actions[1] = currentBot.actions[0];
            currentBot.actions[0] = action;
        }

        UpdateSelectedModDisplay();
    }
    public void RemoveModule(Action action)
    {
        currentBot.actions.Remove(action);
    }

    public void UpdateSelectedModDisplay()
    {
        
        for (int i = 0; i < selectedMods.Count; i++)
        {
            if (i >= currentBot.actions.Count) break;
            if (currentBot.actions[i] != null)
            {
                selectedMods[i].text = currentBot.actions[i].name;
                
            }
            else
            {
                selectedMods[i].text = "Empty";
            }
        }
    }

    public void ChangeAnimator(SpriteChooseButton scb)
    {
        currentBot.animatorName = scb.animName;
        selectedBot.sprite = scb.image.sprite;

    }
}
