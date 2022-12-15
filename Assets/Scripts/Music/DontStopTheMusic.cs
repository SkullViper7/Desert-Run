using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontStopTheMusic : MonoBehaviour
{
    private static DontStopTheMusic instance = null;
    public static DontStopTheMusic Instance => instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Menu" || currentScene.name == "EndScreen")
        {
            Destroy(gameObject);
        }
    }
}
