using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotLibrary : MonoBehaviour
{
    public List<WorkshopBot> bots;
    // Start is called before the first frame update
    void Awake()
    {
        bots = new List<WorkshopBot>();
        DontDestroyOnLoad(this);
    }

}
