using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllActions : MonoBehaviour
{
    static AllActions instance;
    public static AllActions Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    public List<Action> ActionLibrary = new List<Action>();

    private void Start()
    {
        ActionLibrary.Add(new Attack("Basic Attack", "Basic attack module all combat bots have installed.", 1));
        ActionLibrary.Add(new Attack("Power Drill", "Drill used by construction bots.", 5, 2, 10));
        ActionLibrary.Add(new Attack("Short Circuit", "Uses a short range electric shock to fry the opponent.", 3, 1, 7));
        ActionLibrary.Add(new Attack("Saw Blades", "Shreds the enemy bot into bits", 7, 3, 12.5f));
        ActionLibrary.Add(new Attack("Mining Laser", "Uses a high powered mining laser to melt through the enemy defenses", 10, 5, 15));
        ActionLibrary.Add(new Defend("Metal Plates", "Metal plates welded to the bot to increase defenses, not practical", 5, 12, 2.5f));
        ActionLibrary.Add(new Defend("Plasteel Chassis", "Replaces your bot's chassis with high density plasteel to deflect attacks.", 15, 10, 10f));
        ActionLibrary.Add(new Defend("Oiled Joints", "Increases robot dexterity, allows it evade attacks more efficiently", 10, 15, 12f));
    }

    public List<Attack> AttackLibrary { get { return (List<Attack>)ActionLibrary.Where(b => b.type == Action.eType.Attack); } }
    public List<Defend> DefendLibrary { get { return (List<Defend>)ActionLibrary.Where(b => b.type == Action.eType.Defend); } }

    public Action GetAction(string name)
    {
        foreach(var action in ActionLibrary)
        {
            if (name.Trim().Equals(action.name.Trim())) return action;
        }
        Debug.Log("No actions with the name of " + name + '.');
        return null;
    }

    public Attack GetAttack(string name)
    {
        foreach (Action action in AttackLibrary)
        {
            if (name.Trim().Equals(action.name.Trim())) return (Attack)action;
        }
        Debug.Log("No actions with the name of " + name + '.');
        return null;
    }

    public Defend GetDefend(string name)
    {
        foreach (Action action in AttackLibrary)
        {
            if (name.Trim().Equals(action.name.Trim())) return (Defend)action;
        }
        Debug.Log("No actions with the name of " + name + '.');
        return null;
    }

}
