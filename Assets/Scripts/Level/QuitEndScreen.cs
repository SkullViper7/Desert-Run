using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitEndScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            SceneManager.LoadScene("Menu");
        }
        Invoke("AutoQuit", 23);
    }
    void AutoQuit()
    {
        SceneManager.LoadScene("Menu");
    }
}
