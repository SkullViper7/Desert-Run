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

    public void OnJump(InputValue val)
    {
        gameObject.SetActive(false);
        t3.Enable();
    }
}
