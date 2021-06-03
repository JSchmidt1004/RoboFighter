using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public string name;
    public float health;
    public float stamina;

    public Action[] actions;

    public float stamPerSec;

    float second = 1.0f;
    float secondTimer = 0;

    float actionTime = 1.5f;
    float actionTimer = 0.0f;

    bool debugLog;

    public Robot(string name, float hp, float stam, List<Action> moves, float sps, float actionTime)
    {
        this.name = name;
        this.actionTime = actionTime;
        health = hp;
        stamina = stam;
        stamPerSec = sps;

        //populate action array
        actions = new Action[moves.Count];
        for (int i = 0; i < moves.Count-1; i++)
        {
            actions[i] = moves[i];
        }
    }
    public Robot(WorkshopBot botTemplate)
    {
        this.name = botTemplate.name;
        this.actionTime = botTemplate.actionTime;
        health = botTemplate.health;
        stamina = botTemplate.stamina;
        stamPerSec = botTemplate.stamPerSec;

        //populate action array
        actions = new Action[botTemplate.actions.Count];
        for (int i = 0; i < botTemplate.actions.Count - 1; i++)
        {
            actions[i] = botTemplate.actions[i];
        }

        //GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>($"Animations/{botTemplate.animatorName}");
    }

    private void Start()
    {
        debugLog = GameController.Instance.debugLogs;
    }
    private void Update()
    {
        //do nothing until we do shit
        secondTimer += Time.deltaTime;
        actionTimer += Time.deltaTime;
        if(secondTimer >= second)
        {
            stamina += stamPerSec;
        }
        if(actionTimer >= actionTime)
        {
            OnAct();
        }
    }

    public void OnHurt(float damage, List<string> effects = null)
    {
        if(debugLog) Debug.Log("Attempted Damage");
        //check if you list contains a defense item
        bool containsDefense = false;
        foreach(Action action in actions)
        {
            if (action.type == Action.eType.Defend) containsDefense = true;
        }
        Defend defense = null;
        bool foundValidDefend = false;
        if (containsDefense)
        {
            foreach (Action action in actions)
            {
                if (action.type == Action.eType.Defend && action.OffCooldown())
                {
                    defense = (Defend)action;
                    foundValidDefend = true;
                    break;
                }
            }
        }
        
        bool blockedDamage = false;
        if(foundValidDefend)
        {
            if (Random.Range(0, 100) <= defense.chanceOfProc)
            {
                defense.Apply();
                blockedDamage = true;
            }
        }

        if(!blockedDamage)
        {
            health -= damage;
            if(effects != null)
            {
                //add status effects
                if (debugLog) Debug.Log(name + " took " + damage + " damage!");
            }
            if (health <= 0)
            {
                OnDeath();
            }
        }
        else
        {
            //shield popup or something
            if (debugLog) Debug.Log("Defended attack!");
        }

    }

    public void OnAct()
    {
        if (!FindValidAction(out Action validAction))
        {
            if (debugLog) Debug.Log("No valid actions ready to be taken!");
            return;
        }
        else
        {
            if (debugLog) Debug.Log("Valid action found!");
            validAction.Apply();
        }
    }
    public void OnDeath()
    {
        //death anim or effect
        //Die screen

        //GameController.OnFinish(); ??
    }

    bool FindValidAction(out Action valid)
    {
        bool found = false;
        valid = null;

        //find a valid action
        List<Action> validActions = new List<Action>();
        //add all valid actions into a list
        foreach(Action action in actions)
        {
            if (action.type != Action.eType.Defend && action.OffCooldown() && action.stamCost <= stamina)
            {
                validActions.Add(action);
            }
            
        }
        if (validActions.Count == 0) return found;
        else
        {
            found = true;
            int index = Random.Range(0, validActions.Count);
            valid = actions[index];
        }

        return found;
    }

}
