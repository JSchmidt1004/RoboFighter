using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RobotUI : MonoBehaviour
{
    public TMP_Text nameText;

    public void OnSelectBot()
    {
        foreach(Robot robot in GameController.Instance.robots)
        {
            if (robot.name == nameText.text)
            {
                GameController.Instance.robots[0] = robot;
                break;
            }
        }
    }
}
