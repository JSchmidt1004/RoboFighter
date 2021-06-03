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

    public Action action;

    void Start()
    {
        nameTextBox.text = action.name;
        icon.sprite = action.icon;
    }

    public void SetDisplay()
    {
        nameTextBox.text = action.name;
        //Debug.Log("Action name = " + action.name);

    }
}
