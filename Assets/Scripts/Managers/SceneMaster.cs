using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    public Object[] scenes;
    public string currentScene;

    public void LoadScene(string name)
    {
        
        foreach (var scene in scenes)
        {
            if(scene.name == name)
            {
                SceneManager.LoadScene(name, LoadSceneMode.Single);
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    
    
}
