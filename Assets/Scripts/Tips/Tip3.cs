using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tip3 : MonoBehaviour
{
    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void OnDash(InputValue val)
    {
        gameObject.SetActive(false);
    }
}
