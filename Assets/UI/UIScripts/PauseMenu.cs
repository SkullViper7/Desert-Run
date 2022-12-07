using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public static bool isPaused = false;
   
    public void TogglePause()
    {
        if(isPaused)
        {
            Pause();
        }

        else
        {
            Resume();
        }
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
        isPaused= true;
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!isPaused) {
            Pause();
            }

            else
            {
                Resume();
            }


        }
    }


}
