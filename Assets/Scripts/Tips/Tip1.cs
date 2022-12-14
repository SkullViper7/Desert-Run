using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip1 : MonoBehaviour
{
    public Tip2 t2;
    public void OnMove(InputValue val)
    {
        gameObject.SetActive(false);
        t2.Enable();
    }
}
