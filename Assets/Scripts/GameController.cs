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

    public GameObject robotPrefab;

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

    public void CreateFightUI()
    {
        //find the bot library in scene
        BotLibrary bl = FindObjectOfType<BotLibrary>();
        if (bl == null)
        {
            if(debugLogs) Debug.Log("Couldn't find the library");
            return;
        }
        
        //get robots
        Robot player = new Robot(bl.bots[0]);
        Robot cpu = new Robot(bl.bots[(int)Random.Range(0, bl.bots.Count)]);

        //create in game bots
        GameObject playerRobot = Instantiate(robotPrefab, playerSpot);
        GameObject cpuRobot = Instantiate(robotPrefab, enemySpot);

        //get access to the components
        robots[0] = playerRobot.GetComponent<Robot>();
        robots[1] = cpuRobot.GetComponent<Robot>();

        //overwrite the info with our own info
        robots[0].OverwriteInfo(player);
        robots[1].OverwriteInfo(cpu);

        //set opponents
        robots[0].opponent = robots[1];
        robots[1].opponent = robots[0];

        //UI
        RobotUI playerUI = playerRobot.GetComponent<RobotUI>();
        RobotUI cpuUI = cpuRobot.GetComponent<RobotUI>();
        playerUI.Setup(robots[0].name, robots[0].animPath);
        cpuUI.Setup(robots[1].name, robots[1].animPath);

        //add all action ui
        foreach(Action action in robots[0].actions)
        {
            playerUI.AddAbility(action);
        }
        foreach(Action action in robots[1].actions)
        {
            cpuUI.AddAbility(action);
        }
        
        //fuck bitches

    }
}
