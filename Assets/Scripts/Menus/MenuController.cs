using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject WorkshopPanel;
    public GameObject RoboSelectPanel;

    public  void LoadMainMenu()
    {
        MainMenuPanel.SetActive(true);
        WorkshopPanel.SetActive(false);
        //RoboSelectPanel.SetActive(false);
    }
    public  void LoadWorkshop()
    {
        MainMenuPanel.SetActive(false);
        WorkshopPanel.SetActive(true);
        //RoboSelectPanel.SetActive(false);
    }
    public  void LoadRoboSelect()
    {
        MainMenuPanel.SetActive(false);
        WorkshopPanel.SetActive(false);
        //RoboSelectPanel.SetActive(true);
    }
}
