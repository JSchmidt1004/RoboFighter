using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public int health;
    public float stamina;

    public Action[] actions;

    public float stamPerSec;

    private void Update()
    {
        
    }

    public void OnHurt(float damage, string effect = "none")
    {

    }

}
