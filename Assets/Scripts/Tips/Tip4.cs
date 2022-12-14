using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip4 : MonoBehaviour
{
    public PlayerMovement pm;
    public CameraTrigger ct;
    public void OnJump(InputValue val)
    {
        if (pm.isWallJumping && ct.isInSecondRoom)
        {
            gameObject.SetActive(false);
        }
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }
}
