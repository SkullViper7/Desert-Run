using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public static bool isPaused = false;

    public Animator animator;

    

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
        animator.Play("PauseMenuAppear");
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
        
        isPaused = false;
        animator.SetTrigger("isPressedP");
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
