using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisappear : MonoBehaviour
{
    public PauseMenu pauseMenu;
    public bool isPressedP = false;
    public bool isPauseMenu = PauseMenu.isPaused;

    

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (!isPauseMenu)
            {
                isPressedP = false;
            }

            else
            {
                isPressedP= true;
            }


        }
    }
}
