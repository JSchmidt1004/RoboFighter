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

    public void OnHurt(float damage, string effect = "none")
    {
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
            if (health <= 0)
            {
                OnDeath();
            }
        }
        else
        {
            //shield popup or something
        }

    }

    public void OnAct()
    {
        //choose an action that is not on cooldown
        bool[] checkedActions = new bool[actions.Length];
        int index = Random.Range(0, actions.Length);
        bool done = true;
        //should make sure that all actions are not
        while (actions[index].type == Action.eType.Defend && !actions[index].OffCooldown() && (stamina - actions[index].stamCost) < 0.0f)
        {
            checkedActions[index] = true;
            index = Random.Range(0, actions.Length);
            done = true;
            foreach(bool b in checkedActions)
            {
                if (!b) done = false;
            }
            if (done) break;
        }
        if (done) return;

    }
    public void OnDeath()
    {
        //death anim or effect
        //Die screen
    }

}
