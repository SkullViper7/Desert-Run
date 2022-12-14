using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip1 : MonoBehaviour
{
    public Tip2 t2;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            gameObject.SetActive(false);
            t2.Enable();
        }
    }
}
