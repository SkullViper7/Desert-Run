using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip3 : MonoBehaviour
{
    public Tip4 t4;
    public PlayerMovement pm;
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!pm.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                gameObject.SetActive(false);
                t4.Enable();
            }
        }
    }
}
