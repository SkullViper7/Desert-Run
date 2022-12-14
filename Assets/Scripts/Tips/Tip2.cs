using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip2 : MonoBehaviour
{
    public Tip3 t3;
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            gameObject.SetActive(false);
            t3.Enable();
        }
    }
}
