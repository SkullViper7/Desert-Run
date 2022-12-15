using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip4 : MonoBehaviour
{
    public PlayerMovement pm;
    public CameraTrigger ct;

    public Tip5 t5;
    private void Update()
    {
        if (pm.isWallSliding)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                gameObject.SetActive(false);
                t5.Enable();
            }
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
