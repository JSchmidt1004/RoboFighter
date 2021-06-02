using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public enum eState
    {
        Title,
        LevelUp,
        Fight
    }

    public eState State { get; set; } = eState.Title;

    static GameController instance;
    public static GameController Instance { get { return instance; } }

    public Robot[] robots = new Robot[2];

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        switch (State)
        {
            case eState.Title:
                State = eState.LevelUp;
                break;
            case eState.LevelUp:
                State = eState.Fight;
                break;
            case eState.Fight:

                break;
            default:
                break;
        }
    }

    public void GetOtherRobot(Robot current)
    {

    }
}
