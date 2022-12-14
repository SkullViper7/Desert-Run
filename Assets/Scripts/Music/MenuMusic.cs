using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    private void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Menu")
        {
            // Stops playing music in level 1 scene
            Destroy(gameObject);
        }
    }
}
