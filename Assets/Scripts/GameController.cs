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
    public bool debugLogs = true;

    static GameController instance;
    public static GameController Instance { get { return instance; } }

    public Transform playerSpot;
    public Transform enemySpot;

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


    public Robot GetOtherRobot(Robot current)
    {
        if (current == robots[0]) return robots[1];
        else if (current == robots[1]) return robots[0];
        return null;
    }
}
