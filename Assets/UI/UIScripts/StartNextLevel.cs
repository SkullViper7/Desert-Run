using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextLevel : MonoBehaviour
{
    private int nextSceneToLoad;
    private void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        
    }

    public void startNextLevel(int nextSceneToLoad)
    {

        SceneManager.LoadScene(nextSceneToLoad);
    }
}
