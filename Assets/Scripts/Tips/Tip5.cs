using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip5 : MonoBehaviour
{
    private void Update()
    {
        Invoke("Disable", 3);
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }
}
