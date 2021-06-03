using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModuleButton : MonoBehaviour
{
    public TMP_Text nameTextBox;
    public Image icon;

    public string moduleName;

    AllActions allActions;
    Action action;

    void Start()
    {
        allActions = AllActions.Instance;
        action = allActions.GetAction(moduleName);
    }

    public void OnAddModule()
    {
        //add module to the tentative list of modules for the robot
            //if list has an empty spot, add it
            //if it doesnt have an empty spot, display that there is no spot
    }
}
