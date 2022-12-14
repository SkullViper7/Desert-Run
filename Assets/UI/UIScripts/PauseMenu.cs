using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public bool isPaused = false;

    public Animator animator;

    public GameObject tip1;
    public GameObject tip2;
    public GameObject tip3;

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
        tip1.SetActive(false);
        tip2.SetActive(false);
        tip3.SetActive(false);
    }

    void Resume()
    {
        Time.timeScale = 1.0f;
        
        isPaused = false;
        animator.SetTrigger("isPressedP");

        if (!tip2.activeSelf && !tip3.activeSelf) 
        {
            tip1.SetActive(true);
        }
        else if (!tip1.activeSelf && !tip3.activeSelf)
        {
            tip2.SetActive(true);
            tip3.SetActive(true);
        }
        else if (!tip2.activeSelf && !tip1.activeSelf)
        {
            tip3.SetActive(true);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
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
